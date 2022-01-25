import {LiveAnnouncer} from '@angular/cdk/a11y';
import {AfterViewInit, Component, ViewChild} from '@angular/core';
import {MatSort, Sort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { EmployeeListService } from './employee-list.service';
import { EmployeeReports } from './employeesReport';
import { Input} from '@angular/core'

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements AfterViewInit {
  @Input('ELEMENT_DATA')  ELEMENT_DATA!:  EmployeeReports[];
  displayedColumns: string[] = ['id', 'name', 'ocupation','phoneNumber','address','email','github','instagram'];
  dataSource= new MatTableDataSource<EmployeeReports>(this.ELEMENT_DATA);

  constructor(private _liveAnnouncer: LiveAnnouncer, private service:EmployeeListService) {}


  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  
  ngOnInit(){
    this.getAllEmployees();
  }
  ngAfterViewInit() {
    this.dataSource.sort = this.sort;
    this.dataSource.paginator = this.paginator;
  }
  applyFilter(filterValue: string) {
    this.dataSource.filter = filterValue.trim().toLowerCase();
  }

  /** Announce the change in sort state for assistive technology. */
  announceSortChange(sortState: Sort) {
    // This example uses English messages. If your application supports
    // multiple language, you would internationalize these strings.
    // Furthermore, you can customize the message to add additional
    // details about the values being sorted.
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  public getAllEmployees(){
    let resp = this.service.getEmployees();
    resp.subscribe(report => this.dataSource.data = report as EmployeeReports[]);
  }

}
