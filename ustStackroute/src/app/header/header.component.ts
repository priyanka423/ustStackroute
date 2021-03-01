import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  constructor(private auth: UserService, private router: Router) { }
  userInfo:any;
  loginStatus: boolean;
  ngOnInit(): void {
    this.loginStatus = this.auth.isLoggedIn();
  }
  ngOnChanges() {
    console.log("yes")
  }
  isLoggedIn() {
    const UserDeatails = JSON.parse(localStorage.getItem('UserDeatails'));
    if (UserDeatails) {
      this.userInfo = UserDeatails.userId;
      return true;
    } else {
      return false;
    }
  }
  logout() {
    localStorage.removeItem('UserDeatails');
    this.router.navigateByUrl('/login');

  }
}
