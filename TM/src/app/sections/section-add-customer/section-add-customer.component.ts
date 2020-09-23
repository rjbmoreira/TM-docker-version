import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DBAccessService } from 'src/app/services/dbaccess.service';

@Component({
  selector: 'app-section-add-customer',
  templateUrl: './section-add-customer.component.html',
  styleUrls: ['./section-add-customer.component.css']
})
export class SectionAddCustomerComponent implements OnInit {

  addButtonText: string = "Add";
  showError:boolean = false;
  showSuccess:boolean = false;
  addCustomerForm: FormGroup;

  constructor(private dbaccess: DBAccessService,
    private formBuilder: FormBuilder
  ) {
    
   }

  ngOnInit(): void {
    this.addCustomerForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      email: ['', [Validators.email]],
      phone: ''
    })
  }

  addCostumer(addCustomerFormValue): void {
    
    this.dbaccess.addCustomer(addCustomerFormValue)
      .subscribe(res => {
        console.log('Result from addCostumer: ', res);
        this.showError = false;
        this.showSuccess = true;
        this.addCustomerForm.reset();
        this.addButtonText = "Add";
      }, (error) => {
        console.log("There was an error.");
        this.showSuccess = false;
        this.showError = true;
        this.addButtonText = "Add";
      });
      
  }

  onSubmit(addCustomerFormValue){
    this.showError = this.showSuccess = false;
    this.addButtonText = "Processing";
    this.addCostumer(addCustomerFormValue);
    //console.warn('Your form has been submitted', addCustomerFormValue);
    
  }
}
