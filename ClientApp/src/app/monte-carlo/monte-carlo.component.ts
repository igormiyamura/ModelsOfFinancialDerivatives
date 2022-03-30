import { Component, OnInit } from '@angular/core';
import { MonteCarloService } from './monte-carlo.service';

import { Observable } from 'rxjs';

@Component({
  selector: 'app-monte-carlo',
  templateUrl: './monte-carlo.component.html',
  styleUrls: ['./monte-carlo.component.css']
})
export class MonteCarloComponent implements OnInit {
  title = 'Monte Carlo';
  loading: boolean = false;

  S: number = 100;
  r: number = 0.05;
  sigma: number = 0.2;
  X: number = 100;
  T: number = 1;
  N: number = 100;
  M: number = 50000;
  
  c: number = 0;
  se: number = 0;
  run_time: number = 0;

  public showOverlay = true;
  
  constructor(
    private bsService: MonteCarloService
  ) { 
    
  }

  onCalculateMonteCarlo() {
    this.loading = true;

    this.bsService.getMonteCarlo(this.S, this.r, this.sigma, this.X, this.T, this.N, this.M)
      .subscribe(
        (successReponse) => {
          this.loading = false;
          
          this.c = successReponse.valueOf().premium;
          this.se = successReponse.valueOf().error;
          this.run_time = successReponse.valueOf().timeElapsed;

          console.log(successReponse.valueOf());
        },
        (errorResponse) => {
          console.log(errorResponse);
        }
      );

      
  }

  ngOnInit(): void {
  }
  

}
