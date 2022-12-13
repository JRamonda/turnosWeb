import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TypeDoc } from '../models/type-docs';
import { environment } from '../../environments/environment';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TypeDocsService {
  resourceUrl: string;
  constructor(private httpClient: HttpClient) {
    this.resourceUrl = environment.ConexionWebApiProxy + 'typeDocs/'
  }

  get() {
    return this.httpClient.get(this.resourceUrl);
  }

  getById(id: number) {
    return this.httpClient.get(this.resourceUrl + id);
  }

  post(obj: TypeDoc) {
    return this.httpClient.post(this.resourceUrl, obj);
  }

  put(id: number, obj: TypeDoc) {
    return this.httpClient.put(this.resourceUrl + id, obj);
  }

  delete(id: number) {
    return this.httpClient.delete(this.resourceUrl + id);
  }
}
