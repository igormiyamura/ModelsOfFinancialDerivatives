using COEsWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COEsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ResultAccumulatorController : ControllerBase
    {
        private double _accValues, _accSquares, _M, _discount;

        public ResultAccumulatorController(MonteCarloData mcData)
        {
            this._accValues = 0;
            this._accSquares = 0;
            this._M = 0;
            this._discount = Math.Exp(-mcData.r * mcData.T);
        }
        
        [ApiExplorerSettings(IgnoreApi = true)]
        public void Update(double newValue)
        {
            _accValues += newValue;
            _accSquares += newValue * newValue;
            _M += 1;
        }

        [HttpGet]
        public double GetCValue()
        {
            return _discount * _accValues / _M;
        }

        [HttpGet]
        public double GetSe()
        {
            double radix = _accSquares - _accValues * _accValues / _M;

            if (radix < 0)
                throw new Exception("Radix can't be negative.");

            return _discount * Math.Sqrt(radix) / _M;
        }

    }
}
