import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CookieService } from 'ngx-cookie-service';
import { AuthModule } from './auth/auth.module';
import { AuthComponent } from './auth/auth.component';
import axios from 'axios';
import { WorkDashboardModule } from './work-dashboard/work-dashboard.module';
import { HistoryPanelModule } from './history-panel/history-panel.module';

axios.defaults.withCredentials = true;

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    WorkDashboardModule, AuthModule, HistoryPanelModule
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
