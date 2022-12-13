import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Service } from '../models/service';
import { environment } from '../../environments/environment';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  resourceUrl: string;
  constructor(private httpClient: HttpClient) {
    this.resourceUrl = environment.ConexionWebApiProxy + 'services/'
    }
  
    // get():Observable<Service[]> {
    //   return this.httpClient.get<Service[]>(this.resourceUrl);
    // }
    get() {
      return this.httpClient.get(this.resourceUrl);
    }

    getById(id: number) {
      return this.httpClient.get(this.resourceUrl + id);
    }
  
    post(obj: Service) {
      return this.httpClient.post(this.resourceUrl, obj);
    }
  
    put(id: number, obj: Service) {
      return this.httpClient.put(this.resourceUrl + id, obj);
    }
  
    delete(id: number) {
      return this.httpClient.delete(this.resourceUrl + id);
    }
}