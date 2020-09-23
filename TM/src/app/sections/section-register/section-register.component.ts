import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customer } from 'src/app/models/customer';
import { Project } from 'src/app/models/project';
import { DBAccessService } from 'src/app/services/dbaccess.service';

@Component({
  selector: 'app-section-register',
  templateUrl: './section-register.component.html',
  styleUrls: ['./section-register.component.css']
})
export class SectionRegisterComponent implements OnInit {

  registerButtonText: string = "Register";
  showError:boolean = false;
  showSuccess:boolean = false;
  registerTimeForm: FormGroup;
  customers: Customer[] = [
  ];
  projects: Project[] = [
  ];
  
  constructor(private dbaccess: DBAccessService,
    private formBuilder: FormBuilder) { }

    getCustomers(): void {
      this.dbaccess.getCustomers()
        .subscribe(res => {
          console.log('Result from getCustomers: ', res);
          this.customers = res as Customer[];          
        });
    }

    getProjectsByCustomer(cId:number) : void{
      this.dbaccess.getProjectsByCustomer(cId)
      .subscribe(res => {
        console.log('Result from getProjectsByCustomer: ', res);
        this.projects = res as Project[];          
      });
    }

    onCustomerChange(){
      const cId = this.registerTimeForm.controls.customerId.value as number;
      this.getProjectsByCustomer(cId);
    }




  ngOnInit(): void {
    this.getCustomers();

    this.registerTimeForm = this.formBuilder.group({
      customerId: ['', [Validators.required]],
      projectId: ['', [Validators.required]],
      timeSpent: [0, [Validators.required, Validators.min(0.1) ]]
    })
  }

  registerTime(registerTimeFormValue): void {
    
    this.dbaccess.registerTime(registerTimeFormValue)
      .subscribe(res => {
        console.log('Result from registerTime: ', res);
        this.showError = false;
        this.showSuccess = true;
        this.projects = [];
        this.registerTimeForm.reset();
        this.registerButtonText = "Register";
      }, (error) => {
        console.log('debug: ', registerTimeFormValue);
        console.log("There was an error.");
        this.showSuccess = false;
        this.showError = true;
        this.registerButtonText = "Register";
      });
      
  }

  onSubmit(registerTimeFormValue){
    this.showError = this.showSuccess = false;
    this.registerButtonText = "Processing";
    this.registerTime(registerTimeFormValue);
    
  }

}
