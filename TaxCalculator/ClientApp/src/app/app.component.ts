import { Component, OnInit } from '@angular/core';
import { TaxCalculatorService } from './services/tax-calculator.service';
import { SalaryTaxCalculationData } from './models/SalaryTaxCalculationData';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'taxCalculator';
  grossAnnualSalary: number = 0;
  taxCalcualtionData: SalaryTaxCalculationData = {} as SalaryTaxCalculationData;

  constructor(private taxCalculatorService: TaxCalculatorService) { }

  ngOnInit(): void {}

  onSubmit() {
    this.taxCalculatorService.getTax(this.grossAnnualSalary)
      .subscribe(response => 
          this.taxCalcualtionData = response
      );
  }
}
