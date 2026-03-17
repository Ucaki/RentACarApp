using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Tests.ClassBuilder
{
    public class CarBuilder
    {
        private Automobil _car;
        public CarBuilder() { 
            _car = new Automobil() 
           { RegistarskiBroj = "BG000ts", Marka = "bmw", Model = "x13", Kilometraza=20000, Godiste = 2023, Klasa = new KlasaAutomobila() { KlasaID = 2 }, Status = StatusAutomobila.dostupan };
        }
        public CarBuilder WithRegistarski(string registration) {
            _car.RegistarskiBroj = registration;
            return this;
        }
        public CarBuilder WithKilometraza(int kilometraza) {
            _car.Kilometraza = kilometraza;
            return this;
        }
        public CarBuilder WithBrand(string brand)
        {
            _car.Marka = brand;
            return this;
        }
        public CarBuilder WithModel(string model)
        {
            _car.Model = model;
            return this;
        }
        public CarBuilder WithYearProduction(int year)
        {
            _car.Godiste = year;
            return this;
        }
        public CarBuilder WithCarClass(KlasaAutomobila k)
        {
            _car.Klasa = k;
            return this;
        }
        public CarBuilder WithState(StatusAutomobila state)
        {
            _car.Status = state;
            return this;
        }
        public Automobil Build() {
            return _car;
        }
    }
}
