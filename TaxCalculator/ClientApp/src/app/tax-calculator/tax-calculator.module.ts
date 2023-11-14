import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaxCalculatorComponent } from './tax-calculator.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    TaxCalculatorComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
  ],
  exports: [ TaxCalculatorComponent ]
})

export class TaxCalculatorModule { }
