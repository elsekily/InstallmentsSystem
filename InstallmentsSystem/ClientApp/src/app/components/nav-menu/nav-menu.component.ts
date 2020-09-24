import { Component } from '@angular/core';
import { SaveUser, loggedUser } from '../../models/user';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  user: SaveUser = {
    email: '',
    password: '',
    userName:''
  };

  loggeduser: loggedUser = {
    id: 0,
    email: '',
    roles: [],
    userName: '',
    tokenString: ''
  };

  constructor(private authservice: AuthService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  submit() {
    console.log(this.user);
    this.authservice.login(this.user).subscribe(res => {
      console.log(res.tokenString);
      localStorage.setItem('token', res.tokenString);
    });
  }
  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }
}
