import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { Board } from 'src/app/shared/models/board';
import { BoardService } from './board.service';
import { SubscriptionsContainer } from 'src/app/shared/utils/subscription-container';

@Component({
	selector: 'app-board-settings',
	templateUrl: './board-settings.component.html',
	styleUrls: ['./board-settings.component.scss'],
})
export class BoardSettingsComponent implements OnInit {
	subscriptions = new SubscriptionsContainer();

	addBoardDialog = false;

	deleteBoardDialog = false;

	showSecret = false;

	boards: Board[] = [];

	board: Board = {} as Board;

	addBoardSubmitted = false;

	cols: any[] = [];

	rowsPerPageOptions = [5, 10, 20];

	constructor(
		private messageService: MessageService,
		private boardService: BoardService,
	) {}

	ngOnInit() {
		this.loadBoards();
	}

	onNewBoardButtonClick() {
		this.board = {} as Board;
		this.addBoardSubmitted = false;
		this.addBoardDialog = true;
	}

	deleteBoard(board: Board) {
		this.deleteBoardDialog = true;
		this.board = board;
	}

	confirmDeleteBoard() {
		this.deleteBoardDialog = false;

		this.subscriptions.add(
			this.boardService.deleteBoard(this.board.name).subscribe({
				complete: () => {
					this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Board Deleted', life: 3000 });
					this.boards = this.boards.filter((val) => val.name !== this.board.name);
					this.board = {} as Board;
				},
				error: () => {
					this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Deleting board', life: 3000 });
				},
			}),
		);
	}

	onCancelButtonClick() {
		this.addBoardDialog = false;
		this.addBoardSubmitted = false;
	}

	onSaveBoardButtonClick() {
		this.subscriptions.add(
			this.boardService.addBoard(this.board.name, this.board.secret).subscribe((board) => {
				this.boards.push(board);
				this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Board added', life: 3000 });
			}),
		);
		this.addBoardDialog = false;
	}

	private loadBoards() {
		this.subscriptions.add(
			this.boardService.getBoards().subscribe({
				next: (boards) => {
					this.boards = boards;
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
