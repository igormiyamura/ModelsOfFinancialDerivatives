import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MonteCarloService {

  private baseApiUrl = 'https://localhost:44381';

  constructor(private httpClient: HttpClient) { }

  getMonteCarlo(S: number, r: number, sigma: number, X: number, T: number, N: number, M: number): Observable<any> {
    return this.httpClient.get<any>(this.baseApiUrl + 
      '/api/MonteCarlo/GetMonteCarlo?S=' + S + '&r=' + r + '&sigma=' + sigma + '&X=' + X + '&T=' + T + '&N=' + N + '' + '&M=' + M + '')
  }
  
}
