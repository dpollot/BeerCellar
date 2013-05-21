using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCellar.Core
{
    public class CellarEntry
    {
        #region properties/fields
        [JsonProperty("_id")]
        [BsonElement("_id")]
        public ObjectId Id { get; set; }

        [JsonProperty("breweryName")]
        [BsonElement("breweryName")]
        public string BreweryName { get; set; }

        [JsonProperty("beerName")]
        [BsonElement("beerName")]
        public string BeerName { get; set; }

        [JsonProperty("year")]
        [BsonElement("year")]
        public int Year { get; set; }

        [JsonProperty("count")]
        [BsonElement("count")]
        public int Count { get; set; }
        #endregion
    }
}
