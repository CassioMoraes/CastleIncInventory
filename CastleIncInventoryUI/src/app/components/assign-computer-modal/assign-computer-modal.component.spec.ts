import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AssignUserModalComponent } from './assign-computer-modal.component';

describe('AssignUserModalComponent', () => {
  let component: AssignUserModalComponent;
  let fixture: ComponentFixture<AssignUserModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AssignUserModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AssignUserModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
