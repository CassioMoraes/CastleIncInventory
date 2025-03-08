import { Component } from '@angular/core';
import { MatDialogActions, MatDialogContent, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { ComputerModel } from '../../models/computer-model';
import { ComputerApiService } from '../../services/computer-api-service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-add-computer-modal',
  standalone: true,
  templateUrl: './add-computer-modal.component.html',
  styleUrl: './add-computer-modal.component.css',
  imports: [
    MatDialogContent,
    MatDialogActions,
    MatDialogModule,
    MatFormFieldModule,
    FormsModule,
    CommonModule
  ]
})
export class AddComputerModalComponent {

  public computer: ComputerModel = new ComputerModel();
  public formName: string = "Add Computer"

  constructor(public dialogRef: MatDialogRef<AddComputerModalComponent>, public computerApiService: ComputerApiService) {
    this.computer.createDate = new Date();
    this.computer.purchaseDate = new Date();
    this.computer.warrantyExpirationDate = new Date();
  }

  loadComputer(computerEdit: ComputerModel): any {
    this.formName = "Edit Computer";
    this.computer = computerEdit;
    console.log("Computer: ", this.computer);
    console.log("ComputerEdit: ", computerEdit);
  }

  submit(): any {
    this.computerApiService.addComputer(this.computer).subscribe({
      next: (response) => { this.dialogRef.close();; },
      error: (error) => { console.log(error); }
    });    
  }

  close(): void {
    this.dialogRef.close();
  }
}
