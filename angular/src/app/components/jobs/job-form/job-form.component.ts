import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {CommonService} from "../../../shared/services/common.service";

@Component({
  selector: 'app-job-form',
  templateUrl: './job-form.component.html'
})
export class JobFormComponent implements OnInit {

  form!: FormGroup;
  mode = 'Create';
  isSubmitted = false;
  selectedCompanyMasterId!: number;
  selectedDesignationId!: number;
  companyMasterHolder: any[] = [];
  designationHolder: any[] = [];

  constructor(
    public dialogRef: MatDialogRef<any>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private commonService: CommonService
  ) {
  }

  ngOnInit(): void {
    this.getCompany();
    this.getDesignation();
    this.form = this.fb.group({
      id: [null],
      companyMasterId: ['', [Validators.required]],
      designationId: ['', [Validators.required]],
      vacancyAvailable: ['', [Validators.required]],
      address1: ['', [Validators.required]],
      address2: ['', [Validators.required]],
    });

    if (this.data) {
      // console.log('Edit Data : ', this.data);
      this.mode = 'Update';
      this.commonService.getRequestWithId('JobMaster/get', this.data.id).subscribe((result) => {
        if (result) {
          this.selectedCompanyMasterId = result.companyMasterId;
          this.selectedDesignationId = result.designationId;
          this.form.patchValue({
            id: this.data.id,
            companyMasterId: result.companyMasterId,
            designationId: result.designationId,
            vacancyAvailable: result.vacancyAvailable,
            address1: result.address1,
            address2: result.address2,
          });
        }
      });
      // console.log('patchValue : ', this.form.value);
    }
  }

  get f() {
    return this.form.controls;
  }

  onSubmit(): void {

    this.form.patchValue({
      companyMasterId: this.selectedCompanyMasterId,
      designationId: this.selectedDesignationId,
    });
    // console.log('Form Data : ', this.form.value);
    this.isSubmitted = true;
    if (this.form.invalid) {
      return;
    }
    this.commonService.postRequest('JobMaster/createOrUpdate', this.form.value).subscribe((resp) => {
      // console.log('Save Resp', resp);
      this.dialogRef.close(true);
    })
  }

  getCompany() {
    this.commonService.getRequest('CompanyMaster/getCompanyMasterDropdown').subscribe((result) => {
      if (result) {
        this.companyMasterHolder = result;
      }
    })
  }
  getDesignation() {
    this.commonService.getRequest('DesignationAndDepartment/getDesignationDropdown').subscribe((result) => {
      if (result) {
        this.designationHolder = result;
      }
    })
  }

}
