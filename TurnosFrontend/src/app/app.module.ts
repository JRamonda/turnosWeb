import { NgModule, LOCALE_ID } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { MyInterceptor } from "./shared/my-interceptor";

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MenuComponent } from './components/menu/menu.component';
import { ContactComponent } from './components/contact/contact.component';
import { TurnsComponent } from './components/turns/turns.component';
import { MyTurnComponent } from './components/my-turn/my-turn.component';
import { LoginComponent } from './components/login/login.component';
import { ModalDialogComponent } from './components/modal-dialog/modal-dialog.component';  

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { APP_BASE_HREF, registerLocaleData } from '@angular/common';

import { NgbPaginationModule } from "@ng-bootstrap/ng-bootstrap";
import { TurnsManagerComponent } from './components/turns-manager/turns-manager.component';

import localeAr from '@angular/common/locales/es-AR';
registerLocaleData(localeAr);

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    MenuComponent,
    ModalDialogComponent,
    ContactComponent,
    TurnsComponent,
    MyTurnComponent,
    LoginComponent,
    TurnsManagerComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/inicio', pathMatch: 'full' },
      { path: 'inicio', component: HomeComponent },
      { path: 'turnos', component: TurnsComponent },
      { path: 'miturno', component: MyTurnComponent },
      { path: 'contacto', component: ContactComponent },
      { path: 'login', component: LoginComponent },
    ]),
    FormsModule,
    ReactiveFormsModule,
    NgbPaginationModule,
    HttpClientModule,
  ],
  providers: [
    { provide: APP_BASE_HREF, useValue: "/" }, 
    { provide: HTTP_INTERCEPTORS, useClass: MyInterceptor, multi: true }, 
    { provide: LOCALE_ID, useValue: 'es-AR' }
  ],
  bootstrap: [AppComponent],
  entryComponents: [ModalDialogComponent],
})
export class AppModule { }
