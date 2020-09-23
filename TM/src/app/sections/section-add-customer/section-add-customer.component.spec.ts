import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionAddCustomerComponent } from './section-add-customer.component';

describe('SectionAddCustomerComponent', () => {
  let component: SectionAddCustomerComponent;
  let fixture: ComponentFixture<SectionAddCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SectionAddCustomerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionAddCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
