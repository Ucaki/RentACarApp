using Common.Domain;
using RentACar.Tests.ClassBuilder;
using Repository.Connection;
using Repository.Implementation;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace RentACar.Tests.Services
{
    public class AutomobilTests
    {
        
        private GenericDbRepository createRepo()
        {
            IConnectionFactory factory = new SqlConnectionFactory(ConfigurationManager.ConnectionStrings["RentACar"].ConnectionString);
            return new GenericDbRepository(factory);

        }
        private void ExecuteInTransaction(Action<GenericDbRepository, IDbConnection, IDbTransaction> action)
        {
            var factory = new SqlConnectionFactory(ConfigurationManager.ConnectionStrings["RentACar"].ConnectionString);
            var repo = new GenericDbRepository(factory);
            using (var conn = factory.CreateConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        action(repo, conn, transaction);
                    }
                    finally
                    {
                        transaction.Rollback();
                    }
                }
            }

        }
        [Fact]
        public void AddAutomobil_ShouldReturnGeneratedID()
        {
            ExecuteInTransaction((repo, conn, transaction) =>
            {
                var auto = new CarBuilder().Build();

                repo.Add(auto, conn, transaction);
                var inserted = (Automobil)repo.Find(auto, auto.IdCondition, conn, transaction);
                Assert.NotNull(inserted);
                Assert.True(inserted.AutomobilID > 0);
                Assert.Equal("BG000ts", inserted.RegistarskiBroj);
                Assert.Equal("bmw", inserted.Marka);
                Assert.Equal("x13", inserted.Model);
                Assert.Equal(2023, inserted.Godiste);
                Assert.Equal(20000, inserted.Kilometraza);
                Assert.Equal(2, inserted.Klasa.KlasaID);
                Assert.Equal(StatusAutomobila.dostupan, inserted.Status);
            });
        }
        [Fact]
        public void DeleteAutomobil_ShouldReturnAffectedRows()
        {
            ExecuteInTransaction((repo, conn, transaction) =>
            {
                var auto = new CarBuilder().Build();
                repo.Add(auto, conn, transaction);
                int affectedRows = repo.Delete(auto, conn, transaction);
                Assert.True(affectedRows == 1);
            });
        }
        [Fact]
        public void DeleteAutomobil_ShouldThrowException()
        {
            ExecuteInTransaction((repo, conn, transaction) =>
            {
                var auto = new CarBuilder().Build();
                Assert.Throws<Exception>(() => repo.Delete(auto, conn, transaction));
            });
        }
        [Fact]
        public void FindAutomobil_ShouldReturnObjectIEntity()
        {
            ExecuteInTransaction((repo, conn, transaction) =>
            {
                var auto1 = new CarBuilder().Build();
                repo.Add(auto1, conn, transaction);
                var autoFound = repo.Find(auto1, auto1.IdCondition, conn, transaction);
                Automobil returned = (Automobil)repo.Find(auto1, auto1.IdCondition, conn, transaction);
                Assert.NotNull(returned);
                Assert.True(returned.AutomobilID > 0);
                Assert.Equal("BG000ts", returned.RegistarskiBroj);
                Assert.Equal("bmw", returned.Marka);
                Assert.Equal("x13", returned.Model);

               //ssert.Equal(2023, returned.Godiste);
                //sert.Equal(20000, returned.Kilometraza);
                Assert.Equal(2, returned.Klasa.KlasaID);
                Assert.Equal(StatusAutomobila.dostupan, returned.Status);
            });
        }

        [Fact]
        public void GetAllAutomobil_ShouldReturnListOfIEntity()
        {
            ExecuteInTransaction((repo, conn, transaction) =>
            {
                var auto1 = new CarBuilder().Build();
                var auto2 = new CarBuilder()
                                    .WithBrand("toyot")
                                    .WithCarClass(new KlasaAutomobila() { KlasaID = 1 })
                                    .WithModel("yaris")
                                    .WithRegistarski("bg000tx")
                                    .WithKilometraza(124789)
                                    .WithState(StatusAutomobila.dostupan)
                                    .WithYearProduction(2024).Build();
                repo.Add(auto1, conn, transaction);
                repo.Add(auto2, conn, transaction);
                var autoLista = repo.GetAll(auto1, conn, transaction);
                Assert.NotNull(autoLista);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID == auto1.AutomobilID);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID == auto2.AutomobilID);

            });
        }
        [Fact]
        public void GetAutomobils_ShouldReturnListOfIEntityFilteredByCondition()
        {
            ExecuteInTransaction((repo, conn, transaction) =>
            {
                var auto1 = new CarBuilder().Build();
                var auto2 = new CarBuilder()
                                    .WithBrand("toyot")
                                    .WithCarClass(new KlasaAutomobila() { KlasaID = 2 })
                                    .WithModel("yaris")
                                    .WithRegistarski("bg000tx")
                                 .WithKilometraza(200000)
                                    .WithState(StatusAutomobila.dostupan)
                                    .WithYearProduction(2024).Build();
                repo.Add(auto1, conn, transaction);
                repo.Add(auto2, conn, transaction);
                var autoLista = repo.GetAll(auto1, conn, transaction, "KlasaID=2");
                Assert.NotNull(autoLista);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID == auto1.AutomobilID);
                Assert.Contains(autoLista, x => ((Automobil)x).AutomobilID == auto2.AutomobilID);

            });
        }
        [Fact]
        public void UpdateAutomobil_ShouldChangeValues()
        {
            ExecuteInTransaction((repo, conn, transaction) =>
            {
                var auto1 = new CarBuilder().Build();
                repo.Add(auto1, conn, transaction);
                auto1.Marka = "suzuki";
                repo.Update(auto1, conn, transaction);
                Automobil updated = (Automobil)repo.Find(auto1, auto1.IdCondition, conn, transaction);
                Assert.Equal("suzuki", updated.Marka);

            });
        }
    }
}
