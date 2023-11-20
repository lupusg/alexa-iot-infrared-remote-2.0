import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BoardSettingsComponent } from './board-settings.component';
import { BoardSettingsRoutingModule } from './board-settings-routing.module';



@NgModule({
  declarations: [
    BoardSettingsComponent
  ],
  imports: [
    CommonModule,
    BoardSettingsRoutingModule
  ]
})
export class BoardSettingsModule { }
