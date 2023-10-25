import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AppTopBarComponent } from './components/topbar/app.topbar.component';
import { AppSidebarComponent } from './components/sidebar/app.sidebar.component';
import { AppFooterComponent } from './components/footer/app.footer.component';
import { AppMenuComponent } from './components/menu/app.menu.component';
import { AppMenuitemComponent } from './components/menu/menu-item/app.menuitem.component';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppTopBarComponent,
    AppSidebarComponent,
    AppFooterComponent,
    AppMenuComponent,
    AppMenuitemComponent,
  ],
  imports: [CommonModule, RouterModule],
  exports: [
    AppTopBarComponent,
    AppSidebarComponent,
    AppFooterComponent,
    AppMenuComponent,
  ],
})
export class CoreModule {}
