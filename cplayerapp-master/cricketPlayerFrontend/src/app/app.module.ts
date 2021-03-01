import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatToolbarModule } from '@angular/material/toolbar';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FavPlayerComponent } from './dashboard/fav-player/fav-player.component';
import { FooterComponent } from './footer/footer.component';
import { FavPlayersComponent } from './dashboard/fav-players/fav-players.component';
import { RecommendationComponent } from './dashboard/recommendation/recommendation.component';
const routes: Routes = [
  {
    path: '', component: HomeComponent
  },
  {
    path: 'login', component: LoginComponent
  },
  {
    path: 'dashboard', component: DashboardComponent
  },
  {
    path: 'signup', component: SignupComponent
  },
  {
    path: 'about', component: AboutComponent
  },
  {
    path: 'fav-player', component: FavPlayerComponent
  },
  {
    path: 'fav-players', component: FavPlayersComponent
  },
  {
    path: 'recommendation', component: RecommendationComponent
  }

]
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    SignupComponent,
    DashboardComponent,
    HomeComponent,
    AboutComponent,
    FavPlayerComponent,
    FooterComponent,
    FavPlayersComponent,
    RecommendationComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatToolbarModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
