import { AuthGuard } from './guards/auth-guard.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { JwtHelper } from 'angular2-jwt'

import { HomeComponent } from 'app/home/home.component';
import { LoginComponent } from 'app/login/login.component';
import { CustomersComponent } from 'app/customers/customers.component';
import { AppComponent } from './app/app.component';

@NgModule({
  declarations: [
    HomeComponent,
    LoginComponent,
    CustomersComponent,
    AppComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'login', component: LoginComponent },
      { path: 'customers', component: CustomersComponent, canActivate: [AuthGuard] },
    ])
  ],
  providers: [JwtHelper, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
