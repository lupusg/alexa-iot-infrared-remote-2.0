import { OnInit } from '@angular/core';
import { Component } from '@angular/core';
import { LayoutService } from '../../../app.service';

@Component({
    selector: 'app-menu',
    templateUrl: './app.menu.component.html'
})
export class AppMenuComponent implements OnInit {

    model: any[] = [];

    constructor(public layoutService: LayoutService) { }

    ngOnInit() {
        this.model = [
            {
                label: 'Home',
                items: [
                    { label: 'Dashboard', icon: 'pi pi-fw pi-home', routerLink: ['/'] },
                ],
            },
            {
                label: 'Infrared Signals Manager',
                items: [
                    { label: 'Your Infrared Signals', icon: 'pi pi-fw pi-wifi', routerLink: ['/infrared-signals'] },
                    { label: 'Board Settings', icon: 'pi pi-fw pi-cog', routerLink: ['/board-settings'] }
                ]
            }
        ];
    }
}
