import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {CommonService} from 'src/app/shared/services/common.service';

@Component({
  selector: 'app-create-and-update-modal',
  templateUrl: './create-and-update-modal.component.html'
})
export class CreateAndUpdateModalComponent implements OnInit {
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
    const emailRegex = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    const phoneRegex = /^[0-9]{10}$/;
    this.form = this.fb.group({
      id: [null],
      firstName: ['', [Validators.required]],
      lastName: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.pattern(emailRegex)]],
      phone: ['', [Validators.required, Validators.pattern(phoneRegex)]],
      remark: ['']
    });

    if (this.data) {
      console.log('Edit Data : ', this.data);
      this.mode = 'Update';
      this.commonService.getRequestWithId('Enquiry/get', this.data.id).subscribe((result) => {
        this.form.patchValue({
          id: this.data.id,
          firstName: result.firstName,
          lastName: result.lastName,
          email: result.email,
          phone: result.phone,
          remark: result.remark,
        });
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
    this.commonService.postRequest('Enquiry/createOrUpdate', this.form.value).subscribe((resp) => {
      console.log('Save Resp', resp);
      this.dialogRef.close(true);
    })

  }
}
