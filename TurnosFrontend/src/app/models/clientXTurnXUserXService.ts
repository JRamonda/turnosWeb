import { Client } from "./client";
import { Turn } from "./turn";
import { User } from "./user";
import { Service } from "./service";

export interface ClientXTurnXUserXService {
  idClient: number;
  idTurn: number;
  idUser: number;
  idService: number;
  client: Client;
  turn: Turn;
  user: User;
  service: Service;
}