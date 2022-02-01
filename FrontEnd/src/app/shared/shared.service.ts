import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { DevTool, Employee, EmployeeForCreation, Interest, Skill ,Study} from './Employee';

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
  AddEmployee(employee:EmployeeForCreation): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(employee);
    return this.http.post('https://localhost:7106/api/Employee/', body,{'headers':headers})
  }
  AddSkill(employeeId: string,skill:Skill): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(skill);
    return this.http.post('https://localhost:7106/api/Skill/'+employeeId, body,{'headers':headers})
  }
  AddInterest(employeeId: string,interest:Interest): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(interest);
    return this.http.post('https://localhost:7106/api/Interest/'+employeeId, body,{'headers':headers})
  }
  AddDevTool(employeeId: string,devTool:DevTool): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(devTool);
    return this.http.post('https://localhost:7106/api/DevTool/'+employeeId, body,{'headers':headers})
  }
  AddStudy(employeeId: string,study:Study): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    const body=JSON.stringify(study);
    return this.http.post('https://localhost:7106/api/Studies/'+employeeId, body,{'headers':headers})
  }
  DeleteEmployee(employeeId: string): Observable<any> {
    const headers = { 'content-type': 'application/json'}  
    var employee =  this.http.delete('https://localhost:7106/api/Employee/'+employeeId);
    return employee;
  }
}



//'https://localhost:7106/api/Employee?skillId=' +skillId+ '&interestId='+interestId+'&decToolId='+devToolId

