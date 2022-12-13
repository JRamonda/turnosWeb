import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TypeDoc } from '../../models/type-docs';
import { Turn } from '../../models/turn';
import { TypeDocsService } from '../../services/type-docs.service';
import { ModalDialogService } from '../../services/modal-dialog.service';
import { TurnsService } from '../../services/turns.service';
import { ClientsService } from '../../services/clients.service';
import { Client } from '../../models/client';
import { ClientsXTurnsXUsersService } from '../../services/clients-xturns-xusers.service';
import { ClientXTurnXUserXService } from '../../models/clientXTurnXUserXService';
import { Service } from '../../models/service';

@Component({
  selector: 'app-my-turn',
  templateUrl: './my-turn.component.html',
  styleUrls: ['./my-turn.component.css']
})

export class MyTurnComponent implements OnInit {
  TypeDocs: TypeDoc[] | null = null;
  Items: any[] | null = null;
  Client: Client | null = null;
  Service: Service | null = null;
  TituloAccionABMC: { [index: string]: string } = {
    A: '(Agregar)',
    B: '(Eliminar)',
    M: '(Modificar)',
    C: '(Consultar)',
    L: '(Listado)',
  };
  AccionABMC: string = 'L'; // inicia en el listado de articulos (buscar con parametros)

  Mensajes = {
    SD: ' No se encontraron registros...',
    RD: ' Revisar los datos ingresados...',
  };

  submitted = false;

  constructor(
    private typeDocsService: TypeDocsService, 
    private clientsService: ClientsService,
    private turnsService: TurnsService,
    private clientsXTurnsXUsersService: ClientsXTurnsXUsersService,
    private modalDialogService: ModalDialogService
    ) { }

  ngOnInit(): void {
    this.GetTypeDocs();
  }

  GetTypeDocs() {
    this.typeDocsService.get().subscribe((res: any) => {
      this.TypeDocs = res.items;
    });
  }

  // Buscar segun los filtros, establecidos en FormRegistro
  Search() {
    this.submitted = true;
    // verificar que los validadores esten OK
    if (this.FormSearch.invalid) {
      return;
    }

    this.modalDialogService.BloquearPantalla();
    this.clientsService
    .get(
      this.FormSearch.value.NumDoc,
      this.FormSearch.value.IdTypeDoc,
    )
    .subscribe((res: any) => {
      this.Client = res.items.result;
      this.modalDialogService.DesbloquearPantalla();
      this.clientsXTurnsXUsersService
    .get(
      'client',
      res.items.result[0]?.id || 0
    )
    .subscribe((res: any) => {
      this.Items = res.items.result;
      // res.items.result.map((e: any) => {
      //   this.Items = e.turn;
      //   this.Service = e.service;
      // });
      this.modalDialogService.DesbloquearPantalla();
    });
     });
    
    // this.turnsService
    // .get(
    //   this.Client?.id
    // )
    // .subscribe((res: any) => {
    //   this.Items = res.items;
    //   this.modalDialogService.DesbloquearPantalla();
    // });
  }

  Consult(Item: Turn) {

  }

  Modify(Item: Turn) {

  }

  Delete(Item: Turn) {

  }

  FormSearch = new FormGroup({
    NumDoc: new FormControl('', [
      Validators.required,
    ]),
    IdTypeDoc: new FormControl('', [
      Validators.required,
    ]),
  });
}
