import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class EmployeeListService {

  constructor(private http:HttpClient) { }

  public getEmployees(){
    return this.http.get("https://localhost:7106/api/Employee");
  }
}
