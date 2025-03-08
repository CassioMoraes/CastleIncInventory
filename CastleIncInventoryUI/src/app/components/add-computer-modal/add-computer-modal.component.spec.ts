import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddComputerModalComponent } from './add-computer-modal.component';

describe('AddComputerModalComponent', () => {
  let component: AddComputerModalComponent;
  let fixture: ComponentFixture<AddComputerModalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddComputerModalComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddComputerModalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
