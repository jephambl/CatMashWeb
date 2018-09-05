using CatMashWeb.Business;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashWeb.Service
{
    public class CatsService
    {
        public List<CatCandidate> GetCatCandidates()
        {
            var cats = LoadCats();

            var catsScores = new List<CatCandidate>();
            foreach (var cat in cats)
            {
                var catsScore = new CatCandidate
                {
                    Id = cat.Id,
                    ImgUrl = cat.ImgUrl,
                    Score = 0
                };

                catsScores.Add(catsScore);
            }

            return catsScores;
        }

        private List<Cat> LoadCats()
        {
            var catsData = @"
             [
                {
                    ""url"": ""http://24.media.tumblr.com/tumblr_m82woaL5AD1rro1o5o1_1280.jpg"",
                    ""id"": ""MTgwODA3MA""
                },
                {
                    ""url"": ""http://24.media.tumblr.com/tumblr_m29a9d62C81r2rj8po1_500.jpg"",
                    ""id"": ""tt""
                },
                {
                    ""url"": ""http://25.media.tumblr.com/tumblr_m4bgd9OXmw1qioo2oo1_500.jpg"",
                    ""id"": ""bmp""
                },
                {
                    ""url"": ""http://24.media.tumblr.com/tumblr_lzxok2e2kX1qgjltdo1_1280.jpg"",
                    ""id"": ""c8a""
                },
                {
                    ""url"": ""http://25.media.tumblr.com/tumblr_m33r7lpy361qzi9p6o1_500.jpg"",
                    ""id"": ""3kj""
                }
            ]";

            var cats = JsonConvert.DeserializeObject<List<Cat>>(catsData);
            return cats;
        }
    }
}
