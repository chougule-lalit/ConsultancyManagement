import {Component, Inject, OnInit} from '@angular/core';
import {CreateAndUpdateModalComponent} from '../../inquiry/create-and-update-modal/create-and-update-modal.component';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {CommonService} from '../../../shared/services/common.service';

@Component({
  selector: 'app-company-form',
  templateUrl: './company-form.component.html'
})
export class CompanyFormComponent implements OnInit {

  form!: FormGroup;
  mode = 'Add';
  isSubmitted = false;
  constructor(
    public dialogRef: MatDialogRef<any>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private commonService: CommonService
  ) {
  }

  ngOnInit(): void {
    this.form = this.fb.group({
      id: [null],
      name: ['', [Validators.required]],
      active: [true, [Validators.required]],
      address1: ['', [Validators.required]],
      address2: ['', [Validators.required]],
    });

    if (this.data) {
      console.log('Edit Data : ', this.data);
      this.mode = 'Update';

      this.commonService.getRequestWithId('CompanyMaster/get', this.data.id).subscribe(() => {
        this.form.patchValue({
          id: this.data.id,
          name: this.data.name,
          active: this.data.active,
          address1: this.data.address1,
          address2: this.data.address2,
        })
      });
      console.log('patchValue : ', this.form.value);
    }
  }

  get f() {
    return this.form.controls;
  }

  onSubmit(): void {
    console.log('Form Data : ', this.form.value);
    this.isSubmitted = true;
    if (this.form.invalid) {
      return;
    }
    this.commonService.postRequest('CompanyMaster/createOrUpdate', this.form.value).subscribe((resp) => {
      console.log('Save Resp', resp);
      this.dialogRef.close(true);
    });

  }

}
