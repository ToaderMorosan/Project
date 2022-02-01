import { Component, OnInit } from '@angular/core';
import { Skill, EmployeeForCreation, DevTool, Interest, Study } from '../shared/Employee';
import { SharedService } from 'src/app/shared/shared.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {  
  employeeId: string;
  employee = new EmployeeForCreation();
  skill = new Skill();
  interest = new Interest;
  devTool = new DevTool
  study = new Study;
  msgTrue : boolean =  false;
  constructor(
    private SharedService: SharedService) { }

  ngOnInit(): void {
  }
  createEmployee() {
    this.SharedService.AddEmployee(this.employee)
      .subscribe((data: any) => {
        console.log(data)
      })      
  }
  createSkill() {
    this.SharedService.AddSkill(this.employeeId,this.skill)
      .subscribe((data: any) => {
        console.log(data)
      })      
  }
  createInterest() {
    this.SharedService.AddInterest(this.employeeId,this.interest)
      .subscribe((data: any) => {
        console.log(data)
      })      
  }
  createDevTool() {
    this.SharedService.AddDevTool(this.employeeId,this.devTool)
      .subscribe((data: any) => {
        console.log(data)
      })      
  }
  createStudy() {
    this.SharedService.AddStudy(this.employeeId,this.study)
      .subscribe((data: any) => {
        console.log(data)
      })      
  }
  deleteEmployee() {
    this.SharedService.DeleteEmployee(this.employeeId)
      .subscribe((data: any) => {
        console.log(data)
      })      
  }

}
