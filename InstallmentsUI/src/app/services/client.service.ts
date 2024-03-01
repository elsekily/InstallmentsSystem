import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientSummary, ClientWithInstallments } from '../models/client';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ClientService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  create(client: ClientSummary) {
    return this.http.post<ClientSummary>(this.apiUrl+'api/client', client);
  }
  getClient(id: string | number) {
    return this.http.get<ClientWithInstallments>(this.apiUrl+'api/client/' + id);
  }
  getClients() {
    return this.http.get<ClientSummary[]>(this.apiUrl+'api/client');
  }
  update(client: ClientWithInstallments) {
    return this.http.put<ClientSummary>(this.apiUrl+'api/client/' + client.id, client);
  }
  delete(id: string | number) {
    return this.http.delete(this.apiUrl+'api/client/' + id);
  }
}
