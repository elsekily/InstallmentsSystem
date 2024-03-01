import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ClientSummary, ClientWithInstallments } from '../models/client';
import { Installment } from '../models/installment';
import { savePayment } from '../models/payment';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PaymentService {
  
  apiUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  create(payment: savePayment) {
    return this.http.post<Installment>(this.apiUrl+'api/payment', payment);
  }
  delete(id: string | number) {
    return this.http.delete(this.apiUrl+'api/payment/' + id);
  }
}
