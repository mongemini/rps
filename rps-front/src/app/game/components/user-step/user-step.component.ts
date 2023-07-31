import { Component, Input } from '@angular/core';
import { GameStatisticsResponseInterface } from '../../types/gameStatisticsResponse.interface';
import { GameStateInterface } from '../../types/gameState.interface';
import { Store } from '@ngrx/store';
import { newUserStepAction } from '../../store/actions';

@Component({
  selector: 'app-user-step',
  templateUrl: './user-step.component.html',
  styleUrls: ['./user-step.component.less'],
})
export class UserStepComponent {
  stepNumber: number;
  userNumber: number;
  userId?: number;
  turn: number = 0;
  isShow: boolean;
  gameId: number;
  winner?: number;

  constructor(private store: Store) {}

  @Input() set gameInfo(value: GameStateInterface) {
    if (value) {
      this.gameId = value.gameId;
      this.isShow = value.firstUser != null && value.secondUser != null;
      this.userNumber = value.nextUser;
      this.userId =
        value.nextUser == 1 ? value.firstUser?.id : value.secondUser?.id;
      this.stepNumber = value.step;
      this.turn = 0;
      this.winner = value.gameInfo?.winner;
    }
  }

  nextStep() {
    this.store.dispatch(
      newUserStepAction({
        request: {
          gameId: this.gameId,
          userId: this.userId || 0,
          turn: this.turn,
        },
      })
    );
  }
}
