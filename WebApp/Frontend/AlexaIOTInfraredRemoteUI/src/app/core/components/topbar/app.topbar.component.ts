import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { LayoutService } from '../../../app.service';
import { OidcSecurityService, UserDataResult } from 'angular-auth-oidc-client';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-topbar',
  templateUrl: './app.topbar.component.html',
  styleUrls: ['./app.topbar.component.scss']
})
export class AppTopBarComponent implements OnInit {
  items!: MenuItem[];
  userData$!: Observable<UserDataResult>;

  @ViewChild('menubutton') menuButton!: ElementRef;

  @ViewChild('topbarmenubutton') topbarMenuButton!: ElementRef;

  @ViewChild('topbarmenu') menu!: ElementRef;

  constructor(
    public layoutService: LayoutService,
    private oidcSecurityService: OidcSecurityService,
  ) {}

  ngOnInit(): void {
    this.userData$ = this.oidcSecurityService.userData$;
    this.userData$.subscribe(val => console.log(val));
  }

  public login(): void {
    this.oidcSecurityService.authorize();
    this.oidcSecurityService.userData$;
  }

  public logout(): void {
    this.oidcSecurityService.logoff().subscribe();
  }
}
