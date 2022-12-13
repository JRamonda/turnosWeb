import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Client } from '../models/client';
import { environment } from '../../environments/environment';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ClientsService {
  resourceUrl: string;
  constructor(private httpClient: HttpClient) {
    this.resourceUrl = environment.ConexionWebApiProxy + 'clients/'
  }

  get(num_doc: any, id_type_doc: any) {
    let params = new HttpParams();
    if (num_doc != null) {
      params = params.append('num_doc', num_doc);
    }
    if (id_type_doc != null) {
      params = params.append('id_type_doc', id_type_doc);
    }
    return this.httpClient.get(this.resourceUrl, { params: params });
  }

  getById(id: number) {
    return this.httpClient.get(this.resourceUrl + id);
  }

  post(obj: Client) {
    return this.httpClient.post(this.resourceUrl, obj);
  }

  put(id: number, obj: Client) {
    return this.httpClient.put(this.resourceUrl + id, obj);
  }

  delete(id: number) {
    return this.httpClient.delete(this.resourceUrl + id);
  }
}
