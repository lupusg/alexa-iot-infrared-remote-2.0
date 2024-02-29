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

	isInfraredEditDialogVisible = false;

	isDeleteInfraredSignalDialogVisible = false;

	isDeleteInfraredSignalsDialogVisible = false; // multiple signals dialog

	infraredSignals: InfraredSignal[] = [];

	infraredSignal: InfraredSignal = {} as InfraredSignal;

	selectedInfraredSignals: any[] = [];

	outputs: any[] = [];

	rowsPerPageOptions = [5, 10, 20];

	constructor(
		private messageService: MessageService,
		private infraredSignalsService: InfraredSignalsService,
	) {}

	ngOnInit() {
		this.loadSignals();

		this.outputs = [{ label: '1' }, { label: '2' }, { label: '3' }, { label: '4' }];
	}

	ngOnDestroy() {
		this.subscriptions.dispose();
	}

	onDeleteInfraredSignalClick(infraredSignal: InfraredSignal) {
		this.isDeleteInfraredSignalDialogVisible = true;
		this.infraredSignal = { ...infraredSignal };
	}

	onConfirmDeleteInfraredSignalClick() {
		this.subscriptions.add(
			this.infraredSignalsService.deleteInfraredSignal(this.infraredSignal).subscribe({
				error: (err) => {
					this.messageService.add({
						severity: 'error',
						summary: 'Error',
						detail: 'Deleting Infrared Signal',
						life: 3000,
					});
				},
				complete: () => {
					this.messageService.add({
						severity: 'success',
						summary: 'Successful',
						detail: 'Infrared Signal deleted',
						life: 3000,
					});

					this.infraredSignals = this.infraredSignals.filter((val) => val.id !== this.infraredSignal.id);
					this.infraredSignal = {} as InfraredSignal;
				},
			}),
		);

		this.isDeleteInfraredSignalDialogVisible = false;
	}

	onDeleteMultipleInfraredSignalsClick() {
		// not implemented yet
		// this.isDeleteInfraredSignalsDialogVisible = true;
	}

	onConfirmDeleteMultipleInfraredSignalsClick() {
		// not implemented yet
		// this.isDeleteInfraredSignalsDialogVisible = false;
		// this.infraredSignals = this.infraredSignals.filter((val) => !this.selectedInfraredSignals.includes(val));
		// this.messageService.add({
		// 	severity: 'success',
		// 	summary: 'Successful',
		// 	detail: 'Signals Deleted',
		// 	life: 3000,
		// });
		// this.selectedInfraredSignals = [];
	}

	onEditInfraredSignalClick(infraredSignal: InfraredSignal) {
		this.infraredSignal = { ...infraredSignal };
		this.isInfraredEditDialogVisible = true;
	}

	onSaveEditInfraredSignalClick() {
		this.subscriptions.add(
			this.infraredSignalsService.updateInfraredSignal(this.infraredSignal).subscribe({
				error: (err) => {
					let detailMessage = 'Updating infrared signal.';

					if (err.status === 409) detailMessage = err.error;

					this.messageService.add({
						severity: 'error',
						summary: 'Error',
						detail: detailMessage,
						life: 3000,
					});
				},
				complete: () => {
					this.messageService.add({
						severity: 'success',
						summary: 'Successful',
						detail: 'Infrared signal updated',
						life: 3000,
					});

					const index = this.infraredSignals.findIndex((signal) => signal.id === this.infraredSignal.id);
					if (index !== -1) {
						this.infraredSignals[index] = this.infraredSignal;
					}
				},
			}),
		);
		this.isInfraredEditDialogVisible = false;
	}

	onHideInfraredDialogClick() {
		this.isInfraredEditDialogVisible = false;
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
		} else if (error.status === 0) {
			return 'Server error.';
		}
		return 'Unknown error.';
	}
}
