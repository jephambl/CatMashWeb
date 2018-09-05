using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashWeb.Business
{
    public class Cat
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string ImgUrl { get; set; }
    }

    public class CatCandidate : Cat
    {
        public int Score { get; set; }
    }
}
