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

  constructor(private authservice: AuthService) { }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  submit() {
    this.authservice.login(this.user).subscribe(res => {
      localStorage.setItem('token', res.tokenString);
    });
  }
  loggedIn() {
    return this.authservice.authenticated();
  }

  logout() {
    if (confirm('Are you sure??')) {
      this.authservice.logout();
      window.location.replace('/');
    }
  }
}
