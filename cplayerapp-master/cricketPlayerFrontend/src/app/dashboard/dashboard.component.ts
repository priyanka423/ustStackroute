import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {

  constructor(private router: Router) { }
  favPlayer: any;
  ngOnInit(): void {
  }
  
  playerStat() {
    this.router.navigateByUrl('/fav-player');
  }

  myFavList() {
    this.router.navigateByUrl('/fav-players');
  }
  recommendation() {
    this.router.navigateByUrl('/recommendation');
  }
}
