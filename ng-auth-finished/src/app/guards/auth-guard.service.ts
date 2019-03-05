import { JwtHelperService } from '@auth0/angular-jwt'
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private JwtHelperService: JwtHelperService, private router: Router) {
  }
  canActivate() {
    var token = localStorage.getItem("jwt");

    if (token && !this.JwtHelperService.isTokenExpired(token)){
      console.log(this.JwtHelperService.decodeToken(token));
      return true;
    }
    this.router.navigate(["login"]);
    return false;
  }
}

