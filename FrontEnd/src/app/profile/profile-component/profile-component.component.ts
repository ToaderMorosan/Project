import { Component, OnInit } from '@angular/core';
import { ProfileService } from './profile.service';
import { Input} from '@angular/core'
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/shared/shared.service';
@Component({
  selector: 'app-profile-component',
  templateUrl: './profile-component.component.html',
  styleUrls: ['./profile-component.component.css']
})

export class ProfileComponent implements OnInit {

  id:any;
  employee: any;
  studies: any;
  skills: any;
  devTools:any;
  interests:any;
  constructor(private route:ActivatedRoute,
    private SharedService: SharedService) { }

  ngOnInit(): void {
    this.id =this.route.snapshot.params['id'];
    this.SharedService.getEmployee(this.id).subscribe(data => {
      this.employee=data;
  
    }, error => {
      console.log(error); // if api returns and error you will get it here  
    }); 
    
    this.SharedService.getStudies(this.id).subscribe(data => {
      this.studies=data;
    
    }, error => {
      console.log(error); // if api returns and error you will get it here  
    }); 


    this.SharedService.getSkills(this.id).subscribe(data => {
      this.skills=data;
    
    }, error => {
      console.log(error); // if api returns and error you will get it here  
    }); 

    this.SharedService.getDevTools(this.id).subscribe(data => {
      this.devTools=data;
    
    }, error => {
      console.log(error); // if api returns and error you will get it here  
    }); 

    this.SharedService.getInterests(this.id).subscribe(data => {
      this.interests=data;
    
    }, error => {
      console.log(error); // if api returns and error you will get it here  
    }); 
  }

}





