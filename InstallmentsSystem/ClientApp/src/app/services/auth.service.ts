import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { loggedUser } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(user) {
    return this.http.post<loggedUser>('/api/account/login', user);
  }
}
