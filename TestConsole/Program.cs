using Common.Domain;
using Repository.Implementation;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Automobil auto = new Automobil() { Godiste = 2009, RegistarskiBroj = "BG126RS", Marka = "renault", Model = "megane", Klasa = new KlasaAutomobila(){ KlasaID = 2 }, Status=StatusAutomobila.dostupan};
            IDbRepository<IEntity> genericRepo = new GenericDbRepository();
            TestAddAutomobil();
            
            
            
            void TestAddAutomobil()
            {
                try
                {
                    genericRepo.BeginTransaction();
                    genericRepo.Add(auto);
                    genericRepo.Commit();
                    Console.WriteLine($"Upisan automobil u bazi sa id brojem {auto.AutomobilID}");
                    while (true) { }
                }
                catch (Exception ex)
                {
                    genericRepo.RollBack();
                    //Added using system.Diagnostics, proveri sta radi Debug iako je intuitivno
                    Debug.WriteLine(">>>" + ex.Message);
                   
                }
                finally { genericRepo.CloseConnection(); }
            }
        }
    }
}
