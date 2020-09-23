import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientSummary, ClientWithInstallments } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http: HttpClient) { }

  create(client) {
    return this.http.post<ClientSummary>('/api/client', client);
  }
  getClient(id) {
    return this.http.get<ClientWithInstallments>('/api/client/' + id);
  }
  getClients() {
    return this.http.get<ClientSummary[]>('/api/client');
  }
  update(client) {
    return this.http.put<ClientSummary>('/api/client/' + client.id, client);
  }
  delete(id) {
    return this.http.delete('/api/client/' + id);
  }
}
