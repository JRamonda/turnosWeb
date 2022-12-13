import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { TypeDoc } from '../../models/type-docs';
import { Service } from '../../models/service';
import { TypeDocsService } from '../../services/type-docs.service';
import { ServicesService } from '../../services/services.service';
import { Turn } from '../../models/turn';
import { TurnsService } from '../../services/turns.service';
import { ClientsXTurnsXUsersService } from '../../services/clients-xturns-xusers.service';

import * as moment from 'moment';
import { ClientsService } from '../../services/clients.service';
import { ModalDialogService } from '../../services/modal-dialog.service';

@Component({
  selector: 'app-turns',
  templateUrl: './turns.component.html',
  styleUrls: ['./turns.component.css']
})
export class TurnsComponent implements OnInit {
  submitted = false;
  Messages = {
    SD: ' No se encontraron registros...',
    RD: ' Revisar los datos ingresados...',
  };
  selectedTurn: any = '';

  TypeDocs: TypeDoc[] | null = null;
  Services: Service[] | null = null;
  Turns: Turn[] | null = null;

  selected: boolean = false;
  preSelected: string = '';

  constructor(
    private typeDocsService: TypeDocsService,
    private turnsService: TurnsService,
    private clientsService: ClientsService,
    private servicesService: ServicesService,
    private clientsXTurnsXUsersService: ClientsXTurnsXUsersService,
    private modalDialogService: ModalDialogService
  ) {
  }

  ngOnInit(): void {
    this.GetTypeDocs();
    this.GetServices();
    this.GetTurns();

    this.getDaysFromDate(12, 2022)
  }
  
  GetTurns() {
    this.turnsService.get().subscribe((res: any) => {
      this.Turns = res.items;
      this.clientsXTurnsXUsersService
      .get(
      )
      .subscribe((res: any) => {
        this.Turns?.map((turn: Turn) => {
          res.items.result.map((e: any) => {
            if (turn.date === e.turn.date && turn.startTime === e.turn.startTime)
              turn.state = true;
          })
        });
      });
    });
  }

  GetTypeDocs() {
    this.typeDocsService.get().subscribe((res: any) => {
      this.TypeDocs = res.items;
    })
  }

  GetServices() {
    this.servicesService.get().subscribe((res: any) => {
      this.Services = res.items;
    });
  }

  Selected(turn: Turn) {
    this.selectedTurn = this.HourSystem(turn.startTime);
  }

  Save() {
    this.submitted = true;
    // verificar que los validadores esten OK
    // if (this.FormRegister.invalid) {
    //   return;
    // }

    //hacemos una copia de los datos del formulario, para modificar la fecha y luego enviarlo al servidor
    const itemClient: any = {
      FirstName: this.FormRegister.value.FirstName,
      LastName: this.FormRegister.value.LastName,
      NumDoc: this.FormRegister.value.NumDoc,
      IdTypeDoc: this.FormRegister.value.IdTypeDoc,
      NumPhone: this.FormRegister.value.NumPhone,
    };

    //buscar si existe el cliente o no para luego crearlo
    this.clientsService.get(itemClient.NumDoc, itemClient.IdTypeDoc).subscribe((res: any) => {
      let clientId = 0;

      if (res.items.result[0]?.id == undefined) {
        this.clientsService.post(itemClient).subscribe((res: any) => {
          clientId = res.id;
        });
      }
      else {
        clientId = res.items.result[0]?.id;
      }

      let turnId = 1;
      let userId = 1;
      let serviceId = this.FormRegister.value.IdService;
      const itemTurn: any = {
        IdClient: clientId,
        IdTurn: turnId,
        IdUser: userId,
        IdService: serviceId,
      }

      this.clientsXTurnsXUsersService.get('client turn user', clientId, turnId, userId).subscribe((res: any) => {
        //length == 1 si se encontro
        if (res.items.result.length == 1) {
          this.modalDialogService.Alert('Ya tienes un turno para la hora y fecha seleccionados, puedes consultarlo en la sección "Mi Turno"');
        } else {
          this.clientsXTurnsXUsersService.post(itemTurn).subscribe((res: any) => {
            this.modalDialogService.Alert('Turno reservado correctamente, podras consultarlo en la sección "Mi Turno"');
            this.FormRegister.reset();
          });
        }
      });

     
    });
    this.submitted = false;
  }

  HourSystem(time: string) {
    if (time.slice(0,2) < '12')
      return time.slice(0,5) + ' am';
    return time.slice(0,5) + ' pm';
  }

  FormRegister = new FormGroup({
    FirstName: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(55),
    ]),
    LastName: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(55),
    ]),
    NumDoc: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(55),
    ]),
    IdTypeDoc: new FormControl('', [
      Validators.required,
    ]),
    NumPhone: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(55),
    ]),
    IdService: new FormControl('', [
      Validators.required,
    ]),
  });

  week: any = [
    "Lunes",
    "Martes",
    "Miercoles",
    "Jueves",
    "Viernes",
    "Sabado",
    "Domingo"
  ];

  monthSelect: any[] = [];
  dateSelect: any;
  dateValue: any;

  getDaysFromDate(month: number, year: number) {
    const startDate = moment.utc(`${year}/${month}/01`)
    const endDate = startDate.clone().endOf('month')
    this.dateSelect = startDate;

    const diffDays = endDate.diff(startDate, 'days', true)
    const numberDays = Math.round(diffDays);

    const arrayDays = Object.keys([...Array(numberDays)]).map((a: any) => {
      a = parseInt(a) + 1;
      const dayObject = moment(`${year}-${month}-${a}`)
      return {
        name: dayObject.format("dddd"),
        value: a,
        indexWeek: dayObject.isoWeekday()
      };
    });

    this.monthSelect = arrayDays;
  }

  changeMonth(flag: number) {
    if (flag < 0) {
      const prevDate = this.dateSelect.clone().subtract(1, "month");
      this.getDaysFromDate(prevDate.format("MM"), prevDate.format("YYYY"));
    } else {
      const nextDate = this.dateSelect.clone().add(1, "month");
      this.getDaysFromDate(nextDate.format("MM"), nextDate.format("YYYY"));
    }
  }

  clickDay(day: any) {
    const monthYear = this.dateSelect.format('YYYY-MM')
    const parse = `${monthYear}-${day.value}`
    const objectDate = moment(parse)
    this.dateValue = objectDate;
  }

  toggleSelected(i: any) {
    const spanSelected = document.getElementById(i);
    if (spanSelected != null) {
      spanSelected.classList.add('lightGray');
    }
    const spanPreSelected = document.getElementById(this.preSelected);
    if (spanPreSelected != null && this.preSelected != i) {
      spanPreSelected.classList.remove('lightGray');
    }
    this.preSelected = i;
  }
}