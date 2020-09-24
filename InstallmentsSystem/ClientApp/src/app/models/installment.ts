import { payment } from "./payment";

export interface InstallmentSummary {
  id: number;
  deviceName: string;
  clientName: string;
  paymentScheme: number;
  remaining: string;
  montlyPayment: number;
  nextPayment: Date;
}

export interface Installment {
  id: number;
  deviceName: string;
  remaining: number;
  nextPayment: Date;
  startDate: Date;
  deviceActualPrice: number;
  devicePrice: number;
  firstInstallment: number;
  paymentScheme: number;
  montlyPayment: number;
  dayofPayment: number;
  clientId: number;
  clientName: string;
  payments: payment[];
}

export interface SaveInstallment {
  deviceName: string;
  deviceActualPrice: number;
  paymentScheme: number;
  devicePrice: number;
  firstInstallment: number;
  montlyPayment: number;
  dayofPayment: number;
  clientId: number;
}

export interface IdDatePair {
  id: number;
  Date: Date;
}
