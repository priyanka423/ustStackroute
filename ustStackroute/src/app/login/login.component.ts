import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  error: any
  userSession: string;
  buttonDisable: boolean = false;
  constructor(private auth: UserService, private router: Router) { }
  setErrorMessage: any;
  login(form: NgForm) {
    this.error = null;
    this.auth.loginUser(form.value).subscribe(data => {
      if (data.status == "success") {
        let login = data;
        console.log(localStorage.setItem('UserDeatails', JSON.stringify(login)));
        this.userSession = localStorage.getItem('UserDeatails');
        alert("Login Successfull");
        this.router.navigateByUrl('/dashboard');
      }
      else if (data.status == "failure") {
        this.setErrorMessage = "Wrong email and password combination..";
      } else {
        this.setErrorMessage = "Wrong email and password combination..";
      form.reset();
      }
    }, err => {
      this.error = err.error.message;
    
    });
  }

  ngOnInit(): void {
  }
  validateEmpty(form: NgForm) {
    if ((form.value.UserId == null || form.value.UserId == "") || (form.value.Password == null || form.value.Password == "")) {
      this.buttonDisable = true;
    } else {
      this.buttonDisable = false;

    }
  }
}
