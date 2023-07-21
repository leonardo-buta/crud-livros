import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { AlertComponent } from './components';
import { HomeComponent } from './home';
import { AppRoutingModule } from './app-routing.module';
import { AuthInterceptor } from './shared/authconfig.interceptor';
import { SigninComponent } from './signin/signin.component';
import { JWT_OPTIONS, JwtHelperService } from '@auth0/angular-jwt';

@NgModule({
  declarations: [
    AppComponent,
    AlertComponent,
    HomeComponent,
    SigninComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    },
    { 
      provide: JWT_OPTIONS,
      useValue: JWT_OPTIONS
    },
    JwtHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
