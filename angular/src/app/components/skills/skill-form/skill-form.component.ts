import {Component, Inject, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {MAT_DIALOG_DATA, MatDialogRef} from '@angular/material/dialog';
import {CommonService} from '../../../shared/services/common.service';

@Component({
  selector: 'app-skill-form',
  templateUrl: './skill-form.component.html'
})
export class SkillFormComponent implements OnInit {
  form!: FormGroup;
  mode = 'Add';
  isSubmitted = false;
  selectedUserMasterId!: number;
  userHolder: any[] = [];
  constructor(
    public dialogRef: MatDialogRef<any>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private commonService: CommonService
  ) {
  }

  ngOnInit(): void {
    this.getUserList();
    this.form = this.fb.group({
      id: [null],
      name: ['', [Validators.required]],
      userMasterId: ['', [Validators.required]],
      experienceInMonths: ['', [Validators.required]],
    });

    if (this.data) {
      console.log('Edit Data : ', this.data);
      this.mode = 'Update';
      this.commonService.getRequestWithId('SkillMaster/get', this.data.id).subscribe((result) => {
        this.selectedUserMasterId = result.userMasterId;
        this.form.patchValue({
          id: this.data.id,
          name: result.name,
          userMasterId: result.userMasterId,
          experienceInMonths: result.experienceInMonths
        });
      });
    }
  }

  getUserList(): void {
    const input = {
      maxResultCount: 100,
      skipCount: 0,
    };
    this.commonService.fetchUserList(input).subscribe((result) => {
      console.log('fetchUserList : ', result);
      this.userHolder = result.items;
    });
  }

  get f() {
    return this.form.controls;
  }

  onSubmit(): void {
    this.form.patchValue({
      userMasterId: this.selectedUserMasterId
    });
    console.log('Form Data : ', this.form.value);
    this.isSubmitted = true;
    if (this.form.invalid) {
      return;
    }
    this.commonService.postRequest('SkillMaster/createOrUpdate', this.form.value).subscribe((resp) => {
      console.log('Save Resp', resp);
      this.dialogRef.close(true);
    });

  }

  /*getUsers(){
    this.commonService.getRequest('').subscribe((result) => {
      this.userHolder = result;
    })
  }*/
}
