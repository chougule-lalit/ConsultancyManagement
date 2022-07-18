import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {AuthGuard} from '../shared/guards/auth.guard';
import {RoleGuard} from '../shared/guards/role.guard';
import {AboutComponent} from './about/about.component';
import {HomeComponent} from './home/home.component';
import {InquiryComponent} from './inquiry/inquiry.component';
import {LayoutComponent} from './layout/layout.component';
import {RoleComponent} from './role/role.component';
import {UsersComponent} from './users-and-roles/users.component';
import {SkillsComponent} from './skills/skills.component';
import {CompanyComponent} from './company/company.component';
import {DesignationComponent} from './designation/designation.component';
import {DepartmentComponent} from "./department/department.component";
import {JobsComponent} from "./jobs/jobs.component";

const routes: Routes = [
  {
    path: '', component: LayoutComponent, children: [
      {path: '', redirectTo: '/main/home', pathMatch: 'full'},
      {path: 'home', component: HomeComponent},
      {path: 'about', component: AboutComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'users', component: UsersComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'enquiry', component: InquiryComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'skills', component: SkillsComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'company', component: CompanyComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'designation', component: DesignationComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'department', component: DepartmentComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'roles', component: RoleComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
      {path: 'jobs', component: JobsComponent, canActivate: [AuthGuard, RoleGuard], data: {expectedRoles: 1}},
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MainRoutingModule {
}
