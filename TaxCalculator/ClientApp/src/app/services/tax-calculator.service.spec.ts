import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TaxCalculatorService } from './tax-calculator.service';
import { AppConfigService } from './app-config.service';
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
    httpMock.expectOne('/assets/config.json');
    expect(service).toBeTruthy();
  });
});
