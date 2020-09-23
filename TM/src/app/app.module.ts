import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SectionRegisterComponent } from './sections/section-register/section-register.component';
import { SectionOverviewComponent } from './sections/section-overview/section-overview.component';
import { appRoutes } from 'src/routes';
import { SectionAddCustomerComponent } from './sections/section-add-customer/section-add-customer.component';
import { SectionAddProjectComponent } from './sections/section-add-project/section-add-project.component';
import { ReactiveFormsModule } from '@angular/forms';
import { DBAccessService } from './services/dbaccess.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    SectionRegisterComponent,
    SectionOverviewComponent,
    SectionAddCustomerComponent,
    SectionAddProjectComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule,
    HttpClientModule
  ],
  providers: [
    DBAccessService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
