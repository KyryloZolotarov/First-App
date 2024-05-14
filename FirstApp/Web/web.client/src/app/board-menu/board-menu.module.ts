import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardMenuComponent } from './board-menu.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    BoardMenuComponent
  ],
  imports: [
    CommonModule, FormsModule
  ],
  exports: [
    BoardMenuComponent
  ]
})
export class BoardMenuModule { }
