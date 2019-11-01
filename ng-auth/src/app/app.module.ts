import { AuthGuard } from './guards/auth-guard.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { JwtModule } from "@auth0/angular-jwt";

import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { CustomersComponent } from './customers/customers.component';
import { AppComponent } from './app.component';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

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
    ]),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        whitelistedDomains: ["localhost:5000"],
        blacklistedRoutes: []
      }
    })
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
