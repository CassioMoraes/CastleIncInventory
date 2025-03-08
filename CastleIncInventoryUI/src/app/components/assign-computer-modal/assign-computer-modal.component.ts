import { Component, OnInit } from '@angular/core';
import { MatDialogActions, MatDialogContent, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { UserModel } from '../../models/user-model';
import { UserApiService } from '../../services/user-api-service';
import { ComputerModel } from '../../models/computer-model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatOptionModule } from '@angular/material/core';

@Component({
  selector: 'app-assign-computer-modal',
  standalone: true,
  templateUrl: './assign-computer-modal.component.html',
  styleUrl: './assign-computer-modal.component.css',
  imports: [
    MatDialogContent,
    MatDialogActions,
    MatDialogModule,
    MatOptionModule,
    MatFormFieldModule,
    FormsModule,
    CommonModule
  ]
})
export class AssignComputerModalComponent implements OnInit {

  public users: UserModel[] = [];
  public computer: ComputerModel = new ComputerModel();
  public selectedUser: UserModel = new UserModel();

  constructor(public dialogRef: MatDialogRef<AssignComputerModalComponent>,
    public userApiService: UserApiService) {
  }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers(): any {
    this.userApiService.getData().subscribe({
      next: (response) => {
        this.users = response;
        console.log("Users:", this.users);
        //this.computerListStatus = "";
      },
      error: (error) => {
        //this.computerListStatus = error;
      }
    });
  }

  submit(): any {
    console.log("SelectedUser", this.selectedUser);
    this.userApiService.assignComputer(this.computer.id, this.selectedUser.id).subscribe({
      next: (response) => { this.dialogRef.close();; },
      error: (error) => { console.log(error); }
    });
  }

  close(): void {
    this.dialogRef.close();
  }
}
