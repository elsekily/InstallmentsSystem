import { InstallmentSummary } from "./installment";


export interface ClientSummary {
  id: number;
  name: string;
  nationalId: string;
  mobileNumber: string;
}
export interface ClientWithInstallments {
  id: number;
  name: string;
  nationalId: string;
  mobileNumber: string;
  installments: InstallmentSummary[];
}
