using BeerCellar.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BeerCellar.Service.Controllers
{
    public class BeerCellarController : ApiController
    {
        #region actions
        /// <summary>
        /// GET api/beercellar
        /// Returns the collection of cellar entries
        /// </summary>
        /// <returns></returns>
        public IEnumerable<CellarEntry> Get()
        {
            var repo = new BeerCellar.Data.BeerCellarRepository();
            var collection = repo.GetCollection();

            return collection;
        }

        /// <summary>
        /// GET api/beercellar/5
        /// Returns the entry with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string Get(int id)
        {
            throw new NotImplementedException("I ain't been implemented yo.  Gatorade me bitch!");
        }

        /// <summary>
        /// POST api/beercellar
        /// Inserts the given entry
        /// </summary>
        /// <param name="value">the json representation of a CellarEntry</param>
        public void Post([FromBody]CellarEntry entry)
        {
            var repo = new BeerCellar.Data.BeerCellarRepository();
            repo.InsertEntry(entry);
        }

        /// <summary>
        /// PUT api/beercellar/5
        /// updates the entry with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        public void Put(string id, [FromBody]CellarEntry entry)
        {
            var repo = new BeerCellar.Data.BeerCellarRepository();
            repo.UpdateEntry(entry);
        }

        /// <summary>
        /// DELETE api/beercellar/5
        /// deletes the entry with the given id
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            throw new NotImplementedException("I ain't been implemented yo.  Gatorade me bitch!");
        }
        #endregion
    }
}
