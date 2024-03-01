import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveUser, loggedUser } from '../models/user';
import { JwtHelperService } from '@auth0/angular-jwt';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  apiUrl = environment.apiUrl;
  constructor(private http: HttpClient, private jwt: JwtHelperService) { }

  login(user: SaveUser) {
    return this.http.post<loggedUser>(this.apiUrl+'api/account/login', user);
  }
  public authenticated() {
    const token = localStorage.getItem('token');
    return !this.jwt.isTokenExpired(token);
  }

  public logout() {
    localStorage.removeItem('token');
  }

}
