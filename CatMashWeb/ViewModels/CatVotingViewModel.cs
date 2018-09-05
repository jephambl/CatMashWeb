using CatMashWeb.Business;
using System;
using System.Collections.Generic;

namespace CatMashWeb.ViewModels
{
    public class CatVotingViewModel
    {
        public CatCandidate CatCandidateLeft { get; set; }
        public CatCandidate CatCandidateRight { get; set; }
        public int CatIdx { get; set; }
    }
}