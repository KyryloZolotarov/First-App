import { Component, OnInit } from '@angular/core';
import { AuthService } from './auth/AuthProvider';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public isAuthenticated: boolean = false;
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
  

  title = 'web.client';
}
