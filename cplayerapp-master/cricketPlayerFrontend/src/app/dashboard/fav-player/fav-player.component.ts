import { Component, OnInit } from '@angular/core';
import { FetchDataService } from 'src/app/fetch-data.service';

@Component({
  selector: 'app-fav-player',
  templateUrl: './fav-player.component.html',
  styleUrls: ['./fav-player.component.css']
})
export class FavPlayerComponent implements OnInit {

  constructor(private fetchData: FetchDataService) { }
  favPlayers: any;
  playerStat: any = null;
  heartClass: any = "fa-heart-o";
  currentPlayerPid: any;
  ngOnInit(): void {
    this.favPlayers = this.fetchData.favPlayerFunc();
  }

  showMoreStat(pid) {
    this.heartClass = "fa-heart-o";
    this.currentPlayerPid = pid;
    this.fetchData.getPlayerStat(pid).subscribe((data) => {
      this.playerStat = data;
    });
  }
  showSearchStat(pid) {
    this.currentPlayerPid = pid;
    this.heartClass = "fa-heart-o";
    this.fetchData.getPlayerStat(pid).subscribe(res => {
      this.playerStat = res;
    })

  }

  scroll(className: string) {
    console.log("calling")
    const elementList = document.querySelectorAll(className);
    const element = elementList[0] as HTMLElement;
    element.scrollIntoView({ behavior: 'smooth' });
  }

  makeItFav() {
    this.heartClass = "fa-heart";
    this.fetchData.makeItFav(this.playerStat).subscribe(res => {
      console.log(res);
    });

  }
}
