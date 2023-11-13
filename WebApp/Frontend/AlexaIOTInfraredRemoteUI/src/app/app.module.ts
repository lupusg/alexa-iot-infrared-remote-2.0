import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ButtonModule } from 'primeng/button';

import {
  AuthInterceptor,
  AuthModule,
  LogLevel,
} from 'angular-auth-oidc-client';

import { environment } from 'src/environments/environment.development';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FeaturesModule } from './features/features.module';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { FormsModule } from '@angular/forms';
import { InputTextModule } from 'primeng/inputtext';
import { SidebarModule } from 'primeng/sidebar';
import { BadgeModule } from 'primeng/badge';
import { RadioButtonModule } from 'primeng/radiobutton';
import { InputSwitchModule } from 'primeng/inputswitch';
import { RippleModule } from 'primeng/ripple';
import { RouterModule } from '@angular/router';
import { AppConfigModule } from './core/components/config/config.module';

@NgModule({
  declarations: [AppComponent],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    AuthModule.forRoot({
      config: {
        authority: environment.authServerUrl,
        redirectUrl: window.location.origin,
        postLogoutRedirectUri: window.location.origin,
        clientId: environment.oidcClientId,
        scope: 'openid profile roles email dataAIIR offline_access',
        responseType: 'code',
        silentRenew: true,
        ignoreNonceAfterRefresh: true, // this is required if the id_token is not returned
        useRefreshToken: true,
        logLevel: LogLevel.Debug,
        secureRoutes: [environment.apiUrl],
      },
    }),
    ButtonModule,
    SharedModule,
    CoreModule,
    FeaturesModule,
    FormsModule,
    InputTextModule,
    SidebarModule,
    BadgeModule,
    RadioButtonModule,
    InputSwitchModule,
    RippleModule,
    RouterModule,
    AppConfigModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
