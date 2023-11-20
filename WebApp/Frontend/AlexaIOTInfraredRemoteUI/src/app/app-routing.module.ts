import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    loadChildren: () => import('./features/dashboard/dashboard.module').then(m => m.DashboardModule),
  },
  {
    path: 'infrared-signals',
    loadChildren: () => import('./features/infrared-signals/infrared-signals.module').then(m => m.InfraredSignalsModule),
  },
  {
    path: 'board-settings',
    loadChildren: () => import('./features/board-settings/board-settings.module').then(m => m.BoardSettingsModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
