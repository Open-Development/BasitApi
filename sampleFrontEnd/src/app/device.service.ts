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
    return this.http.get<Light[]>(this.apiUrl + '/' + type);
  }
}
