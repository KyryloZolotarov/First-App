import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkDashboardComponent } from './work-dashboard.component';
import { ListComponent } from '../list/list.component';
import { ListModule } from '../list/list.module';
import { AddCardModule } from '../add-card/add-card.module';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    WorkDashboardComponent
  ],
  imports: [
    CommonModule, ListModule, FormsModule
  ],
  exports: [
    WorkDashboardComponent
  ]
})
export class WorkDashboardModule { }
