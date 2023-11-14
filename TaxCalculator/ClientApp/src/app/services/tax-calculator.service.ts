import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SalaryTaxCalculationData } from '../models/SalaryTaxCalculationData';
import { AppConfigService } from './app-config-service.service';

@Injectable({
  providedIn: 'root'
})

export class TaxCalculatorService {

  baseUrl = this.config.getBaseUrl();

  constructor(private http: HttpClient, private config: AppConfigService) { }
  
  getTax(income: number): Observable<SalaryTaxCalculationData> {
    return this.http.get<SalaryTaxCalculationData>(this.baseUrl + income);
  } 
}
