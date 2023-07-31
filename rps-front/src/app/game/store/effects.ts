import { Injectable } from '@angular/core';
import { createEffect, Actions, ofType } from '@ngrx/effects';
import {
  map,
  catchError,
  switchMap,
  tap,
  withLatestFrom,
} from 'rxjs/operators';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable, of } from 'rxjs';

import {
  createGameAction,
  createGameFailureAction,
  createGameSuccessAction,
  gameStatisticsAction,
  gameStatisticsFailureAction,
  gameStatisticsSuccessAction,
  joinToGameAction,
  joinToGameFailureAction,
  joinToGameSuccessAction,
  newUserStepAction,
  newUserStepFailureAction,
  newUserStepSuccessAction,
} from './actions';
import { GamesService } from '../services/games.service';
import { CreateGameResponseInterface } from '../types/createGameResponse.interface';
import { JoinToGameResponseInterface } from '../types/joinToGameResponse.interface';
import { GameStatisticsResponseInterface } from '../types/gameStatisticsResponse.interface';
import { Store } from '@ngrx/store';
import { AppStateInterface } from 'src/app/shared/types/appState.interface';
import { allSelector } from './selectors';
import { GameStateInterface } from '../types/gameState.interface';
import { NewUserStepResponseInterface } from '../types/nextUserStepResponse.interface';

@Injectable()
export class GamesEffect {
  constructor(
    private actions$: Actions,
    private gamesService: GamesService,
    private store$: Store<AppStateInterface>
  ) {}

  createGame$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createGameAction),
      switchMap(({ request }) => {
        return this.gamesService.createGame(request).pipe(
          map((response: CreateGameResponseInterface) => {
            return createGameSuccessAction({ response });
          }),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              createGameFailureAction({ error: errorResponse.error.errors })
            );
          })
        );
      })
    )
  );

  joinToGame$ = createEffect(() =>
    this.actions$.pipe(
      ofType(joinToGameAction),
      switchMap(({ request }) => {
        return this.gamesService.joinToGame(request).pipe(
          map((response: JoinToGameResponseInterface) => {
            return joinToGameSuccessAction({
              response: {
                secondUserId: response.secondUserId,
                gameId: request.gameId,
              },
            });
          }),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              joinToGameFailureAction({ error: errorResponse.error.errors })
            );
          })
        );
      })
    )
  );

  nextUserStep$ = createEffect(() =>
    this.actions$.pipe(
      ofType(newUserStepAction),
      switchMap(({ request }) => {
        return this.gamesService.nextUserStep(request).pipe(
          map((response: boolean) => {
            return newUserStepSuccessAction({
              response: {
                gameId: request.gameId,
                result: response,
              },
            });
          }),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              newUserStepFailureAction({ error: errorResponse.error.errors })
            );
          })
        );
      })
    )
  );

  gameStatistics$ = createEffect(() =>
    this.actions$.pipe(
      ofType(gameStatisticsAction),
      switchMap(({ request }) => {
        return this.gamesService.gameInfo(request).pipe(
          map((response: GameStatisticsResponseInterface) => {
            return gameStatisticsSuccessAction({ response });
          }),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              gameStatisticsFailureAction({ error: errorResponse.error.errors })
            );
          })
        );
      })
    )
  );

  redirectAfterCreate$ = createEffect(() =>
    this.actions$.pipe(
      ofType(createGameSuccessAction),
      switchMap(({ response }) => {
        return this.gamesService.gameInfo(response.gameId).pipe(
          map((response: GameStatisticsResponseInterface) => {
            return gameStatisticsSuccessAction({ response });
          }),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              gameStatisticsFailureAction({ error: errorResponse.error.errors })
            );
          })
        );
      })
    )
  );

  redirectAfterJoin$ = createEffect(() =>
    this.actions$.pipe(
      ofType(joinToGameSuccessAction),
      switchMap((response) => {
        return this.gamesService.gameInfo(response.response.gameId).pipe(
          map((response: GameStatisticsResponseInterface) => {
            return gameStatisticsSuccessAction({ response });
          }),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              gameStatisticsFailureAction({ error: errorResponse.error.errors })
            );
          })
        );
      })
    )
  );

  redirectAfterStep$ = createEffect(() =>
    this.actions$.pipe(
      ofType(newUserStepSuccessAction),
      switchMap((response) => {
        return this.gamesService.gameInfo(response.response.gameId).pipe(
          map((response: GameStatisticsResponseInterface) => {
            return gameStatisticsSuccessAction({ response });
          }),
          catchError((errorResponse: HttpErrorResponse) => {
            return of(
              gameStatisticsFailureAction({ error: errorResponse.error.errors })
            );
          })
        );
      })
    )
  );
}
