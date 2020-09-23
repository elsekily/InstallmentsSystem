import { Data } from "@angular/router";


export interface InstallmentSummary {
  id: number;
  deviceName: string;
  clientName: string;
  paymentScheme: number;
  remaining: string;
  MontlyPayment: number;
  nextPayment: Date;
}

export interface Installment implements InstallmentSummary {
  StartDate: Date;
  DeviceActualPrice: number;
  DevicePrice: number;
  FirstInstallment: number;
  paymentScheme: number;
  MontlyPayment: number;
  DayofPayment: number;
  ClientId: number;
}
