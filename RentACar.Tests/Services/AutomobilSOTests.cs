using Common.Domain;
using Moq;
using RentACar.Tests.ClassBuilder;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
using SystemOperations.AutomobilSO;
using Xunit;

namespace RentACar.Tests.Services
{
    public class AutomobilSOTests
    {
        private readonly Mock<IRepository<IEntity>> _repoMock;
        private readonly Mock<IConnectionFactory> _factoryMock;
        private readonly BaseSO _so;
        public AutomobilSOTests() {
            _repoMock = new Mock<IRepository<IEntity>>();      
            _factoryMock = new Mock<IConnectionFactory>();

            var _transactionMock = new Mock<IDbTransaction>();
            _transactionMock.Setup(t => t.Commit());
            _transactionMock.Setup(t => t.Rollback());

            var _connectionMock = new Mock<IDbConnection>();
            _connectionMock.Setup(c => c.Open());
            _connectionMock.Setup(c => c.BeginTransaction())
                .Returns(_transactionMock.Object);

            _factoryMock
                .Setup(f => f.CreateConnection())
                .Returns(_connectionMock.Object);

            _so = new ZapamtiVoziloSO(_repoMock.Object, _factoryMock.Object);
        }


        //registration tests

        [Fact]
        public void Should_Throw_When_Registration_Is_Null() 
        {
            var car = new CarBuilder().WithRegistarski("").Build();
            Assert.Throws<Exception>(()=> _so.ExecuteTemplate(car));
        }
        [Fact]
        public void Should_Throw_When_Registration_Is_Empty() 
        {
            var car = new CarBuilder().WithRegistarski(null).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }
        [Fact]
        public void Should_Throw_When_Registration_Is_Aready_Exists() 
        {
            var car = new CarBuilder().Build();

            _repoMock.Setup(r => r.Find(It.IsAny<Automobil>(), $"RegistarskiBroj= '{car.RegistarskiBroj}'",
               It.IsAny<IDbConnection>(),
               It.IsAny<IDbTransaction>())).Returns(car);

            Assert.Throws<Exception>(()=> _so.ExecuteTemplate(car));
        }


        //brand tests

        [Fact]
        public void Should_Throw_When_Brand_Is_Null()
        {
            var car = new CarBuilder().WithBrand("").Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }
        [Fact]
        public void Should_Throw_When_Brand_Is_Empty()
        {
            var car = new CarBuilder().WithBrand(null).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }


        //model tests

        [Fact]
        public void Should_Throw_When_Model_Is_Null()
        {
            var car = new CarBuilder().WithModel("").Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }
        [Fact]
        public void Should_Throw_When_Model_Is_Empty()
        {
            var car = new CarBuilder().WithModel(null).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }


        //year test

        [Fact]
        public void Should_Throw_When_Year_Is_Less_Then_1900()
        {
            var car = new CarBuilder().WithYearProduction(1800).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }
        [Fact]
        public void Should_Throw_When_Year_Is_Greater_Then_Current()
        {
            var car = new CarBuilder().WithYearProduction(2100).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }

        //CarClass test

        [Fact]
        public void Should_Throw_When_CarClass_Is_Null()
        {
            var car = new CarBuilder().WithCarClass(null).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }
        [Fact]
        public void Should_Throw_When_CarClassID_Is_Equal_0()
        {
            var car = new CarBuilder().WithCarClass(new KlasaAutomobila()).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }

        //State field test

        [Fact]
        public void Should_Throw_When_State_Is_invalid()
        {
            var car = new CarBuilder().WithState((StatusAutomobila)999).Build();
            Assert.Throws<Exception>(() => _so.ExecuteTemplate(car));
        }

        //Valid input case test
        [Fact]
        public void Should_Insert_Car_When_Data_Is_Valid() {
            var car = new CarBuilder().Build();
            _repoMock
                .Setup(r => r.Find(It.IsAny<IEntity>(), $"{car.IdCondition}", It.IsAny<IDbConnection>(), It.IsAny<IDbTransaction>()))
                .Returns((IEntity)null);
           
            _repoMock
                .Setup(r=> r.Add(It.IsAny<IEntity>(), It.IsAny<IDbConnection>(), It.IsAny<IDbTransaction>()))
                .Callback<IEntity,IDbConnection, IDbTransaction>((entity,conn,trans) => {
                    car = (Automobil)entity;
                    car.AutomobilID = 10;
                });

            _so.ExecuteTemplate(car);
            _repoMock
                .Verify(r => r.Add(car, It.IsAny<IDbConnection>(), It.IsAny<IDbTransaction>()),
                Times.Once);

            Assert.True(car.AutomobilID > 0);
        }
        

    }
}
