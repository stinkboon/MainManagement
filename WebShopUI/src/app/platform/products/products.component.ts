import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-products',
  imports: [CommonModule, RouterModule, MatButtonModule, MatIconModule,],
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductComponent {
  public products = [
    { id: 1, name: 'Product 1', price: 100, category: { name: 'Category 1'}, description: 'Description of Product 1', stock: 10 },
    { id: 2, name: 'Product 2', price: 200, category: { name: 'Category 2'}, description: 'Description of Product 2', stock: 5 },
    { id: 3, name: 'Product 3', price: 300, category: { name: 'Category 3'}, description: 'Description of Product 3', stock: 3 },
    { id: 4, name: 'Product 4', price: 400, category: { name: 'Category 4'}, description: 'Description of Product 4', stock: 15 },

  ];


  public deleteProduct(productId: number): void {
    console.log(`Deleting product with ID: ${productId}`);
  }
}
