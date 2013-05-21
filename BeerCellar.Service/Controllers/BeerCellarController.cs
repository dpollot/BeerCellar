using BeerCellar.Core;
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
        // GET api/beercellar
        public IEnumerable<CellarEntry> Get()
        {
            var repo = new BeerCellar.Data.BeerCellarRepository();
            var collection = repo.GetCollection();

            return collection;
        }

        // GET api/beercellar/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/beercellar
        public void Post([FromBody]string value)
        {
        }

        // PUT api/beercellar/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/beercellar/5
        public void Delete(int id)
        {
        }
        #endregion
    }
}
