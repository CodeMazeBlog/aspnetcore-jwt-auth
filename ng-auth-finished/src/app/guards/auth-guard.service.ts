import { JwtHelper } from 'angular2-jwt';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private jwtHelper: JwtHelper, private router: Router) {
  }
  canActivate() {
    var token = localStorage.getItem("jwt");

    if (token && !this.jwtHelper.isTokenExpired(token)){
      console.log(this.jwtHelper.decodeToken(token));
      return true;
    }
    this.router.navigate(["login"]);
    return false;
  }
}
