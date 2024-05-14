import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms'; // Import FormsModule
import { CommonModule } from '@angular/common';
import { AddCardComponent } from './add-card.component';




@NgModule({
  declarations: [
    AddCardComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    CommonModule
  ],
  exports: [
    AddCardComponent
  ]
})
export class AddCardModule { }
