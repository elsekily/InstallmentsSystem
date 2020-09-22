import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveClient } from '../models/client';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  constructor(private http: HttpClient) { }

  create(client) {
    return this.http.post<SaveClient>('/api/client', client);
  }
  getClient(id) {
    return this.http.get<SaveClient>('/api/client/' + id);
  }
  getClients() {
    return this.http.get<SaveClient[]>('/api/client');
  }
  update(client) {
    return this.http.put<SaveClient>('/api/client/' + client.id, client);
  }
  delete(id) {
    return this.http.delete('/api/client/' + id);
  }
}
