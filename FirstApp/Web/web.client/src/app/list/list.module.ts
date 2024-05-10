import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list.component';
import { CardModule } from '../card/card.module';
import { AddCardModule } from '../add-card/add-card.module';
import { FormsModule } from '@angular/forms';



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
