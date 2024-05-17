import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { AuthService } from '../auth/AuthProvider';



@NgModule({
  declarations: [
    LoginComponent
  ],
  imports: [
    CommonModule
  ],  
  providers: [
    AuthService
  ],
  exports: [
    LoginComponent
  ]
})
export class LoginModule { }
