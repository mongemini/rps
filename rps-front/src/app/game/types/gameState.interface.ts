import { GameStatisticsResponseInterface } from './gameStatisticsResponse.interface';
import { UserInterface } from './user.Interface';

export interface GameStateInterface {
  gameInfo: GameStatisticsResponseInterface | null;
  firstUser: UserInterface | null;
  secondUser: UserInterface | null;
  step: number;
  nextUser: number;
  gameId: number;
  isLoading: boolean;
  error?: string | null;
}
