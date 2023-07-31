import { createAction, props } from '@ngrx/store';

import { ActionTypes } from 'src/app/game/store/actionTypes';
import { CreateGameRequestInterface } from '../types/createGameRequest.interface';
import { CreateGameResponseInterface } from '../types/createGameResponse.interface';
import { BackendErrorInterface } from '../types/backendError.interface';
import { JoinToGameRequestInterface } from '../types/joinToGameRequest.interface';
import { JoinToGameResponseInterface } from '../types/joinToGameResponse.interface';
import { NewUserStepRequestInterface } from '../types/newUserStepRequest.interface';
import { GameStatisticsResponseInterface } from '../types/gameStatisticsResponse.interface';
import { NewUserStepResponseInterface } from '../types/nextUserStepResponse.interface';

export const createGameAction = createAction(
  ActionTypes.CREATE_GAME,
  props<{ request: CreateGameRequestInterface }>()
);

export const createGameSuccessAction = createAction(
  ActionTypes.CREATE_GAME_SUCCESS,
  props<{ response: CreateGameResponseInterface }>()
);

export const createGameFailureAction = createAction(
  ActionTypes.CREATE_GAME_FAILURE,
  props<{ error: BackendErrorInterface }>()
);

export const joinToGameAction = createAction(
  ActionTypes.JOIN_TO_GAME,
  props<{ request: JoinToGameRequestInterface }>()
);

export const joinToGameSuccessAction = createAction(
  ActionTypes.JOIN_TO_GAME_SUCCESS,
  props<{ response: JoinToGameResponseInterface }>()
);

export const joinToGameFailureAction = createAction(
  ActionTypes.JOIN_TO_GAME_FAILURE,
  props<{ error: BackendErrorInterface }>()
);

export const newUserStepAction = createAction(
  ActionTypes.NEW_USER_STEP,
  props<{ request: NewUserStepRequestInterface }>()
);

export const newUserStepSuccessAction = createAction(
  ActionTypes.NEW_USER_STEP_SUCCESS,
  props<{ response: NewUserStepResponseInterface }>()
);

export const newUserStepFailureAction = createAction(
  ActionTypes.NEW_USER_STEP_FAILURE,
  props<{ error: BackendErrorInterface }>()
);

export const gameStatisticsAction = createAction(
  ActionTypes.GAME_STATISTICS,
  props<{ request: number }>()
);

export const gameStatisticsSuccessAction = createAction(
  ActionTypes.GAME_STATISTICS_SUCCESS,
  props<{ response: GameStatisticsResponseInterface }>()
);

export const gameStatisticsFailureAction = createAction(
  ActionTypes.GAME_STATISTICSP_FAILURE,
  props<{ error: BackendErrorInterface }>()
);

export const newGame = createAction(ActionTypes.START_NEW_GAME);
