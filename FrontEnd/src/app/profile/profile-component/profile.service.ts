import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http:HttpClient) { }

  public getProfile(){
    return this.http.get("https://localhost:7106/api/Employee/1");
  }
}
