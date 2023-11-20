import { Injectable } from '@angular/core';
import { InfraredSignal } from 'src/app/shared/models/infrared-signal';

@Injectable({
  providedIn: 'root',
})
export class InfraredSignalsService {
  getInfraredSignals(): InfraredSignal[] {
    const result: InfraredSignal[] = [];
  
    for (let i = 0; i < 50; ++i) {
      const date = new Date();
      date.setDate(date.getDate() + i);
  
      const infraredSignal: InfraredSignal = {
        description: 'Signal' + (i + 1),
        infraredData: 'Data' + (i + 1),
        irSignalOutput: 'Output' + (i + 1),
        createdAt: date,
      };
      result.push(infraredSignal);
    }
  
    return result;
  }
}
