import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SkillsListService {

  constructor(private http:HttpClient) { }

  public getSkills(){
    return this.http.get("https://localhost:7106/api/Skill");
  }
}
