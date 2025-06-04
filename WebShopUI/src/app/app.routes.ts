import { Routes } from '@angular/router';
import { ProductComponent } from './platform/products/products.component';
import { ClientsComponent } from './platform/clients/clients.component';
import { CategoryComponent } from './platform/category/category.component';

export const routes: Routes = [
  {  path:  'products' , component: ProductComponent },
  { path: 'clients', component: ClientsComponent },
  { path: 'category', component: CategoryComponent},
];

