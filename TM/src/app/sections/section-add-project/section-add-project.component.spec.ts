import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SectionAddProjectComponent } from './section-add-project.component';

describe('SectionAddProjectComponent', () => {
  let component: SectionAddProjectComponent;
  let fixture: ComponentFixture<SectionAddProjectComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SectionAddProjectComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SectionAddProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
