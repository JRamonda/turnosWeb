import { Injectable } from '@angular/core';
import {
  HttpClient,
  HttpHeaders,
  HttpErrorResponse,
  HttpParams,
} from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Turn } from '../models/turn';

@Injectable({
  providedIn: 'root'
})
export class TurnsService {
  resourceUrl: string;
  constructor(private httpClient: HttpClient) {
    this.resourceUrl = environment.ConexionWebApiProxy + 'turns/'
  }

  get() {
    return this.httpClient.get(this.resourceUrl);
  }

  getById(id: number) {
    return this.httpClient.get(this.resourceUrl + id);
  }

  post(obj: Turn) {
    return this.httpClient.post(this.resourceUrl, obj);
  }

  put(id: number, obj: Turn) {
    return this.httpClient.put(this.resourceUrl + id, obj);
  }

  delete(id: number) {
    return this.httpClient.delete(this.resourceUrl + id);
  }
}
