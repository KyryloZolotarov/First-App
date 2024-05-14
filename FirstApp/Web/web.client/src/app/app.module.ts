import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { CookieService } from 'ngx-cookie-service';
import { AuthModule } from './auth/auth.module';
import axios from 'axios';
import { WorkDashboardModule } from './work-dashboard/work-dashboard.module';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { HistoryPanelModule } from './history-panel/history-panel.module';
import { HeaderModule } from './header/header.module';
import { BoardMenuModule } from './board-menu/board-menu.module';
import { rootReducer } from './store/reducers/app-reducer';
import { ListEffects } from './store/effects/list-effects';
import { listReducer } from './store/reducers/list-reducer';

axios.defaults.withCredentials = true;

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule, HttpClientModule,
    WorkDashboardModule, AuthModule, HistoryPanelModule,
    HeaderModule,
    BoardMenuModule,
    StoreModule.forRoot(rootReducer),
    EffectsModule.forRoot([ListEffects])
  ],
  providers: [CookieService],
  bootstrap: [AppComponent]
})
export class AppModule { }
