import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardSettingsModule } from './board-settings/board-settings.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { InfraredSignalsModule } from './infrared-signals/infrared-signals.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    BoardSettingsModule,
    DashboardModule,
    InfraredSignalsModule
  ]
})
export class FeaturesModule { }
