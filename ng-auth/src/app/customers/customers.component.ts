import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: []
})
export class CustomersComponent implements OnInit  {
  customers: any;
 
  constructor(private http: HttpClient) { }
 
  ngOnInit() {
    let token = localStorage.getItem("jwt");
    this.http.get("http://localhost:5000/api/customers", {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      this.customers = response;
    }, err => {
      console.log(err)
    });
  }
}
