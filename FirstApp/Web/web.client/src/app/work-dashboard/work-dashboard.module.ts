import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkDashboardComponent } from './work-dashboard.component';
import { ListComponent } from '../list/list.component';
import { ListModule } from '../list/list.module';
import { AddCardModule } from '../add-card/add-card.module';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { ListEffects } from '../store/effects/list-effects';
import { StoreModule } from '@ngrx/store';
import { rootReducer } from '../store/reducers/app-reducer';



@NgModule({
  declarations: [
    WorkDashboardComponent
  ],
  imports: [
    CommonModule,
    ListModule,
    FormsModule,    
    StoreModule.forRoot({ list: rootReducer }),
    EffectsModule.forRoot([ListEffects])
  ],
  exports: [
    WorkDashboardComponent
  ]
})
export class WorkDashboardModule { }
