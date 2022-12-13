import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  LoginPanel: boolean = true;
  constructor() { }

  ngOnInit(): void {
  }

  TogglePanel(number: any) {
    if (number == 1)
      this.LoginPanel = true;
    else 
      this.LoginPanel = false;
  }
}
