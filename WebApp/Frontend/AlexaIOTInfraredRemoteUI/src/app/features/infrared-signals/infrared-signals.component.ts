import { Component, OnDestroy, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { InfraredSignalsService } from './infrared-signals.service';
import { InfraredSignal } from 'src/app/shared/models/infrared-signal';
import { SubscriptionsContainer } from 'src/app/shared/utils/subscription-container';

@Component({
  selector: 'app-infrared-signals',
  templateUrl: './infrared-signals.component.html',
  styleUrls: ['./infrared-signals.component.scss'],
})
export class InfraredSignalsComponent implements OnInit, OnDestroy {
  subscriptions = new SubscriptionsContainer();

  isInfraredDialogVisible = false;

  isDeleteInfraredSignalDialogVisible = false;

  isDeleteInfraredSignalsDialogVisible = false; // multiple signals dialog

  infraredSignals: InfraredSignal[] = [];

  infraredSignal: InfraredSignal = {} as InfraredSignal;

  selectedInfraredSignals: any[] = [];

  submitted = false;

  cols: any[] = [];

  outputs: any[] = [];

  rowsPerPageOptions = [5, 10, 20];

  constructor(
    private messageService: MessageService,
    private infraredSignalsService: InfraredSignalsService,
  ) {}

  ngOnInit() {
    this.loadSignals();

    this.cols = [
      { field: 'product', header: 'Product' },
      { field: 'price', header: 'Price' },
      { field: 'category', header: 'Category' },
      { field: 'rating', header: 'Reviews' },
      { field: 'inventoryStatus', header: 'Status' },
    ];

    this.outputs = [
      { label: 'Output1', value: 'output1' },
      { label: 'Output2', value: 'output2' },
      { label: 'Output3', value: 'output3' },
      { label: 'Output4', value: 'output4' },
    ];
  }

  ngOnDestroy() {
    this.subscriptions.dispose();
  }

  onNewClick() {
    this.infraredSignal = {} as InfraredSignal;
    this.submitted = false;
    this.isInfraredDialogVisible = true;
  }

  onDeleteClick() {
    this.isDeleteInfraredSignalsDialogVisible = true;
  }

  onEditInfraredSignalClick(infraredSignal: InfraredSignal) {
    this.infraredSignal = { ...infraredSignal };
    this.isInfraredDialogVisible = true;
  }

  onDeleteInfraredSignalClick(infraredSignal: InfraredSignal) {
    this.isDeleteInfraredSignalDialogVisible = true;
    // this.infraredSignal = { ...infraredSignal };
  }

  onConfirmDeleteMultipleInfraredSignalsClick() {
    this.isDeleteInfraredSignalsDialogVisible = false;
    this.infraredSignals = this.infraredSignals.filter(
      (val) => !this.selectedInfraredSignals.includes(val),
    );
    this.messageService.add({
      severity: 'success',
      summary: 'Successful',
      detail: 'Signals Deleted',
      life: 3000,
    });
    this.selectedInfraredSignals = [];
  }

  confirmDelete() {
    this.isDeleteInfraredSignalDialogVisible = false;
    // this.infraredSignals = this.infraredSignals.filter((val) => val.id !== this.product.id);
    this.messageService.add({
      severity: 'success',
      summary: 'Successful',
      detail: 'Signal Deleted',
      life: 3000,
    });
    this.infraredSignal = {} as InfraredSignal;
  }

  onHideInfraredDialogClick() {
    this.isInfraredDialogVisible = false;
    this.submitted = false;
  }

  onSaveInfraredSignalClick() {
    //
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  private loadSignals() {
    this.subscriptions.add(
      this.infraredSignalsService.getInfraredSignals().subscribe({
        next: (infraredSignals) => {
          this.infraredSignals = infraredSignals;
        },
        error: (error) => {
          const message = this.getErrorMessage(error);

          this.messageService.add({
            severity: 'error',
            summary: 'Error',
            detail: message,
            life: 3000,
          });
        },
      }),
    );
  }

  private getErrorMessage(error: any): string {
    if (error.status === 401) {
      return 'You are not logged in.';
    } else if (error.status === 0){
      return 'Server error.'
    }
    return 'Unknown error.';
  }
}
