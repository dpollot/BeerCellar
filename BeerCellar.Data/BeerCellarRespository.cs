using BeerCellar.Core;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCellar.Data
{
    public class BeerCellarRepository
    {
        #region properties/fields
        private static readonly string RepositoryKey = "BeerCellar";
        private static readonly string DatabaseName = "beerCellar";

        private MongoClient _Client = null;
        public MongoClient Client
        {
            get
            {
                if (null == _Client)
                {
                    string connString = ConfigurationManager.ConnectionStrings[BeerCellarRepository.RepositoryKey].ConnectionString;
                    _Client = new MongoClient(connString);
                }
                return _Client;
            }
        }
        #endregion

        #region public methods
        public IEnumerable<CellarEntry> GetCollection()
        {
            var server = Client.GetServer();
            var db = server.GetDatabase(BeerCellarRepository.DatabaseName);

            var beers = db.GetCollection<CellarEntry>("myBeers").FindAll().ToList();
            return beers;
        }
        #endregion
    }
}
