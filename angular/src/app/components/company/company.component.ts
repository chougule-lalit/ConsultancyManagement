import {Component, OnInit, ViewChild} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {MatSort} from '@angular/material/sort';
import {MatPaginator} from '@angular/material/paginator';
import {CommonService} from '../../shared/services/common.service';
import {FormBuilder} from '@angular/forms';
import {CompanyFormComponent} from './company-form/company-form.component';

@Component({
  selector: 'app-company',
  templateUrl: './company.component.html'
})
export class CompanyComponent implements OnInit {

  displayedColumns = ['id', 'name', 'active', 'address1', 'address2', 'actions'];
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
    this.commonService.postRequest('CompanyMaster/fetchCompanyMasterList', input).subscribe((result) => {
      console.log('Get Data : ', result);
      this.dataSource = result.items;
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    });
  }

  add(): void {
    const dialogRef = this.dialog.open(CompanyFormComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed after insert : ', result);
      if (result) {
        this.getData();
      }
    });
  }

  edit(editData: any): void {
    console.log('Edit Data : ', editData);
    const dialogRef = this.dialog.open(CompanyFormComponent, {
      data: editData,
    });
    dialogRef.afterClosed().subscribe(result => {
      console.log('The dialog was closed after update : ', result);
      if (result) {
        this.getData();
      }
    });
  }

  delete(id: any): void {
    this.commonService.deleteRequestWithId('CompanyMaster/delete', id).subscribe((data) => {
      console.log('Delete Resp : ', data);
      this.getData();
    });
  }


}
