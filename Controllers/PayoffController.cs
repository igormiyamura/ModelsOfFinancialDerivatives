using Microsoft.AspNetCore.Mvc;
using System;

namespace COEsWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PayoffController : ControllerBase
    {
        [HttpGet]
        public double GetPayoff(double S, double X)
        {
            return Math.Max(0, S - X);
        }
    }
}
