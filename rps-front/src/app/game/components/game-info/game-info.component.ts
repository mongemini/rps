import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import { GameStatisticsResponseInterface } from '../../types/gameStatisticsResponse.interface';
import { gameInfoSelector } from '../../store/selectors';

@Component({
  selector: 'app-game-info',
  templateUrl: './game-info.component.html',
  styleUrls: ['./game-info.component.less'],
})
export class GameInfoComponent implements OnInit {
  info$: Observable<GameStatisticsResponseInterface | null>;

  constructor(private store: Store) {}

  ngOnInit(): void {
    this.info$ = this.store.pipe(select(gameInfoSelector));
  }
}
