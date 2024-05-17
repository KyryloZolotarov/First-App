import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CardComponent } from './card.component';
import { EditCardModule } from '../edit-card/edit-card.module';



@NgModule({
  declarations: [
    CardComponent
  ],
  imports: [
    CommonModule, EditCardModule
  ],
  exports: [
    CardComponent
  ]
})
export class CardModule { }
