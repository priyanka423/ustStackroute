import { Component, OnInit } from '@angular/core';
import { FetchDataService } from 'src/app/fetch-data.service';

@Component({
  selector: 'app-recommendation',
  templateUrl: './recommendation.component.html',
  styleUrls: ['./recommendation.component.css']
})
export class RecommendationComponent implements OnInit {

  constructor(private fetchData: FetchDataService) { }

  recommendationGlobalData: any;
  ngOnInit(): void {
    let n = 4;
    this.fetchData.getFavPlayers().subscribe(res => {
      let array = Array.from({ length: res.length }, (v, k) => res[k]);

      var shuffled = array.sort(function () { return .1 - Math.random() });
      console.log(shuffled, "length", res.length)
      if (res.length > 5) {
        this.recommendationGlobalData = res.sort((a, b) => b - a).slice(0, 5);
        console.log(this.recommendationGlobalData, "rrr")
      } else {
        this.recommendationGlobalData = shuffled;
      }
    })
  }
}
