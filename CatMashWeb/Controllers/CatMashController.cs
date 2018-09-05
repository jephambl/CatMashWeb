using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CatMashWeb.Models;
using CatMashWeb.ViewModels;
using Newtonsoft.Json;
using CatMashWeb.Business;
using System.Net;
using CatMashWeb.Service;

namespace CatMashWeb.Controllers
{
    public class CatMashController : Controller
    {
        public IActionResult CatVoting(int catIdx = 0)
        {
            var catsService = new CatsService();
            var catCandidates = catsService.GetCatCandidates();

            var catVotingViewModel = new CatVotingViewModel
            {
                CatCandidateLeft = (catCandidates.ToArray().ElementAt(catIdx++)),
                CatCandidateRight = (catCandidates.ToArray().ElementAt(catIdx)),
                CatIdx = catIdx
            };

            return View(catVotingViewModel);
        }

        public IActionResult CatCandidatesRanking()
        //public IActionResult CatScoreResult()
        {
            var catsService = new CatsService();
            var catsScores = catsService.GetCatCandidates();

            var catCandidatesRankingViewModel = new CatCandidatesRankingViewModel()
            {
                CatCandidates = catsScores
            };
            return View(catCandidatesRankingViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
