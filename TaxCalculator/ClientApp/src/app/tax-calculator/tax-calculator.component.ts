import { Component } from '@angular/core';
import { TaxCalculatorService } from '../services/tax-calculator.service';
import { SalaryTaxCalculationData } from '../models/SalaryTaxCalculationData';
import { Observable, catchError, of } from 'rxjs';

@Component({
  selector: 'app-tax-calculator',
  templateUrl: './tax-calculator.component.html',
  styleUrls: ['./tax-calculator.component.css']
})
export class TaxCalculatorComponent {
  title = 'taxCalculator';
  grossAnnualSalary: number = 0;
  taxCalculationData$: Observable<SalaryTaxCalculationData> = undefined!;

  constructor(private taxCalculatorService: TaxCalculatorService) { }

  onSubmit() {
    this.taxCalculationData$ = this.taxCalculatorService.getTax(this.grossAnnualSalary)
      .pipe(
        catchError(error => {
          return of({} as SalaryTaxCalculationData);
        })
      );
  }
}
