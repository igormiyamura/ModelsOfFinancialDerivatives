import { Component, OnInit } from '@angular/core';
import { BlackScholesService } from './black-scholes.service';
import { FormBuilder, NgForm } from '@angular/forms';

@Component({
  selector: 'app-black-scholes',
  templateUrl: './black-scholes.component.html',
  styleUrls: ['./black-scholes.component.css']
})
export class BlackScholesComponent implements OnInit {
  title = 'Black Scholes';
  resultBlackScholes: number = 0;

  constructor(
    private bsService: BlackScholesService) { } 
  
  callputflag: string = 'c';
  price: number = 100;
  strike: number = 100;
  time: number = 1;
  rate: number = 0.05;
  volatility: number = 0.2;

  //CallPutFlag: string, S: number, K: number, T: number, r: number, v: number
  onCalculateBlackScholes() {
    
    this.bsService.getBlackScholes(this.callputflag, this.price, this.strike, this.time, this.rate, this.volatility)
    .subscribe(
      (successReponse) => {
        this.resultBlackScholes = successReponse;
        console.log(successReponse.valueOf());
      },
      (errorResponse) => {
        console.log(errorResponse);
      }
    );
  }

  ngOnInit(): void {
    this.onCalculateBlackScholes();
  }

}
