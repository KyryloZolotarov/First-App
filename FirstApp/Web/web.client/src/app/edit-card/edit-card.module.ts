import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditCardComponent } from './edit-card.component';
import { FormsModule } from '@angular/forms';
import { HistoryComponent } from '../history/history.component';
import { HistoryModule } from '../history/history.module';



@NgModule({
  declarations: [
    EditCardComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HistoryModule
  ],
  exports: [
    EditCardComponent
  ]
})
export class EditCardModule { }
