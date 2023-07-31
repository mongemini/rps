import { createFeatureSelector, createSelector } from '@ngrx/store';
import { AppStateInterface } from 'src/app/shared/types/appState.interface';
import { GameStateInterface } from '../types/gameState.interface';

export const gameFeatureSelector =
  createFeatureSelector<GameStateInterface>('game');

export const allSelector = createSelector(
  gameFeatureSelector,
  (gameState: GameStateInterface) => gameState
);

export const isLoadingSelector = createSelector(
  gameFeatureSelector,
  (gameState: GameStateInterface) => gameState.isLoading
);

export const gameInfoSelector = createSelector(
  gameFeatureSelector,
  (gameState: GameStateInterface) => gameState.gameInfo
);
