using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using COEsWebAPI.Services;
using COEsWebAPI.Models;

namespace COEsWebAPI.Controllers
{
	[ApiController]
    [Route("api/[controller]/[action]")]
    public class MonteCarloController : ControllerBase
    {
        [HttpGet]
		public MonteCarloResult GetMonteCarlo(double S, double r, double sigma, double X, double T, double N, double M)
        {
            try
            {
                var timer = new Stopwatch(); // Instancia object Stopwatch
                timer.Start();

                MonteCarloData mcData = new MonteCarloData(S, r, sigma, X, T, N, M); // Instancia object MonteCarloData (Data-In)
                MonteCarloResult mcResult = new MonteCarloResult(); // Instancia object MonteCarloResult (Data-Out)

                PayoffController payoff = new PayoffController(); // Instancia object PayoffController
                PathGeneratorController pathGen = new PathGeneratorController(mcData); // Instancia object PathGeneratorController

                ResultAccumulatorController resultAcc = new ResultAccumulatorController(mcData); // Instancia object ResultAccumulatorController

                double path_S, valorPayoff;

                for (int i = 0; i < M; i++)
                {
                    if (i % 10000 == 0)
                            System.Console.WriteLine($"{DateTime.Now}: Simulation Number [{i}]");

                    path_S = S;
                    for (int j = 0; j < N; j++)
                    {
                        path_S = pathGen.GetNewFinalS();
                    }

                    valorPayoff = payoff.GetPayoff(path_S, X);
                    resultAcc.Update(valorPayoff);
                }

                mcResult.Premium = resultAcc.GetCValue();
                mcResult.Error = resultAcc.GetSe();

                TimeSpan timeTaken = timer.Elapsed;

                timer.Stop();
                mcResult.TimeElapsed = timeTaken.ToString(@"m\:ss\.fff");

                return mcResult;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine($"Erro: {ex.Message}");
                throw;
            }
            
        }
		
	}
}
