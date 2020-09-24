import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientSummary, ClientWithInstallments } from '../models/client';
import { Installment } from '../models/installment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {

  constructor(private http: HttpClient) { }

  create(payment) {
    return this.http.post<Installment>('/api/payment', payment);
  }
  delete(id) {
    return this.http.delete('/api/payment/' + id);
  }
}
