import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css']
})

export class ContactComponent implements OnInit {
  submitted = false;
  Messages = {
    SD: ' No se encontraron registros...',
    RD: ' Revisar los datos ingresados...',
  };
  constructor() { }

  ngOnInit(): void {
  }

  Enviar() {
    this.submitted = true;
    // verificar que los validadores esten OK
    if (this.FormContact.invalid) {
      return;
    }
  }

  FormContact = new FormGroup({
    Name: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(55),
    ]),
    Email: new FormControl('', [
      Validators.required,
      Validators.pattern(
        '^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'
      ),
    ]),
    Affair: new FormControl('', [
      Validators.required,
      Validators.minLength(4),
      Validators.maxLength(55),
    ]),
    Message: new FormControl('', [
      Validators.required,
      Validators.minLength(3),
      Validators.maxLength(400),
    ]),
    Date: new FormControl('', [
      Validators.required,
      Validators.pattern(
        '(0[1-9]|[12][0-9]|3[01])[-/](0[1-9]|1[012])[-/](19|20)[0-9]{2}'
      ),
    ]),
  });
}
