import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SaveInstallment, Installment, InstallmentSummary, IdDatePair } from '../models/installment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class InstallmentService {
  apiUrl = environment.apiUrl;
  constructor(private http: HttpClient) { }

  create(installment: SaveInstallment) {
    console.log(installment);
    return this.http.post<Installment>(this.apiUrl+'api/installment', installment);
  }
  getinstallment(id: string | number) {
    return this.http.get<Installment>(this.apiUrl+'api/installment/' + id);
  }
  getInstallments() {
    return this.http.get<InstallmentSummary[]>(this.apiUrl+'api/installment');
  }
  getLateInstallments() {
    return this.http.get<InstallmentSummary[]>(this.apiUrl+'api/installment/late');
  }
  update(id: string | number, installment: SaveInstallment) {
    return this.http.put<Installment>(this.apiUrl+'api/installment/' + id, installment);
  }
  updateNextPayment(idDatePair: IdDatePair) {
    return this.http.put<Installment>(this.apiUrl+'api/installment/nextpayment/' + idDatePair.id, idDatePair);
  }
  delete(id: string | number) {
    return this.http.delete(this.apiUrl+'api/installment/' + id);
  }
}
