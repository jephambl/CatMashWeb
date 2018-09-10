using CatMashWeb.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatMashWeb.Service
{
    public interface ICatService
    {
        List<CatCandidate> GetCatCandidates();

        bool UpdateCatScore(string catId);
    }
}
