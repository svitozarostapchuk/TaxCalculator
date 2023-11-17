import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, Subject, map, tap } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AppConfigService {
  private config: any;
  private configLoaded = new Subject<void>();

  constructor(private http: HttpClient) {
    this.loadConfig().subscribe();
  }

  public loadConfig(): Observable<any> {
    return this.http.get('/assets/config.json').pipe(
      tap(config => {
        this.config = config;
        this.configLoaded.next();
      })
    );
  }

  getBaseUrl(): Observable<string> {
    return this.configLoaded.pipe(
      map(() => this.config.baseUrl)
    );
  }
}
