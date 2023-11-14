import { Component, OnInit } from '@angular/core';
import { TaxCalculatorService } from './services/tax-calculator.service';
import { SalaryTaxCalculationData } from './models/SalaryTaxCalculationData';
import { Observable, catchError, of } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  title = 'taxCalculator';
  grossAnnualSalary: number = 0;
  taxCalculationData$: Observable<SalaryTaxCalculationData> = undefined!;

  constructor(private taxCalculatorService: TaxCalculatorService) { }

  ngOnInit(): void {}

  onSubmit() {
    this.taxCalculationData$ = this.taxCalculatorService.getTax(this.grossAnnualSalary)
      .pipe(
        catchError(error => {
          return of({} as SalaryTaxCalculationData);
        })
      );
  }
}
