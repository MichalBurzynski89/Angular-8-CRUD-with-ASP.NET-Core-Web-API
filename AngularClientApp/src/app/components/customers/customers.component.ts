import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';

import { Customer } from '../../models/Customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  customers: Customer[];
  columnDefs: Array<object>;
  rowData: Customer[];

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customerService.getCustomers().subscribe(customers => {
      this.customers = customers;
      this.createColumnDefinitions();
      this.rowData = [...this.customers];
      console.log(this.rowData);
    });
  }

  createColumnDefinitions(): void {
    this.columnDefs = new Array();

    // tslint:disable-next-line: forin
    for (const property in this.customers[0]) {
      const indexOfFirstUpperCaseLetter = property.split('').findIndex(letter => letter.charCodeAt(0) < 97);
      const hasTwoWords = indexOfFirstUpperCaseLetter > -1;
      let headerName = property[0].toUpperCase() + property.slice(1, hasTwoWords ? indexOfFirstUpperCaseLetter : property.length);
      headerName = hasTwoWords ? `${headerName} ${property.slice(indexOfFirstUpperCaseLetter)}` : headerName;
      const columnDef = {
        headerName,
        field: property,
        sortable: true,
        filter: true,
        checkboxSelection: property === 'customerID' ? true : false
      };
      this.columnDefs.push(columnDef);
    }
  }

}
