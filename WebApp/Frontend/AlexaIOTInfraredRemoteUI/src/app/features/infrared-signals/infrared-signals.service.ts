import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { InfraredSignal } from 'src/app/shared/models/infrared-signal';
import { environment } from 'src/environments/environment.development';

@Injectable({
	providedIn: 'root',
})
export class InfraredSignalsService {
	baseUrl = environment.apiUrl + '/api/infrared/signals';
	constructor(private http: HttpClient) {}

	getInfraredSignals(): Observable<InfraredSignal[]> {
		return this.http.get<InfraredSignal[]>(this.baseUrl);
	}

	updateInfraredSignal(infraredSignal: InfraredSignal): Observable<InfraredSignal> {
		return this.http.put<InfraredSignal>(this.baseUrl, infraredSignal);
	}

	deleteInfraredSignal(infraredSignal: InfraredSignal): Observable<void> {
		return this.http.delete<void>(this.baseUrl, { body: infraredSignal });
	}
}
