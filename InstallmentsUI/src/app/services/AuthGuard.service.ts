import { CanActivate } from "@angular/router";
import { Injectable } from "@angular/core";
import { AuthService } from "./auth.service";


@Injectable()
export class AuthGuard implements CanActivate {

  constructor(protected auth: AuthService) { }

  canActivate() {
    if (this.auth.authenticated())
      return true;

    window.location.href = '/';
    return false;
  }
}
