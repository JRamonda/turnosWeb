import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { ClientXTurnXUserXService } from '../models/clientXTurnXUserXService';
import { environment } from '../../environments/environment';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class ClientsXTurnsXUsersService {
  resourceUrl: string;
  constructor(private httpClient: HttpClient) {
    this.resourceUrl = environment.ConexionWebApiProxy + 'clientXTurnXUserXService/'
  }

  get(nameId?: string, idClient?: number | undefined, idTurn?: number | undefined, idUser?: number | undefined) {
    let params = new HttpParams();
    if (idClient != undefined && nameId?.includes('client')) 
      params = params.append('idClient', idClient);
    if (idTurn != undefined && nameId?.includes('turn')) 
      params = params.append('idTurn', idTurn);
    if (idUser != undefined && nameId?.includes('user')) 
      params = params.append('idUser', idUser);

    return this.httpClient.get(this.resourceUrl, { params: params });
  }

  getById(idClient: number, idTurn: number, idUser: number, idService: any) {
    return this.httpClient.get(this.resourceUrl + idClient + '-' + idTurn + '-' + idUser + '-' + idService);
  }

  post(obj: ClientXTurnXUserXService) {
    return this.httpClient.post(this.resourceUrl, obj);
  }

  put(idClient: number, idTurn: number, idUser: number, idService: any, obj: ClientXTurnXUserXService) {
    return this.httpClient.put(this.resourceUrl + idClient + '-' + idTurn + '-' + idUser + '-' + idService, obj);
  }

  delete(idClient: number, idTurn: number, idUser: number, idService: any) {
    return this.httpClient.delete(this.resourceUrl + idClient + '-' + idTurn + '-' + idUser + '-' + idService);
  }
}
