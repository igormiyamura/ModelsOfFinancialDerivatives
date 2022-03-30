import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BlackScholesComponent } from './black-scholes/black-scholes.component';
import { MonteCarloComponent } from './monte-carlo/monte-carlo.component';

const routes: Routes = [
  { path:'monte-carlo', component: MonteCarloComponent },
  { path:'black-scholes', component: BlackScholesComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
