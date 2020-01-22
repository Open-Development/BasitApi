import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Light } from './Light';

@Injectable({
  providedIn: 'root'
})
export class DeviceService {

  private apiUrl: string;

  constructor(private http: HttpClient) {
    this.apiUrl = 'http://localhost:5000/device';
  }

  public get(type: string): Observable<Light[]> {
    const url = this.apiUrl + '/' + type;
    const reqHeaders = this.getHeaders();

    return this.http.get<Light[]>(url);
  }

  private getHeaders(): any {
    return {
      // 'Access-Control-Allow-Origin': '*',
      'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, PATCH, DELETE',
      'Access-Control-Allow-Headers': 'X-Requested-With,content-type'
    };
  }
}
