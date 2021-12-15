import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfileComponent } from './profile/profile-component/profile-component.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { SkillsListComponent } from './skills-list/skills-list.component';

const routes: Routes = [
  { path: 'employees', component: EmployeeListComponent },
  { path: 'skills', component: SkillsListComponent},
  { path: 'profile', component: ProfileComponent},
  { path: '', redirectTo: 'profile', pathMatch: 'full'},
  { path: '**', redirectTo: 'profile', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [ProfileComponent];
