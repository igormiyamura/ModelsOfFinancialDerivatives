import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BlackScholesService {

  private baseApiUrl = 'https://localhost:44381';

  constructor(private httpClient: HttpClient) { }

  getBlackScholes(CallPutFlag: string, S: number, X: number, T: number, r: number, v: number): Observable<number> {
    return this.httpClient.get<number>(this.baseApiUrl + '/api/BlackScholes/GetBlackScholes?CallPutFlag=' + CallPutFlag + '&S=' + S + '&X=' + X + '&T=' + T + '&r=' + r + '&v=' + v + '')
  }
}
