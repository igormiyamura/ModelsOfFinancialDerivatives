using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COEsWebAPI.Models
{
    public class MonteCarloData
    {
        public double S { get; set; }
        public double r { get; set; }
        public double sigma { get; set; }
        public double X { get; set; }
        public double T { get; set; }
        public double N { get; set; }
        public double M { get; set; }

        public MonteCarloData(double S, double r, double sigma, double X, double T, double N, double M)
        {
            this.S = S;
            this.r = r;
            this.sigma = sigma;
            this.X = X;
            this.T = T;
            this.N = N;
            this.M = M;
        }
    }
}
