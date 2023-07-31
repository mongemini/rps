import { createReducer, on, Action } from '@ngrx/store';

import { GameStateInterface } from '../types/gameState.interface';
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
  newGame,
  newUserStepAction,
  newUserStepFailureAction,
  newUserStepSuccessAction,
} from './actions';

import { UserInterface } from '../types/user.Interface';

const initState: GameStateInterface = {
  gameInfo: null,
  firstUser: null,
  secondUser: null,
  gameId: 0,
  isLoading: false,
  step: 1,
  nextUser: 1,
  error: null,
};

const gameReducer = createReducer(
  initState,
  on(
    newGame,
    (state): GameStateInterface => ({
      gameInfo: null,
      firstUser: null,
      secondUser: null,
      gameId: 0,
      isLoading: false,
      step: 1,
      nextUser: 1,
    })
  ),
  on(
    createGameAction,
    (state): GameStateInterface => ({
      ...state,
      gameId: 0,
      firstUser: null,
      secondUser: null,
      gameInfo: null,
      isLoading: true,
      error: undefined,
      step: 1,
      nextUser: 1,
    })
  ),
  on(createGameSuccessAction, (state, action): GameStateInterface => {
    const user: UserInterface = {
      id: action.response.firstUserId,
    };

    return {
      ...state,
      gameId: action.response.gameId,
      firstUser: user,
      isLoading: false,
      error: undefined,
    };
  }),
  on(
    createGameFailureAction,
    (state, action): GameStateInterface => ({
      ...state,
      isLoading: false,
      error: action.error.message,
    })
  ),
  on(
    gameStatisticsAction,
    (state): GameStateInterface => ({
      ...state,
      isLoading: true,
      error: undefined,
    })
  ),
  on(gameStatisticsSuccessAction, (state, action): GameStateInterface => {
    return {
      ...state,
      gameInfo: action.response,
      isLoading: false,
      error: undefined,
    };
  }),
  on(
    gameStatisticsFailureAction,
    (state, action): GameStateInterface => ({
      ...state,
      gameInfo: null,
      isLoading: false,
      error: action.error.message,
    })
  ),
  on(
    newUserStepAction,
    (state): GameStateInterface => ({
      ...state,
      isLoading: true,
      error: undefined,
    })
  ),
  on(newUserStepSuccessAction, (state, action): GameStateInterface => {
    return {
      ...state,
      isLoading: false,
      error: undefined,
      step: state.nextUser == 2 ? state.step + 1 : state.step,
      nextUser: state.nextUser == 1 ? 2 : 1,
    };
  }),
  on(
    newUserStepFailureAction,
    (state, action): GameStateInterface => ({
      ...state,
      isLoading: false,
      error: action.error.message,
    })
  ),
  on(
    joinToGameAction,
    (state): GameStateInterface => ({
      ...state,
      isLoading: true,
      error: undefined,
    })
  ),
  on(joinToGameSuccessAction, (state, action): GameStateInterface => {
    const user: UserInterface = {
      id: action.response.secondUserId,
    };

    return {
      ...state,
      secondUser: user,
      isLoading: false,
      error: undefined,
    };
  }),
  on(
    joinToGameFailureAction,
    (state, action): GameStateInterface => ({
      ...state,
      isLoading: false,
      error: action.error.message,
    })
  )
);

export function reducers(state: GameStateInterface, action: Action) {
  return gameReducer(state, action);
}
