import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list.component';
import { CardModule } from '../card/card.module';
import { AddCardModule } from '../add-card/add-card.module';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { ListEffects } from '../store/effects/list-effects';



@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    AddCardModule,
    FormsModule,
    EffectsModule.forFeature([ListEffects])
  ],
  exports: [
    ListComponent
  ]
})
export class ListModule { }
