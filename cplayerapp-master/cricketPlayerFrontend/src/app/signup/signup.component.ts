import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  error: string;
  buttonDisable: boolean = false;
  constructor(private service: UserService, private router: Router) { }
  register(form: NgForm) {
    this.service.postUser(form.value).subscribe(data => {
      alert('Register Successfully');
      this.router.navigateByUrl('/login');
      form.reset();
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