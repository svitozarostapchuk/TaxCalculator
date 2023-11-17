import { ComponentFixture, TestBed } from '@angular/core/testing';
import { TaxCalculatorComponent } from './tax-calculator.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { TaxCalculatorService } from '../services/tax-calculator.service';
import { FormsModule } from '@angular/forms';
import { of } from 'rxjs';
import { SalaryTaxCalculationData } from '../models/SalaryTaxCalculationData';

describe('TaxCalculatorComponent', () => {
  let component: TaxCalculatorComponent;
  let fixture: ComponentFixture<TaxCalculatorComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientTestingModule,
        FormsModule,
      ], 
      declarations: [TaxCalculatorComponent],
      providers: [TaxCalculatorService]
    });
    fixture = TestBed.createComponent(TaxCalculatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render title', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('h1')?.textContent).toContain(component.title);
  });

  it('should render form', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('form')).toBeTruthy();
  });

  it('should render annualGrossSalary input', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('input[name="annualGrossSalary"]')).toBeTruthy();
  });

  it('should render submit button', () => {
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('button[type="submit"]')).toBeTruthy();
  });

  it('should display loading template when taxCalculationData$ is null', () => {
    component.taxCalculationData$ = of(null as unknown as SalaryTaxCalculationData);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('p')?.textContent).toContain('Loading...');
  });
});
