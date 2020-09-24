import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveInstallment, Installment, InstallmentSummary, IdDatePair } from '../models/installment';

@Injectable({
  providedIn: 'root'
})
export class InstallmentService {

  constructor(private http: HttpClient) { }

  create(installment) {
    console.log(installment);
    return this.http.post<Installment>('/api/installment', installment);
  }
  getinstallment(id) {
    return this.http.get<Installment>('/api/installment/' + id);
  }
  getInstallments() {
    return this.http.get<InstallmentSummary[]>('/api/installment');
  }
  update(id, installment: SaveInstallment) {
    return this.http.put<Installment>('/api/installment/' + id, installment);
  }
  updateNextPayment(idDatePair) {
    return this.http.put<Installment>('/api/installment/nextpayment/' + idDatePair.id, idDatePair);
  }
  delete(id) {
    return this.http.delete('/api/installment/' + id);
  }
}
