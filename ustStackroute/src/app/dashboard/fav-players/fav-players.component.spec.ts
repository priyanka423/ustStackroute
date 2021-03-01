import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FavPlayersComponent } from './fav-players.component';

describe('FavPlayersComponent', () => {
  let component: FavPlayersComponent;
  let fixture: ComponentFixture<FavPlayersComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FavPlayersComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FavPlayersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
