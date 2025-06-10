import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ProductViewModel } from '../../core/datacontracts/ProductViewModel';
import { ProductService } from '../../core/services/product.service';

@Component({
  selector: 'app-products',
  imports: [
    CommonModule,
    RouterModule,
    MatButtonModule,
    MatIconModule,
  ],
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductComponent implements OnInit {
  public products: ProductViewModel[] = [];
  
  constructor(private _productService: ProductService) { }

  public ngOnInit(): void {
    this.getProducts();
  }

  public getProducts(): void {
    this._productService.getAll().subscribe({
      next: (receivedProducts) => {
        this.products = receivedProducts;
      },
      error: (err) => {
        console.error('Error fetching products:', err);
      }
    });
  }

  public deleteProduct(productId: number): void {
    this._productService.delete(productId).subscribe({
      next: () => {
        this.products = this.products.filter(product => product.id !== productId);
      },
      error: (err) => {
        console.error('Error deleting product:', err);
      }
    });
  }
}