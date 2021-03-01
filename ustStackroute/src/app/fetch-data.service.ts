import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserService } from './user.service';


@Injectable({
  providedIn: 'root'
})
export class FetchDataService {

  constructor(private http: HttpClient, private _userService: UserService) { }
  favPlayer: any;
  apiKey: string = "VCibphp6XocVqRWkrDpZyAdK8Am2";
  userInfo = JSON.parse(localStorage.getItem("UserDeatails"))

  favPlayerFunc() {
    return [
      {
        pid: 35320,
        name: "Sachin Tendulkar "
      },
      {
        pid: 49640,
        name: "Thilina Masmulla"
      },
      {
        pid: 359200,
        name: "Madawa Warnapura"
      },
      {
        pid: 424221,
        name: "Sachin Shinde"
      },
      {
        pid: 253802,
        name: "Virat Kohli"
      },
      {
        pid: 434225,
        name: "Ishani Seneviratne"
      },
      {
        pid: 34102,
        name: "Rohit Sharma"
      },
      {
        pid: 18632,
        name: "Samit Patel"
      },
      {
        pid: 4622,
        name: "Allan Cooper"
      },
      {
        pid: 779625,
        name: "Saraswati Kumari"
      },
      {
        pid: 1201537,
        name: "Abhimanyusingh Rajput"
      },
      {
        pid: 35775,
        name: "Vivek Yadav"
      },
      {
        pid: 54171,
        name: "Karu Jain"
      },
      {
        pid: 279545,
        name: "Pradeep Sangwan"
      },
      {
        pid: 471342,
        name: "Krunal Pandya"
      },
      {
        pid: 625371,
        name: "Hardik Pandya"
      },
      {
        pid: 4023,
        name: "Ross Allen"
      },
      {
        pid: 30176,
        name: "Anil Kumble"
      },
      {
        pid: 233514,
        name: "Thisara Perera"
      },
      {
        pid: 41058,
        name: "Kamran Hussain"
      },
      {
        pid: 3994,
        name: "James Atkinson"
      },
      {
        pid: 4010,
        name: "Richard Allanby"
      },
      {
        pid: 4000,
        name: "Sydney Austin"
      },
      {
        pid: 4236,
        name: "Sandy Buckle"
      },
      {
        pid: 296136,
        name: "Alessandro Bonora"
      },
      {
        pid: 4199,
        name: "Leon Braslin"
      },
      {
        pid: 4003,
        name: "William Albury"
      },
      {
        pid: 30988,
        name: "Nitin Menon"
      },
      {
        pid: 321725,
        name: "Narender Singh"
      },
      {
        pid: 52969,
        name: "Ramnaresh Sarwan"
      },
      {
        pid: 28801,
        name: "Naresh Gehlot"
      },
      {
        pid: 1054387,
        name: "Sohil Sidiqi"
      },
      {
        pid: 627632,
        name: "Jaskaranveer Singh"
      },
      {
        pid: 4881,
        name: "Scott Cameron"
      },
      {
        pid: 33757,
        name: "Sachin Rana"
      },
      {
        pid: 40630,
        name: "Inam-ul-Haq"
      },
      {
        pid: 4009,
        name: "Brett Anderton"
      },
      {
        pid: 4002,
        name: "Warren Ayres"
      },
      {
        pid: 4446,
        name: "Robert Barbour"
      },
      {
        pid: 35928,
        name: "Bipul Sharma"
      },
      {
        pid: 28114,
        name: "Rahul Dravid"
      },
      {
        pid: 29976,
        name: "Joginder Sharma"
      },
      {
        pid: 33318,
        name: "Rahul Saini"
      },
      {
        pid: 28235,
        name: "Shikhar Dhawan"
      },
      {
        pid: 422108,
        name: "KL Rahul"
      }
    ];
  }

  getPlayerStat(pid): Observable<any> {
    return this.http.get(`https://cricapi.com/api/playerStats?apikey=${this.apiKey}&pid=${pid}`)
  }

  getFavPlayers(): Observable<any> {
    let usr = this.userInfo.userId;
    return this.http.get(`http://localhost:57744/api/Favourite/${usr}`, {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${this._userService.getToken()}`)
        .set('Accept', 'application/json')
    })
  }

  makeItFav(playerInfo): Observable<any> {
    let user = JSON.parse(localStorage.getItem("UserDeatails"))
    let reqObject = {
      "playerId": playerInfo.pid,
      "playerName": playerInfo.fullName,
      "playerImage": playerInfo.imageURL,
      "createdBy": user.userId
    }
    return this.http.post('http://localhost:57744/api/Favourite', reqObject, {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${this._userService.getToken()}`)
        .set('Accept', 'application/json')
    });
  }

  deleteFavService(pid): Observable<any> {
    return this.http.delete(`http://localhost:57744/api/Favourite/${pid}/${this.userInfo.userId}`, {
      headers: new HttpHeaders()
        .set('Authorization', `Bearer ${this._userService.getToken()}`)
        .set('Accept', 'application/json')
    });
  }
}
