import { Routes } from '@angular/router';

import { DashboardComponent } from './platform/dashboard/dashboard.component';
import { LoginComponent } from './authentication/login/login.component';
import { CategoryComponent } from './platform/category/category.component';

// Products
import { ProductComponent } from './platform/products/products.component';
import { ProductCreateComponent } from './platform/products/product-create/product-create.component';
import { ProductViewComponent } from './platform/products/product-view/product-view.component';
import { ProductUpdateComponent } from './platform/products/product-update/product-update.component';

// Clients
import { CustomerComponent } from './platform/clients/clients.component';
import CustomerCreateComponent from './platform/clients/client-create/client-create.component';
import { CustomerUpdateComponent } from './platform/clients/client-update/client-update.component';
import { CustomerViewComponent } from './platform/clients/client-view/client-view.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },

  { path: 'platform/dashboard', component: DashboardComponent },

  { path: 'platform/category', component: CategoryComponent },

  {
    path: 'platform/products',
    children: [
      { path: '', component: ProductComponent },
      { path: 'create', component: ProductCreateComponent },
      { path: 'edit/:id', component: ProductUpdateComponent },
      { path: ':id', component: ProductViewComponent }
    ]
  },

  {
    path: 'platform/clients',
    children: [
      { path: '', component: CustomerComponent },
      { path: 'create', component: CustomerCreateComponent },
      { path: 'edit/:id', component: CustomerUpdateComponent },
      { path: ':id', component: CustomerViewComponent }
    ]
  },

  { path: '**', redirectTo: 'platform/dashboard' }
];
