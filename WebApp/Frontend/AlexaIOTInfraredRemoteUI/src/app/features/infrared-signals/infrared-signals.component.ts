import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Table } from 'primeng/table';
import { InfraredSignalsService } from './infrared-signals.service';
import { InfraredSignal } from 'src/app/shared/models/infrared-signal';

@Component({
  selector: 'app-infrared-signals',
  templateUrl: './infrared-signals.component.html',
  styleUrls: ['./infrared-signals.component.scss'],
})
export class InfraredSignalsComponent implements OnInit {
  productDialog = false;

  deleteProductDialog = false;

  deleteProductsDialog = false;

  infraredSignals: InfraredSignal[] = [];

  product: any = {};

  selectedInfraredSignals: any[] = [];

  submitted = false;

  cols: any[] = [];

  statuses: any[] = [];

  rowsPerPageOptions = [5, 10, 20];

  constructor(
    // private productService: ProductService,
    private messageService: MessageService,
    private infraredSignalsService: InfraredSignalsService
  ) {}

  ngOnInit() {
    // this.productService.getProducts().then((data) => (this.products = data));
    this.infraredSignals = this.infraredSignalsService.getInfraredSignals();

    this.cols = [
      { field: 'product', header: 'Product' },
      { field: 'price', header: 'Price' },
      { field: 'category', header: 'Category' },
      { field: 'rating', header: 'Reviews' },
      { field: 'inventoryStatus', header: 'Status' },
    ];

    this.statuses = [
      { label: 'INSTOCK', value: 'instock' },
      { label: 'LOWSTOCK', value: 'lowstock' },
      { label: 'OUTOFSTOCK', value: 'outofstock' },
    ];
  }

  onNewClick() {
    this.product = {};
    this.submitted = false;
    this.productDialog = true;
  }

  onDeleteClick() {
    this.deleteProductsDialog = true;
  }

  onEditInfraredSignalClick(product: any) {
    this.product = { ...product };
    this.productDialog = true;
  }

  onDeleteInfraredSignalClick(product: any) {
    this.deleteProductDialog = true;
    this.product = { ...product };
  }

  confirmDeleteSelected() {
    this.deleteProductsDialog = false;
    this.infraredSignals = this.infraredSignals.filter(
      (val) => !this.selectedInfraredSignals.includes(val),
    );
    this.messageService.add({
      severity: 'success',
      summary: 'Successful',
      detail: 'Products Deleted',
      life: 3000,
    });
    this.selectedInfraredSignals = [];
  }

  confirmDelete() {
    this.deleteProductDialog = false;
    // this.infraredSignals = this.infraredSignals.filter((val) => val.id !== this.product.id);
    this.messageService.add({
      severity: 'success',
      summary: 'Successful',
      detail: 'Product Deleted',
      life: 3000,
    });
    this.product = {};
  }

  hideDialog() {
    this.productDialog = false;
    this.submitted = false;
  }

  saveProduct() {
    this.submitted = true;

    if (this.product.name?.trim()) {
      if (this.product.id) {
        this.product.inventoryStatus = this.product.inventoryStatus.value
          ? this.product.inventoryStatus.value
          : this.product.inventoryStatus;
        this.infraredSignals[this.findIndexById(this.product.id)] = this.product;
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Product Updated',
          life: 3000,
        });
      } else {
        this.product.id = this.createId();
        this.product.code = this.createId();
        this.product.image = 'product-placeholder.svg';
        this.product.inventoryStatus = this.product.inventoryStatus
          ? this.product.inventoryStatus.value
          : 'INSTOCK';
        this.infraredSignals.push(this.product);
        this.messageService.add({
          severity: 'success',
          summary: 'Successful',
          detail: 'Product Created',
          life: 3000,
        });
      }

      this.infraredSignals = [...this.infraredSignals];
      this.productDialog = false;
      this.product = {};
    }
  }

  findIndexById(id: string): number {
    // let index = -1;
    // for (let i = 0; i < this.infraredSignals.length; i++) {
    //   if (this.infraredSignals[i].id === id) {
    //     index = i;
    //     break;
    //   }
    // }

    return -1;
  }

  createId(): string {
    let id = '';
    const chars =
      'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (let i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }

  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }
}
