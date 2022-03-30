using COEsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace COEsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PathGeneratorController : ControllerBase
    {
        #region .: Construtor :.
        private MonteCarloData _mcData;
        private NormalGeneratorController _normGen;
        private PathGeneratorData _pathData;

        public PathGeneratorController(MonteCarloData mcData)
        {
            this._mcData = mcData;
            this._normGen = new NormalGeneratorController();
            this._pathData = new PathGeneratorData(_mcData);
        }
        #endregion

        #region .: Private Methods :.
        private double GetNextS(double S)
        {
            return S * Math.Exp(_pathData.drift + _pathData.sRootT * _normGen.GetNormalValue());
        }
        #endregion

        [HttpGet]
        public double GetNewFinalS()
        {
            double pathS = _pathData.S;

            for (int i = 0; i < _pathData.N; i++)
            {
                pathS = GetNextS(pathS);
            }

            return pathS;
        }

        
    }
}
