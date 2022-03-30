using System;

namespace COEsWebAPI.Models
{
    public class PathGeneratorData
    {
        public MonteCarloData mcData { get; set; }

        public double S { get; set; }
        public double N { get; set; }
        public double dt { get; set; }
        public double drift { get; set; }
        public double sRootT { get; set; }

        public PathGeneratorData(MonteCarloData data)
        {
            this.mcData = data;
            this.S = data.S;
            this.N = data.N;
            this.dt = data.T / data.N;
            this.drift = (data.r - 0.5 * data.sigma * data.sigma) * this.dt;
            this.sRootT = data.sigma * Math.Sqrt(this.dt);
        }
    }
}
