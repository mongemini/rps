import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { RouterModule } from '@angular/router';

import { reducers } from './store/reducers';
import { GamesService } from './services/games.service';
import { GamesEffect } from './store/effects';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GamePanelComponent } from './components/game-panel/game-panel.component';
import { GameInfoComponent } from './components/game-info/game-info.component';
import { UserStepComponent } from './components/user-step/user-step.component';

const routes = [
  {
    path: 'game',
    component: GamePanelComponent,
  },
];

@NgModule({
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forFeature('game', reducers),
    EffectsModule.forFeature([GamesEffect]),
  ],
  declarations: [
    GamePanelComponent,
    GameInfoComponent,
    UserStepComponent,
    UserStepComponent,
  ],
  providers: [GamesService],
})
export class GameModule {}
