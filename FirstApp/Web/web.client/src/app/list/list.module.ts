import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list.component';
import { CardModule } from '../card/card.module';
import { AddCardModule } from '../add-card/add-card.module';
import { FormsModule } from '@angular/forms';
import { EffectsModule } from '@ngrx/effects';
import { ModalEffects } from '../store/effects/app-effects';
import { StoreModule } from '@ngrx/store';
import { addCardModalReducer } from '../store/reducers/addcardmodal-reducer';



@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    AddCardModule,
    FormsModule
  ],
  exports: [
    ListComponent
  ]
})
export class ListModule { }
