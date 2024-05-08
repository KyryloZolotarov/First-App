import { Component, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../auth/AuthProvider';
import { ILogin } from '../interfaces/login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  @Output() signUpEvent = new EventEmitter<boolean>();
  constructor(private authService: AuthService) {}

  async login(email: string, password: string, event: Event): Promise<void> {
    event.preventDefault();
    console.log(email);
    let loginData: ILogin = { Email: email, Password: password };
  
    await this.authService.login(loginData);
  }
  setSignedUp(signUp: boolean){
    this.signUpEvent.emit(signUp);
  }
}
