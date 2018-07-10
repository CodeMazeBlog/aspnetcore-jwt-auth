import { JwtHelper } from 'angular2-jwt';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable()
export class AuthGuard  {

  constructor(private jwtHelper: JwtHelper, private router: Router) {
  }

}
