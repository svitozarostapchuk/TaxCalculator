import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TaxCalculatorService } from './tax-calculator.service';
import { AppConfigService } from '../services/app-config-service.service';
import { SalaryTaxCalculationData } from '../models/SalaryTaxCalculationData';

describe('TaxCalculatorService', () => {
  let service: TaxCalculatorService;
  let httpMock: HttpTestingController;
  let configService: AppConfigService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [TaxCalculatorService, AppConfigService]
    });

    service = TestBed.inject(TaxCalculatorService);
    httpMock = TestBed.inject(HttpTestingController);
    configService = TestBed.inject(AppConfigService);
  });

  afterEach(() => {
    httpMock.verify(); 
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return expected tax data (HttpClient called once)', () => {
    const expectedTaxData: SalaryTaxCalculationData = {
      grossAnnualSalary: 10000,
      grossMonthlySalary: 20000,
      netAnnualSalary: 30000,
      netMonthlySalary: 40000,
      annualTaxPaid: 50000,
      monthlyTaxPaid: 60000,
    };

    const grossAnnualSalary = 10000;
    const url = configService.getBaseUrl() + grossAnnualSalary;

    service.getTax(grossAnnualSalary).subscribe({
      next: taxData => expect(taxData).toEqual(expectedTaxData),
      error: err => { throw new Error(`Test failed due to ${err}`); }
    });

    const req = httpMock.expectOne(url);
    expect(req.request.method).toEqual('GET');
    req.flush(expectedTaxData);
  });
});
