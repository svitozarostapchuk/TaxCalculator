import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SalaryTaxCalculationData } from '../models/SalaryTaxCalculationData';
import { AppConfigService } from './app-config.service';

@Injectable({
  providedIn: 'root'
})

export class TaxCalculatorService {
  baseUrl!: string;

  constructor(private httpClient: HttpClient, private appConfigService: AppConfigService) {
    this.appConfigService.getBaseUrl().subscribe(
      (baseUrl) => {
        this.baseUrl = baseUrl;
      }
    );
  }

  getTax(income: number): Observable<SalaryTaxCalculationData> {
    return this.httpClient.get<SalaryTaxCalculationData>(this.baseUrl + income);
  } 
}
