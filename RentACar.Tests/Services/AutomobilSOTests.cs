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
    public class AutomobilSOTests
    {
        [Fact]
        public void AddAutomobil_ShouldReturnGeneratedID() {
            var repo = new GenericDbRepository();
            var auto = new Automobil { Godiste = 2009, RegistarskiBroj = "BG155RS", Marka = "moskvich", Model = "Oldtajmer", Klasa = new KlasaAutomobila() { KlasaID = 3 }, Status = StatusAutomobila.dostupan };
            repo.BeginTransaction();
            repo.Add(auto);
            repo.RollBack();
            Assert.True(auto.AutomobilID > 0);
        }
    }
}
