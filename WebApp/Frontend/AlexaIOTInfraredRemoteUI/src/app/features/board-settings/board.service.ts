import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Board } from 'src/app/shared/models/board';
import { environment } from 'src/environments/environment.development';

@Injectable({
	providedIn: 'root',
})
export class BoardService {
	apiUrl = environment.apiUrl + '/api/user/board';
	authzApiUrl = environment.authServerUrl + '/api/user/board';

	constructor(private http: HttpClient) {}

	getBoards(): Observable<Board[]> {
		return this.http.get<Board[]>(this.apiUrl);
	}

	addBoard(boardName: string, boardSecret: string): Observable<Board> {
		return this.http.post<Board>(this.authzApiUrl, { name: boardName, secret: boardSecret });
	}

	deleteBoard(boardName: string) {
		return this.http.delete(this.authzApiUrl, { params: { boardName } });
	}
}
