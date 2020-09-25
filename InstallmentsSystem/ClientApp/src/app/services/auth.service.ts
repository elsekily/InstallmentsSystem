import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { loggedUser } from '../models/user';
import { JwtHelperService } from '@auth0/angular-jwt';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient, private jwt: JwtHelperService) { }

  login(user) {
    return this.http.post<loggedUser>('/api/account/login', user);
  }
  public authenticated() {
    const token = localStorage.getItem('token');
    return !this.jwt.isTokenExpired(token);
  }

  public logout() {
    localStorage.removeItem('token');
  }

}
