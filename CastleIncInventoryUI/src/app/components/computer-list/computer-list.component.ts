import { Component, OnInit, OnDestroy } from '@angular/core';
import { ComputerApiService } from '../../services/computer-api-service';
import { ComputerModel } from '../../models/computer-model';
import { MatDialog } from '@angular/material/dialog';
import { AddComputerModalComponent } from '../add-computer-modal/add-computer-modal.component';
import { AssignComputerModalComponent } from '../assign-computer-modal/assign-computer-modal.component';
import { Subscription } from 'rxjs';
import { ListReloadEvent } from '../../events/list-reload-event';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-computer-list',
  standalone: true,
  templateUrl: './computer-list.component.html',
  styleUrl: './computer-list.component.css',
  imports: [
    CommonModule
  ]
})
export class ComputerListComponent implements OnInit, OnDestroy {
  public computerListStatus: string = "Loading ...";
  private subscription: Subscription = new Subscription;
  constructor(private computerApiService: ComputerApiService, private dialog: MatDialog, private listReloadEvent: ListReloadEvent) { }

  computers: ComputerModel[] = [];

  ngOnInit() {
    this.subscription = this.listReloadEvent.event$.subscribe(() => {
      this.loadList();
    })
    this.loadList();
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }

  loadList(): void {
    this.computerListStatus = "Loading ...";
    this.computerApiService.getData().subscribe({
      next: (response) => {
        this.computers = response;
        this.computerListStatus = "";
      },
      error: (error) => {
        this.computerListStatus = error;
      }
    });
  }

  hasAssignedOnDate(computer: ComputerModel): boolean {
    return computer.assignedOn != null;
  }

  editComputer(computer: ComputerModel) {
    const dialogRef = this.dialog.open(AddComputerModalComponent);
    dialogRef.componentInstance.loadComputer(computer);
    dialogRef.afterClosed().subscribe(result => {
      this.loadList();
      dialogRef.close();
      console.log(`Dialog result: ${result}`);
    });
  }

  assignUser(computer: ComputerModel): void {
    const dialogRef = this.dialog.open(AssignComputerModalComponent);
    dialogRef.componentInstance.computer = computer;
    dialogRef.componentInstance.loadUsers();
    dialogRef.afterClosed().subscribe(result => {
      this.loadList();
      dialogRef.close();
      console.log(`Dialog result: ${result}`);
    });
  }

  deleteComputer(computerId: number) {
    this.computerApiService.deleteComputer(computerId).subscribe({
      next: () => { this.loadList(); },
      error: (error) => { console.log(error); }
    });
  }
}
