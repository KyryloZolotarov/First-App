import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HistoryPanelComponent } from './history-panel.component';
import { HistoryModule } from '../history/history.module';



@NgModule({
  declarations: [
    HistoryPanelComponent
  ],
  imports: [
    CommonModule, HistoryModule
  ],
  exports: [
    HistoryPanelComponent
  ]
})
export class HistoryPanelModule { }
