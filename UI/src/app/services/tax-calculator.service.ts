import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { SalaryTaxCalculationData } from '../models/SalaryTaxCalculationData';

@Injectable({
  providedIn: 'root'
})
export class TaxCalculatorService {

  baseUrl = "https://localhost:7208/api/tax/";

  constructor(private http: HttpClient) { }
  
  getTax(income: number): Observable<SalaryTaxCalculationData> {
    return this.http.get<SalaryTaxCalculationData>(this.baseUrl + income);
  } 
}
