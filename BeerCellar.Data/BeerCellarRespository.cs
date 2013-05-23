using BeerCellar.Core;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
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
            var db = GetDatabase();

            var beers = db.GetCollection<CellarEntry>(BeerCellarDatabase.Collections.MyBeers).FindAll().ToList();
            return beers;
        }

        public void InsertEntry(CellarEntry entry)
        {
            var db = GetDatabase();
            db.GetCollection<CellarEntry>(BeerCellarDatabase.Collections.MyBeers).Insert<CellarEntry>(entry);
        }

        public void UpdateEntry(CellarEntry entry)
        {
            var db = GetDatabase();
            
            // I should be doing this by id
            var q = Query.And(Query<CellarEntry>.EQ(e => e.BeerName, entry.BeerName), Query<CellarEntry>.EQ(e => e.BreweryName, entry.BreweryName));
            var myBeers = db.GetCollection<CellarEntry>(BeerCellarDatabase.Collections.MyBeers);

            myBeers.Update(q, update: Update<CellarEntry>.Set(e => e.Count, BsonValue.Create(entry.Count)));
        }
        #endregion

        #region private methods
        private MongoDatabase GetDatabase()
        {
            var server = Client.GetServer();
            return server.GetDatabase(BeerCellarRepository.DatabaseName);
        }
        #endregion
    }

    public static class BeerCellarDatabase
    {
        public static readonly string Name = "beerCellar";
        public static class Collections
        {
            public static readonly string MyBeers = "myBeers";
        }
    }
}
