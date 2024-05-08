import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list.component';
import { CardModule } from '../card/card.module';
import { AddCardModule } from '../add-card/add-card.module';



@NgModule({
  declarations: [
    ListComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    AddCardModule
  ],
  exports: [
    ListComponent
  ]
})
export class ListModule { }
