import { Routes } from '@angular/router';
import { ProductComponent } from './platform/products/products.component';
import { ProductCreateComponent } from './platform/products/product-create/product-create.component';
import { ProductViewComponent } from './platform/products/product-view/product-view.component';
import { ProductUpdateComponent } from './platform/products/product-update/product-update.component';
import { CategoryComponent } from './platform/category/category.component';
import { ClientsComponent } from './platform/clients/clients.component';
import { DashboardComponent } from './platform/dashboard/dashboard.component';  // adjust path if needed
import { LoginComponent } from './authentication/login/login.component';

export const routes: Routes = [
  {path: 'login', component: LoginComponent},  // login route
  { path: 'platform/dashboard', component: DashboardComponent },      // dashboard route
  { path: 'platform/products', component: ProductComponent },
  { path: 'platform/products/create', component: ProductCreateComponent },
  { path: 'platform/products/edit/:id', component: ProductUpdateComponent },
  { path: 'platform/products/:id', component: ProductViewComponent },
  { path: 'platform/category', component: CategoryComponent },
  { path: 'platform/clients', component: ClientsComponent },
];
