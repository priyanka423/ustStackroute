import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  // firebaseUrl = 'http://localhost:50740/api/Auth/register';

  constructor(public http: HttpClient) { }

  postUser(data): Observable<any> {
    console.log('service', data);
    let URL = "http://localhost:51512/api/Auth/register";
    return this.http.post(URL, data);

  }
  loginUser(login): Observable<any> {
    let URL = "http://localhost:51512/api/Auth/login";
    return this.http.post(URL, login);
  }

  isLoggedIn() {
    var isLoggedIn = false;
    var userData = JSON.parse(localStorage.getItem("UserDeatails"));
    console.log(userData);
    if (userData != null) {
      isLoggedIn = true;
    }
    return isLoggedIn;
  }

  getToken() {
    var userData = JSON.parse(localStorage.getItem("UserDeatails"));
    return userData.token1;
  }
}
