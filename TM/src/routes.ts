import { Routes } from '@angular/router';
import { SectionAddCustomerComponent } from './app/sections/section-add-customer/section-add-customer.component';
import { SectionAddProjectComponent } from './app/sections/section-add-project/section-add-project.component';
import { SectionOverviewComponent } from './app/sections/section-overview/section-overview.component';
import { SectionRegisterComponent } from './app/sections/section-register/section-register.component';

export const appRoutes: Routes = [
{ path: 'overview', component: SectionOverviewComponent },
{ path: 'register', component: SectionRegisterComponent },
{ path: 'add-customer', component: SectionAddCustomerComponent },
{ path: 'add-project', component: SectionAddProjectComponent },
{ path: '', redirectTo: '/overview', pathMatch: 'full' }

];