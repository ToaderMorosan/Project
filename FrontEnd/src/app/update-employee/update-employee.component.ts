import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared/shared.service';
import { ActivatedRoute } from '@angular/router';
import { Employee } from '../shared/Employee';
@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent implements OnInit {
  title = 'httpGet Example';
  employee = new Employee();
  msgTrue : boolean =  false;
  constructor(
    private SharedService: SharedService) { }
  ngOnInit(): void {
  }
  updateEmployee() {
    this.SharedService.updateEmployee(this.employee)
      .subscribe((data: any) => {
        console.log(data)
      })      
  }
}
