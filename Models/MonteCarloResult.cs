using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COEsWebAPI.Models
{
    public class MonteCarloResult
    {
        public double Premium { get; set; }
        public double Error { get; set; }
        public string TimeElapsed { get; set; }
    }
}
