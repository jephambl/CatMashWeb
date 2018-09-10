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
        private readonly ICatService _catService;

        public CatMashController(ICatService catService)
        {
            _catService = catService;
        }

        [HttpPost]
        public IActionResult UpdateCatScore(CatVotingViewModel catVotingViewModel)
        {
            var catCandidates = _catService.UpdateCatScore(catVotingViewModel.CatIdSelected);

            //return RedirectToAction("CatVoting", new { catVotingViewModel.IdxCat });
            return RedirectToAction("CatVoting");
        }

        public IActionResult CatVoting(int idxCat = 0)
        {
            var catCandidates = _catService.GetCatCandidates();

            var catVotingViewModel = new CatVotingViewModel();

            // a mettre dans le service
            if (idxCat == 0)
            {
                var random = new Random();
                idxCat = random.Next(0, 97);
            }

            // idem : creer 1 fct GetCat(idx) dans le service
            catVotingViewModel.CatCandidateLeft = (catCandidates.ToArray().ElementAt(idxCat));
            idxCat = idxCat + 1;
            catVotingViewModel.CatCandidateRight = (catCandidates.ToArray().ElementAt(idxCat));
            catVotingViewModel.IdxCat = idxCat;

            return View(catVotingViewModel);
        }

        public IActionResult CatCandidatesRanking()
        {
            var catCandidates = _catService.GetCatCandidates();

            //mock
            foreach (var catCandidate in catCandidates)
            {
                var random = new Random();
                catCandidate.Score = random.Next(0, 80);
            }

            var catCandidatesRankingViewModel = new CatCandidatesRankingViewModel()
            {
                CatCandidates = catCandidates.OrderByDescending(c => c.Score).ToList()
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
