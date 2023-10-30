import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './features/dashboard/dashboard.component';
import { InfraredSignalsComponent } from './features/infrared-signals/infrared-signals.component';
import { BoardSettingsComponent } from './features/board-settings/board-settings.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
  },
  {
    path: 'infrared-signals',
    component: InfraredSignalsComponent,
  },
  {
    path: 'board-settings',
    component: BoardSettingsComponent

  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
