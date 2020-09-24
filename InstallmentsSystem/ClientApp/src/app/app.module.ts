import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { HomeComponent } from './components/home/home.component';
import { ClientFormComponent } from './components/client-form/client-form.component';
import { ClientService } from './services/client.service';
import { ClientListComponent } from './components/client-list/client-list.component';
import { InstallmentFormComponent } from './components/installment-form/installment-form.component';
import { InstallmentService } from './services/installment.service';
import { ErrorComponent } from './components/error/error.component';
import { PaymentformComponent } from './components/paymentform/paymentform.component';
import { PaymentService } from './services/payment.service';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClientFormComponent,
    ClientListComponent,
    InstallmentFormComponent,
    ErrorComponent,
    PaymentformComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'error', component: ErrorComponent },
      { path: 'client', component: ClientListComponent },
      { path: 'client/new', component: ClientFormComponent },
      { path: 'client/:id', component: ClientFormComponent },
      { path: 'installment/new/:clientid', component: InstallmentFormComponent },
      { path: 'installment/:id', component: InstallmentFormComponent },
      { path: 'payment/:installmentid', component: PaymentformComponent },
    ])
  ],
  providers: [
    ClientService,
    InstallmentService,
    PaymentService,
    AuthService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
