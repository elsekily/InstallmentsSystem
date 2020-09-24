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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClientFormComponent,
    ClientListComponent,
    InstallmentFormComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'client', component: ClientListComponent },
      { path: 'client/new', component: ClientFormComponent },
      { path: 'client/:id', component: ClientFormComponent },
      { path: 'installment/new/:clientid', component: InstallmentFormComponent },
      { path: 'installment/:id', component: InstallmentFormComponent },
    ])
  ],
  providers: [
    ClientService,
    InstallmentService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
