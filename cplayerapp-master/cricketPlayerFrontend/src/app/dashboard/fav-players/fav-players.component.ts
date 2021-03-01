import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FetchDataService } from 'src/app/fetch-data.service';

@Component({
  selector: 'app-fav-players',
  templateUrl: './fav-players.component.html',
  styleUrls: ['./fav-players.component.css']
})
export class FavPlayersComponent implements OnInit {

  constructor(private fetchData: FetchDataService, private router: Router) { }

  favPlayerss: any;
  ifFavEmpty:boolean=false;
  ngOnInit(): void {
    this.fetchData.getFavPlayers().subscribe(res => {
      console.log(res)
      this.favPlayerss = res;
      if(res==null||res==""){
        this.ifFavEmpty = true;
      }
    })
  }


  ngAfterViewInit() {
  }
  removeFav(pid) {
    this.fetchData.deleteFavService(pid).subscribe(res => {
      if (res == true) {
        alert("favourite Deleted successfully");
        this.ngOnInit()
      }
    })
  }

}
