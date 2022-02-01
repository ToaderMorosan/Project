import {LiveAnnouncer} from '@angular/cdk/a11y';
import { Component, ViewChild, OnInit,AfterViewInit} from '@angular/core';
import {MatSort, Sort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { SkillsListService } from './skills-list.service';
import { SkillsReports } from './skillsReports';
import { Input} from '@angular/core'


@Component({
  selector: 'app-skills-list',
  templateUrl: './skills-list.component.html',
  styleUrls: ['./skills-list.component.css']
})
export class SkillsListComponent implements OnInit {
  @Input('ELEMENT_DATA')  ELEMENT_DATA!:  SkillsReports[];
  displayedColumns: string[] = ['name', 'occurence'];
  dataSource= new MatTableDataSource<SkillsReports>(this.ELEMENT_DATA);

  constructor(private _liveAnnouncer: LiveAnnouncer, private service:SkillsListService) {}

  @ViewChild(MatSort) sort: MatSort;
  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(){

    this.getAllSkills();
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

  public getAllSkills(){
    let resp = this.service.getSkills();
    resp.subscribe(report => this.dataSource.data = report as SkillsReports[]);
  }
}

