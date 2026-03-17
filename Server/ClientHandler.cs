using Common.Communication;
using Common.Domain;
using Common.Exceptions;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private Socket _clientSocket;
        private readonly ServerController _controller;
        private JsonNetworkSerializer _serializer;
        public event EventHandler LoggedInClient;
        public event EventHandler LoggedOutClient;
        bool signal;

        public Radnik radnik;

        public ClientHandler(Socket client, ServerController controller)
        {
            _clientSocket = client;
            _controller = controller;
            _serializer = new JsonNetworkSerializer(new NetworkStream(client));
            signal = true;
        }
        internal void HandleRequest()
        {
            try
            {
                while (signal)
                {
                    Request req = _serializer.Receive<Request>();
                    Response resp = ProcessRequest(req);
                    _serializer.Send(resp);
                }
            }
            catch (SocketException ex)
            {
                Debug.WriteLine("Communication with client stopped");
                Debug.WriteLine(">>>SOCKET>>>" + ex.Message);
            }
            catch (IOException ex)
            {
                Debug.WriteLine("Communication with client stopped");
                Debug.WriteLine(">>>IO>>>" + ex.Message);
            }
            finally
            {
                Stop();
                _serializer.Close();
            }
        }



        public Response ProcessRequest(Request req)
        {
            Response res = new Response();
            try
            {
                switch (req.Operation)
                {
                    case OperationType.Login:
                        Radnik r = _controller.Login(_serializer.ReadType<Radnik>(req.Argument));
                        if (r != null)
                        {
                            if (!Session.currentlyLoggedWorkers.Contains(r))
                            {
                                radnik = r;
                                res.Result = r;
                                res.Message = "Uspešna prijava na sistem!";
                                res.IsSuccessful = true;
                                Session.currentlyLoggedWorkers.Add(r);
                                LoggedInClient?.Invoke(this, EventArgs.Empty);

                            }
                            else
                            {
                                res.IsSuccessful = false;
                                res.ErrorMessage = "Radnik sa ovim korisničkim imenom je već ulogovan";
                            }
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Neuspešna prijava, radnik ne postoji u sistemu!";
                        }
                        break;
                    case OperationType.LogOut:
                        Session.currentlyLoggedWorkers.Remove(radnik);
                        LoggedOutClient.Invoke(this, EventArgs.Empty);
                        res.IsSuccessful = true;
                        res.Message = "uspesno ste se izlogovali (CH msg)";
                        break;

                    ////Cars part
                    case OperationType.AddNewCar:
                        Automobil a = _controller.AddAutomobil(_serializer.ReadType<Automobil>(req.Argument));
                        if (a != null)
                        {
                            res.Result = a;
                            res.IsSuccessful = true;
                            res.Message = "Sistem created new car object.";
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Vozilo nije sačuvano";
                        }
                        break;
                    case OperationType.GetCarClass:
                        List<KlasaAutomobila> list = _controller.GetAllCarClass(new KlasaAutomobila());
                        res.Result = list;
                        if (res.Result != null)
                        {
                            res.IsSuccessful = true;
                        }
                        break;
                    case OperationType.FilterCars:
                        List<Automobil> listCars = _controller.GetAllOrFillteredListCars(_serializer.ReadType<Automobil>(req.Argument));
                        res.Result = listCars;
                        if (res.Result != null)
                        {
                            res.IsSuccessful = true;
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "ne postoji automobil sa datom regitracijom.";
                        }
                       
                        break;
                    case OperationType.UpdateCar:
                        res.Result = _controller.UpdateCar(_serializer.ReadType<Automobil>(req.Argument));
                        if ((int)res.Result == 1)
                            res.IsSuccessful = true;
                        else { 
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Vozilo nije obrisano!";
                        }
                        break;
                    case OperationType.DeleteCar:
                        res.Result=_controller.DeleteCar(_serializer.ReadType<Automobil>(req.Argument));
                        if ((int)res.Result == 1)
                            res.IsSuccessful = true;
                        else { 
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Vozilo nije izmenjeno!";
                        }
                        break;

                    //Users
                    case OperationType.GetAllUsers:
                        res.Result = _controller.GetAllUsers(new Korisnik());
                        if (res.Result != null)
                        {
                            res.IsSuccessful = true;
                        }
                        else {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Ne postoje korisnici u bazi!";
                        }
                        break;

                    case OperationType.GetFilteredUsers:
                        res.Result = _controller.GetFilteredUsers(_serializer.ReadType<Korisnik>(req.Argument));
                        List<Korisnik> korisnici = (List<Korisnik>)res.Result;

                        if (korisnici.Count>0)
                        {
                            res.IsSuccessful = true;
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Korisnici koji odgovaraju zadatoj vrednosti nisu pronadjeni!";
                        }
                        break;
                    case OperationType.GetAllPlaces:
                        res.Result = _controller.GetAllPlaces(new Mesto());
                        if (res.Result != null)
                        {
                            res.IsSuccessful = true;
                        }
                        break;
                    case OperationType.AddUsers:
                        Korisnik kor = _controller.AddUser(_serializer.ReadType<Korisnik>(req.Argument));
                        if (kor != null)
                        {
                            res.Result = kor;
                            res.IsSuccessful = true;
                            res.Message = "Sistem je zapamtio novog korisnika!";
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Sistem ne može da sačuva novog korisnika!";
                        }
                        break;
                        

                    //rent
                    case OperationType.AddRent:
                        Iznajmljivanje rent = _controller.AddRent(_serializer.ReadType<Iznajmljivanje>(req.Argument));
                        if (rent != null)
                        {
                            res.Result = rent;
                            res.IsSuccessful = true;
                            res.Message = "Sistem zapamtio novo iznajmljivanje.";
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Sistem ne moze da zapamti novo iznajmljivanje";
                        }
                        break;
                    case OperationType.GetListRents:
                        res.Result = _controller.GetListRents(_serializer.ReadType<Iznajmljivanje>(req.Argument));
                        if (res.Result != null)
                        {
                            res.IsSuccessful = true;
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Ne postoje iznajmljivanja za korisnika!";
                        }
                        break;
                    case OperationType.GetListRentItems:
                        res.Result = _controller.GetListRentItems(_serializer.ReadType<Iznajmljivanje>(req.Argument));
                        if (res.Result != null)
                        {
                            res.IsSuccessful = true;
                        }
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Sistem ne moze da vrati stavke iznajmljivanja za zadato iznajmljivanje.";
                        }
                        break;
                    case OperationType.ReleaseRent:
                        res.Result = _controller.ReleaseRent(_serializer.ReadType<Iznajmljivanje>(req.Argument));
                        if ((int)res.Result > 0)
                            res.IsSuccessful = true;
                        
                        else
                        {
                            res.IsSuccessful = false;
                            res.ErrorMessage = "Sistem ne moze da razduzi iznajmljivanje!";
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (ValidationException ve)
            {
                res.IsSuccessful = false;
                res.ErrorMessage = ve.Message;
            }
            catch (Exception ex)
            {
                res.IsSuccessful = false;
                res.ErrorMessage = ex.Message;
                Debug.WriteLine(">>>>>>>" + ex.Message);
            }
            return res;
        }

        private readonly object _lockObj = new object();
        public void Stop()
        {
            lock (_lockObj)
            {
                if (_clientSocket != null)
                {
                    _clientSocket.Shutdown(SocketShutdown.Both);
                    _clientSocket.Close();
                    _clientSocket = null;
                    Session.currentlyLoggedWorkers.Remove(radnik);
                    LoggedOutClient?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}
