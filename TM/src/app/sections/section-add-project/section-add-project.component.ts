import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Customer } from 'src/app/models/customer';
import { DBAccessService } from 'src/app/services/dbaccess.service';

@Component({
  selector: 'app-section-add-project',
  templateUrl: './section-add-project.component.html',
  styleUrls: ['./section-add-project.component.css']
})
export class SectionAddProjectComponent implements OnInit {

  addButtonText: string = "Add";
  showError:boolean = false;
  showSuccess:boolean = false;
  addProjectForm: FormGroup;
  customers: Customer[] = [
  ];
  
  
  constructor(private dbaccess: DBAccessService,
    private formBuilder: FormBuilder
    ) { }

    getCustomers(): void {
      this.dbaccess.getCustomers()
        .subscribe(res => {
          console.log('Result from getCustomers: ', res);
          this.customers = res as Customer[];          
        });
    }

  ngOnInit(): void {
    this.getCustomers();

    this.addProjectForm = this.formBuilder.group({
      name: ['', [Validators.required]],
      customerId: ['', [Validators.required]],
      description: ''
    })


  }

  addProject(addProjectFormValue): void {
    
    this.dbaccess.addProject(addProjectFormValue)
      .subscribe(res => {
        console.log('Result from addProject: ', res);
        this.showError = false;
        this.showSuccess = true;
        this.addProjectForm.reset();
        this.addButtonText = "Add";
      }, (error) => {
        console.log('debug: ', addProjectFormValue);
        console.log("There was an error.");
        this.showSuccess = false;
        this.showError = true;
        this.addButtonText = "Add";
      });
      
  }

  onSubmit(addProjectFormValue){
    this.showError = this.showSuccess = false;
    this.addButtonText = "Processing";
    this.addProject(addProjectFormValue);
    //console.warn('Your form has been submitted', addCProjectFormValue);
    
  }

}
