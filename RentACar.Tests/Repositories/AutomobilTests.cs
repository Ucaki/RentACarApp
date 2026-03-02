using Common.Domain;
using Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RentACar.Tests.Services
{
    public class AutomobilTests
    {
        [Fact]
        public void AddAutomobil_ShouldReturnGeneratedID()
        {
            var repo = new GenericDbRepository();
            var auto = new Automobil { Godiste = 2009, RegistarskiBroj = "BG155RS", Marka = "moskvich", Model = "Oldtajmer", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            repo.BeginTransaction();
            try
            {
                repo.Add(auto);
                Automobil inserted = (Automobil)repo.Find(auto, auto.IdCondition);
                Assert.NotNull(inserted);
                Assert.True(inserted.AutomobilID > 0);
                Assert.Equal("BG155RS", inserted.RegistarskiBroj);
                Assert.Equal("moskvich", inserted.Marka);
                Assert.Equal("Oldtajmer", inserted.Model);
                Assert.Equal(3, inserted.Klasa.KlasaID);
                Assert.Equal(StatusAutomobila.dostupan, inserted.Status);
                
            }
            finally
            {
                repo.RollBack();
            }
        }
        [Fact]
        public void DeleteAutomobil_ShouldReturnAffectedRows()
        {
            var repo = new GenericDbRepository();
            var auto = new Automobil { Godiste = 2009, RegistarskiBroj = "BG156RS", Marka = "jeep", Model = "cross", Klasa = new KlasaAutomobila() { KlasaID = 1 }, Status = StatusAutomobila.dostupan };
            repo.BeginTransaction();
            try
            {
                repo.Add(auto);
                int affectedRows = repo.Delete(auto);
                Assert.True(affectedRows == 1);
            }
            finally
            {
                repo.RollBack();
            }
        }
        [Fact]
        public void DeleteAutomobil_ShouldThrowException()
        {
            var repo = new GenericDbRepository();
            var auto = new Automobil() { AutomobilID = 999999 };

            repo.BeginTransaction();
            try
            {
                Assert.Throws<Exception>(() => repo.Delete(auto));
            }
            finally
            { repo.RollBack(); }
        }
        [Fact]
        public void FindAutomobil_ShouldReturnObjectIEntity()
        {
            var repo = new GenericDbRepository();
            var auto1 = new Automobil { Godiste = 2009, RegistarskiBroj = "BG155RS", Marka = "moskvich", Model = "Oldtajmer", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            //var auto2 = new Automobil { Godiste = 2009, RegistarskiBroj = "BG345RS", Marka = "lada", Model = "Niva", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            repo.BeginTransaction();
            try
            {
                repo.Add(auto1);
                var autoFound = repo.Find(auto1, auto1.IdCondition);
                Automobil returned = (Automobil)repo.Find(auto1, auto1.IdCondition);
                Assert.NotNull(returned);
                Assert.True(returned.AutomobilID > 0);
                Assert.Equal("BG155RS", returned.RegistarskiBroj);
                Assert.Equal("moskvich", returned.Marka);
                Assert.Equal("Oldtajmer", returned.Model);
                Assert.Equal(3, returned.Klasa.KlasaID);
                Assert.Equal(StatusAutomobila.dostupan, returned.Status);
                
            }
            finally
            {
                repo.RollBack();
            }
        }

        [Fact]
        public void GetAllAutomobil_ShouldReturnListOfIEntity()
        {
            var repo = new GenericDbRepository();
            var auto1 = new Automobil { Godiste = 2009, RegistarskiBroj = "BG155RS", Marka = "moskvich", Model = "Oldtajmer", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            var auto2 = new Automobil { Godiste = 2009, RegistarskiBroj = "BG345RS", Marka = "lada", Model = "Niva", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            repo.BeginTransaction();
            try
            {
                repo.Add(auto1);
                repo.Add(auto2);
               var autoLista =repo.GetAll(auto1);
                Assert.NotNull(autoLista);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID ==auto1.AutomobilID);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID == auto2.AutomobilID);
            }
            finally
            {
                repo.RollBack();
            }
        }
        [Fact]
        public void GetAutomobils_ShouldReturnListOfIEntityFilteredByCondition()
        {
            var repo = new GenericDbRepository();
            var auto1 = new Automobil { Godiste = 2009, RegistarskiBroj = "BG155RS", Marka = "moskvich", Model = "Oldtajmer", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            var auto2 = new Automobil { Godiste = 2009, RegistarskiBroj = "BG345RS", Marka = "lada", Model = "Niva", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            repo.BeginTransaction();
            try
            {
                repo.Add(auto1);
                repo.Add(auto2);
                var autoLista = repo.GetAll(auto1, "KlasaID=3");
                Assert.NotNull(autoLista);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID == auto1.AutomobilID);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID == auto2.AutomobilID);
            }
            finally
            {
                repo.RollBack();
            }
        }
        [Fact]
        public void UpdateAutomobil_ShouldChangeValues() 
        {
            var repo = new GenericDbRepository();
            var auto1 = new Automobil { Godiste = 2009, RegistarskiBroj = "BG155RS", Marka = "moskvich", Model = "Oldtajmer", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            repo.BeginTransaction();

            try
            {
                repo.Add(auto1);
                auto1.Marka = "suzuki";
                repo.Update(auto1, auto1.IdCondition);
                Automobil updated = (Automobil)repo.Find(auto1, auto1.IdCondition);
                Assert.Equal("suzuki", updated.Marka);
            }
            finally
            {
                repo.RollBack();
            }
        }
    }
}
