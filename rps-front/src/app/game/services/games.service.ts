import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { CreateGameRequestInterface } from '../types/createGameRequest.interface';
import { CreateGameResponseInterface } from '../types/createGameResponse.interface';
import { JoinToGameRequestInterface } from '../types/joinToGameRequest.interface';
import { environment } from 'src/environments/environments';
import { JoinToGameResponseInterface } from '../types/joinToGameResponse.interface';
import { NewUserStepRequestInterface } from '../types/newUserStepRequest.interface';
import { GameStatisticsResponseInterface } from '../types/gameStatisticsResponse.interface';

@Injectable()
export class GamesService {
  constructor(private http: HttpClient) {}

  createGame(
    data: CreateGameRequestInterface
  ): Observable<CreateGameResponseInterface> {
    const url = environment.apiUrl + `/create?userName=${data.userName}`;
    return this.http
      .post<CreateGameResponseInterface>(url, data)
      .pipe(map((response: CreateGameResponseInterface) => response));
  }

  joinToGame(
    data: JoinToGameRequestInterface
  ): Observable<JoinToGameResponseInterface> {
    const url = environment.apiUrl + `/${data.gameId}/join/${data.userName}`;
    return this.http
      .put<JoinToGameResponseInterface>(url, data)
      .pipe(map((response: JoinToGameResponseInterface) => response));
  }

  nextUserStep(data: NewUserStepRequestInterface): Observable<boolean> {
    const url =
      environment.apiUrl + `/${data.gameId}/user/${data.userId}/${data.turn}`;
    return this.http
      .put<boolean>(url, data)
      .pipe(map((response: boolean) => response));
  }

  gameInfo(data: number): Observable<GameStatisticsResponseInterface> {
    const url = environment.apiUrl + `/${data}/stat`;
    return this.http
      .get<GameStatisticsResponseInterface>(url)
      .pipe(map((response: GameStatisticsResponseInterface) => response));
  }
}
