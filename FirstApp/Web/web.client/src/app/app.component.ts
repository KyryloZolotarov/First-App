import { ChangeDetectorRef, Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from './auth/AuthProvider';
import { WorkDashboardComponent } from './work-dashboard/work-dashboard.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public isAuthenticated: boolean = false;
  historyPanelState: boolean = false;
  boardsAreAvailable: boolean = false;
  selectedBoardId!:number;
  constructor(private authService: AuthService) {}

  ngOnInit() {
    this.authService.checkAuth(); // Вызываем метод checkAuth() из сервиса AuthService
    this.authService.isAuthenticated$.subscribe(isAuthenticated => {
      this.isAuthenticated = isAuthenticated; // Обновляем значение isAuthenticated
    });
  }

  toggleAuth(): void {
    this.isAuthenticated = !this.isAuthenticated;
  }

  closePanel(): void {
    console.log("I'm trying to close panel");
    this.historyPanelState = false;
    console.log(this.historyPanelState);
  }

  onOpenPanel(): void {
    console.log(this.historyPanelState);
    this.historyPanelState = true;
  }

  setBoardsState(eventData: { id: number, flag: boolean }){
    this.boardsAreAvailable = eventData.flag;
    this.selectedBoardId = eventData.id;
  }

  title = 'web.client';
}
