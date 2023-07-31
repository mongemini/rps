import { Component, OnInit } from '@angular/core';
import { Store, select } from '@ngrx/store';
import { Observable } from 'rxjs';

import {
  createGameAction,
  joinToGameAction,
  newGame,
} from 'src/app/game/store/actions';
import { allSelector, gameInfoSelector } from '../../store/selectors';
import { GameStateInterface } from '../../types/gameState.interface';
import { GameStatisticsResponseInterface } from '../../types/gameStatisticsResponse.interface';

@Component({
  selector: 'app-game-panel',
  templateUrl: './game-panel.component.html',
  styleUrls: ['./game-panel.component.less'],
})
export class GamePanelComponent implements OnInit {
  gameInfo$: Observable<any>;
  info$: Observable<GameStatisticsResponseInterface | null>;
  public firstUserName = '';
  public secondUserName = '';

  constructor(private store: Store) {}

  ngOnInit(): void {
    this.gameInfo$ = this.store.pipe(select(allSelector));
    this.info$ = this.store.pipe(select(gameInfoSelector));
  }

  startGame() {
    this.store.dispatch(
      createGameAction({ request: { userName: this.firstUserName } })
    );
    this.firstUserName = '';
  }

  joinToGame(gameId: number) {
    this.store.dispatch(
      joinToGameAction({
        request: { gameId: gameId, userName: this.secondUserName },
      })
    );
    this.secondUserName = '';
  }

  newGame() {
    this.store.dispatch(newGame());
  }
}
