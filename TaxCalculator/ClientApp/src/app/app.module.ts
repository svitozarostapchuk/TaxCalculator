import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_INITIALIZER } from '@angular/core';
import { AppConfigService } from '../../src/app/services/app-config-service.service';
import { TaxCalculatorModule } from './tax-calculator/tax-calculator.module';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    TaxCalculatorModule,
  ],
  providers: [
    {
      provide: APP_INITIALIZER,
      useFactory: (config: AppConfigService) => () => config.loadConfig(),
      deps: [AppConfigService],
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})

export class AppModule { }
