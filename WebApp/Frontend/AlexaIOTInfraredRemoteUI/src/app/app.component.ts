import { Component, OnInit } from '@angular/core';

import { LoginResponse, OidcSecurityService } from 'angular-auth-oidc-client';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  title = 'AlexaIOTInfraredRemoteUI';

  constructor(
    private oidcSecurityService: OidcSecurityService,
    private primengConfig: PrimeNGConfig,
  ) {}

  ngOnInit() {
    this.initOidcSecurityService();
    this.initPrimeNGConfig();
  }

  private initOidcSecurityService() {
    this.oidcSecurityService
      .checkAuth()
      .subscribe((loginResponse: LoginResponse) => {
        const { isAuthenticated, userData, accessToken, idToken, configId } =
          loginResponse;

        /*...*/
      });
  }

  private initPrimeNGConfig() {
    this.primengConfig.ripple = true;
  }

  login() {
    this.oidcSecurityService.authorize();
  }

  logout() {
    this.oidcSecurityService
      .logoff()
      .subscribe((result) => console.log(result));
  }
}
