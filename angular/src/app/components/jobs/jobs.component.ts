import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog} from "@angular/material/dialog";
import {MatPaginator} from "@angular/material/paginator";
import {FormBuilder} from "@angular/forms";
import {MatSort} from "@angular/material/sort";
import {CommonService} from "../../shared/services/common.service";
import {JobFormComponent} from "./job-form/job-form.component";

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html'
})
export class JobsComponent implements OnInit {

  displayedColumns = ['id', 'companyMasterId', 'designationId', 'vacancyAvailable', 'address1', 'address2', 'actions'];
  dataSource: any;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private commonService: CommonService, private fb: FormBuilder, public dialog: MatDialog) {
  }

  ngOnInit(): void {
    this.getData();
  }

  getData(): void {
    const input = {
      maxResultCount: 100,
      skipCount: 0,
    };
    this.commonService.postRequest('JobMaster/fetchJobMasterList', input).subscribe((result) => {
      // console.log('Get Data : ', result);
      if(result){
        this.dataSource = result.items;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(JobFormComponent);
    dialogRef.afterClosed().subscribe(result => {
      // console.log('The dialog was closed after insert : ', result);
      if(result){
        this.getData();
      }
    });
  }

  edit(editData: any): void {
    // console.log('Edit Data : ', editData);
    const dialogRef = this.dialog.open(JobFormComponent, {
      data: editData,
    });
    dialogRef.afterClosed().subscribe(result => {
      // console.log('The dialog was closed after update : ', result);
      if(result){
        this.getData();
      }
    });
  }

  delete(id: any): void {
    this.commonService.deleteRequestWithId('JobMaster/delete', id).subscribe((data) => {
      // console.log('Delete Resp : ', data);
      this.getData();
    });
  }

}
