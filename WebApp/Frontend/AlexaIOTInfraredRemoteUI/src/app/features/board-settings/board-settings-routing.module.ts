import { NgModule } from '@angular/core';
import { BoardSettingsComponent } from './board-settings.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '', component: BoardSettingsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BoardSettingsRoutingModule { }
