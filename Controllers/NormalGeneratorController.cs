using COEsWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace COEsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class NormalGeneratorController : ControllerBase
    {
        private double _IA, _IM, _AM, _IQ, _IR, _spareNormal;
        private bool _spareNormalFlag;
        
        private double _seed { get; set; }

        public NormalGeneratorController()
        {
            this._IA = 16807;
            this._IM = 2147483647;
            this._AM = 1 / this._IM;
            this._IQ = 127773;
            this._IR = 2836;

            this._spareNormal = 0;
            this._spareNormalFlag = false;

            Random rnd = new Random();
            this._seed = Convert.ToInt32(rnd.NextDouble() * this._IM);
        }

        [HttpGet]
        public double GetNormalValue()
        {
            if (_spareNormalFlag)
            {
                _spareNormalFlag = false;
                return _spareNormal;
            }

            double u = 0, v = 0, W = 1;

            while (W >= 1)
            {
                u = 2 * GetRand0() - 1;
                v = 2 * GetRand0() - 1;

                W = u * u + v * v;
            }

            double C = Math.Sqrt(-2 * Math.Log(W) / W);

            _spareNormal = C * v;
            _spareNormalFlag = true;

            return C * u;

        }

        [HttpGet]
        public double GetRand0()
        {
            long k = Convert.ToInt32(_seed / _IQ);
            _seed = _IA * (_seed - k * _IQ) - _IR * k;

            if (_seed < 0)
                _seed += _IM;


            return _AM * _seed;
        }
    }
}
