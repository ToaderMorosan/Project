import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Employee } from './Employee';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  errorMessage: any;

  constructor(private http:HttpClient) { }
  getEmployee(id: number){
    var employee =  this.http.get('https://localhost:7106/api/Employee/'+id);
    return employee;
  }

  getStudies(id: number){
    var studies =  this.http.get('https://localhost:7106/api/Studies/getStudyByEmployee/'+id);
    return studies;
  }

  getSkills(id: number){
    var skills =  this.http.get('https://localhost:7106/api/Employee/Skill/'+id);
    return skills;
  }
  getDevTools(id: number){
    var skills =  this.http.get('https://localhost:7106/api/Employee/DevTool/'+id);
    return skills;
  }
  getInterests(id: number){
    var interests =  this.http.get('https://localhost:7106/api/Employee/Interest/'+id);
    return interests;
  }
  updateEmployee(employee:Employee): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(employee);
    return this.http.put('https://localhost:7106/api/Employee/'+ employee.id, body,{'headers':headers})
  }
}



//'https://localhost:7106/api/Employee?skillId=' +skillId+ '&interestId='+interestId+'&decToolId='+devToolId

