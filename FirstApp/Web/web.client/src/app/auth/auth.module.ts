import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthComponent } from './auth.component';
import { AuthService } from '../auth/AuthProvider';
import { LoginModule } from '../login/login.module';
import { SignupModule } from '../signup/signup.module';



@NgModule({
  declarations: [
    AuthComponent
  ],
  imports: [
    CommonModule, LoginModule, SignupModule
  ],  
  providers: [
    AuthService
  ],
  exports: [
    AuthComponent
  ]
})
export class AuthModule { }
