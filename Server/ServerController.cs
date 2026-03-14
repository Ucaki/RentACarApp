using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
using SystemOperations.AdminSO;
using SystemOperations.AutomobilSO;
using SystemOperations.CarClassSO;
using SystemOperations.KorisnikSO;
using SystemOperations.MestoSO;
using SystemOperations.RentSO;

namespace Server
{
    public class ServerController
    {
       // private static ServerController _instance;
        private readonly IRepository<IEntity> _repository;
        private readonly IConnectionFactory _factory;
        //public static ServerController Initialize(IRepository<IEntity> repo, IConnectionFactory factory) 
        //{
        //    if(_instance == null) _instance = new ServerController(repo, factory); return _instance;
        //}
        internal ServerController(IRepository<IEntity> repo, IConnectionFactory factory) {
            _repository = repo;
            _factory = factory;
        }

        internal Automobil AddAutomobil(Automobil auto) 
        {
            BaseSO so = new ZapamtiVoziloSO(_repository, _factory);
            so.ExecuteTemplate(auto);
            return (Automobil)so.Result;
        }

        internal List<KlasaAutomobila> GetAllCarClass(KlasaAutomobila klasaAutomobila)
        {
            BaseSO so = new GetAllCarClassesSO(_repository, _factory);
            so.ExecuteTemplate(klasaAutomobila);
            return (List<KlasaAutomobila>)so.Result;
        }

        internal Radnik Login(Radnik radnik)
        {
            BaseSO so = new LoginSO(_repository, _factory);
            so.ExecuteTemplate(radnik);
            return (Radnik)so.Result;
        }

        internal List<Automobil> GetAllOrFillteredListCars(Automobil automobil)
        {
            BaseSO so = new GetAllOrFilteredCarsList(_repository, _factory);
            so.ExecuteTemplate(automobil);
            return (List<Automobil>)so.Result;
        }

        internal int DeleteCar(Automobil automobil)
        {
            BaseSO so = new DeleteCarSO(_repository, _factory);
            so.ExecuteTemplate(automobil);
            return (int)so.Result;
        }

        internal int UpdateCar(Automobil automobil)
        {
            BaseSO so = new UpdateCarSO(_repository,_factory);
            so.ExecuteTemplate(automobil);
            return (int)so.Result;
        }

        internal List<Korisnik> GetAllUsers(Korisnik korisnik)
        {
            BaseSO so = new GetAllUsersSO(_repository, _factory);
            so.ExecuteTemplate(korisnik);
            return (List<Korisnik>)so.Result;
        }

        internal List<Korisnik> GetFilteredUsers(Korisnik korisnik)
        {
            BaseSO so = new GetFilteredUsersSO(_repository, _factory);
            so.ExecuteTemplate(korisnik);
            return (List<Korisnik>)so.Result;
        }

        internal List<Mesto> GetAllPlaces(Mesto mesto)
        {
            BaseSO so = new GetPlacesSO(_repository, _factory);
            so.ExecuteTemplate(mesto);
            return (List<Mesto>)so.Result;
        }

        internal Korisnik AddUser(Korisnik korisnik)
        {
            BaseSO so = new AddUserSO(_repository, _factory);
            so.ExecuteTemplate(korisnik);
            return (Korisnik)so.Result;
        }

        internal Iznajmljivanje AddRent(Iznajmljivanje iznajmljivanje)
        {
            BaseSO so = new AddRentSO(_repository, _factory);
            so.ExecuteTemplate(iznajmljivanje);
            return (Iznajmljivanje)so.Result;
        }

        internal List<Iznajmljivanje> GetListRents(Iznajmljivanje i)
        {
            BaseSO so = new GetListUserRentsSO(_repository, _factory);
            so.ExecuteTemplate(i);
            return (List<Iznajmljivanje>)so.Result;
        }

        internal int ReleaseRent(Iznajmljivanje iznajmljivanje)
        {
            BaseSO so = new ReleaseRentSO(_repository, _factory);
            so.ExecuteTemplate(iznajmljivanje);
            return (int)so.Result;
        }
    }
}
