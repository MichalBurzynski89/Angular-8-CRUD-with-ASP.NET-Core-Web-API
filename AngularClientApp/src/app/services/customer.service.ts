import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Customer } from '../models/Customer';
import { environment } from 'src/environments/environment';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient) { }

  getCustomers(): Observable<Customer[]> {
    return this.http.get<Customer[]>(`${environment.apiBaseURI}/customers`);
  }

  getCustomerByID(id: string): Observable<Customer> {
    return this.http.get<Customer>(`${environment.apiBaseURI}/customers/${id}`);
  }

  createCustomer(customer: Customer): Observable<void> {
    return this.http.post<void>(`${environment.apiBaseURI}/customers`, customer, httpOptions);
  }

  updateCustomer(id: string, customer: Customer): Observable<void> {
    return this.http.put<void>(`${environment.apiBaseURI}/customers/${id}`, customer, httpOptions);
  }

  deleteCustomer(id: string): Observable<void> {
    return this.http.delete<void>(`${environment.apiBaseURI}/customers/${id}`);
  }
}
