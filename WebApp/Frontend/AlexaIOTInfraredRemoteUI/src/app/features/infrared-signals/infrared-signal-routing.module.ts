import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InfraredSignalsComponent } from './infrared-signals.component';

const routes: Routes = [
  {
    path: '', component: InfraredSignalsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class InfraredSignalRoutingModule { }
