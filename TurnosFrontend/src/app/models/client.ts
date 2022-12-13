import { TypeDoc } from "./type-docs";

export interface Client {
  id: number;
  numDoc: string;
  idTypeDoc: number;
  firstName: string;
  lastName: string;
  numPhone: string;
  typeDoc: TypeDoc;
}