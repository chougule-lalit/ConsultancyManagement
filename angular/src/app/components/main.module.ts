import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { LayoutComponent } from './layout/layout.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSelectModule } from '@angular/material/select';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { SkillsComponent } from './skills/skills.component';
import { CompanyComponent } from './company/company.component';
import { DesignationComponent } from './designation/designation.component';
import { CompanyFormComponent } from './company/company-form/company-form.component';
import { SkillFormComponent } from './skills/skill-form/skill-form.component';
import { DesignationFormComponent } from './designation/designation-form/designation-form.component';
import {DepartmentComponent} from "./department/department.component";
import {DepartmentFormComponent} from "./department/department-form/department-form.component";
import { JobsComponent } from './jobs/jobs.component';
import { JobFormComponent } from './jobs/job-form/job-form.component';


@NgModule({
  declarations: [
    LayoutComponent,
    SkillsComponent,
    CompanyComponent,
    DesignationComponent,
    DesignationFormComponent,
    DepartmentComponent,
    DepartmentFormComponent,
    CompanyFormComponent,
    SkillFormComponent,
    JobsComponent,
    JobFormComponent,
  ],
  imports: [
    CommonModule,
    MainRoutingModule,
    HttpClientModule,
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule,
    MatTableModule,
    MatDialogModule,
    MatInputModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    MatPaginatorModule,
  ]
})
export class MainModule { }
