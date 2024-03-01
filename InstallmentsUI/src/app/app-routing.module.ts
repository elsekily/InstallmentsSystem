import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ErrorComponent } from './components/error/error.component';
import { ClientListComponent } from './components/client-list/client-list.component';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { InstallmentFormComponent } from './components/installment-form/installment-form.component';
import { AuthGuard } from './services/AuthGuard.service';
import { LateinstallmentsComponent } from './components/lateinstallments/lateinstallments.component';
import { PaymentformComponent } from './components/paymentform/paymentform.component';


const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'error', component: ErrorComponent },
  { path: 'client', component: ClientListComponent, canActivate: [AuthGuard] },
  { path: 'client/new', component: ClientFormComponent, canActivate: [AuthGuard] },
  { path: 'client/:id', component: ClientFormComponent, canActivate: [AuthGuard] },
  { path: 'installment/new/:clientid', component: InstallmentFormComponent, canActivate: [AuthGuard] },
  { path: 'installment/:id', component: InstallmentFormComponent, canActivate: [AuthGuard] },
  { path: 'payment/:installmentid', component: PaymentformComponent, canActivate: [AuthGuard] },
  { path: 'lateinstallments', component: LateinstallmentsComponent, canActivate: [AuthGuard] },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }