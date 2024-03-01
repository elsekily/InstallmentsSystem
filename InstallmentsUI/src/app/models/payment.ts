
export interface payment {
  id: number;
  amount: number;
  monthNumber: number;
  date: Date;
  detials: string;
}

export interface savePayment {
  installmentId: number;
  amount: number;
  detials: string;
}
