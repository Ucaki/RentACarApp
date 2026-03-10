using Common.Domain;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemOperations;
using SystemOperations.AutomobilSO;
using SystemOperations.CarClassSO;

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
    }
}
