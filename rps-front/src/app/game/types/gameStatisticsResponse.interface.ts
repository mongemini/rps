import { UserInterface } from './user.Interface';

export interface GameStatisticsResponseInterface {
  gameId: number;
  firstUser: UserInterface;
  secondUser: UserInterface;
  winner: number;
  isCloser: boolean;
}
