import { Component } from '@angular/core';
import { AddComputerModalComponent } from '../add-computer-modal/add-computer-modal.component';
import { MatDialog } from '@angular/material/dialog';
import { ListReloadEvent } from '../../events/list-reload-event';
import { ComputerListComponent } from '../computer-list/computer-list.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'main-root',
  templateUrl: './main.component.html',
  standalone: true,
  styleUrl: './main.component.css',
  imports: [
    RouterOutlet,
    ComputerListComponent
  ]
})
export class MainComponent {
  title = 'CastleIncInventoryUI';

  constructor(public dialog: MatDialog, private listReloadEvent: ListReloadEvent) { }

  addComputer() {
    const dialogRef = this.dialog.open(AddComputerModalComponent);

    dialogRef.afterClosed().subscribe(result => {
      this.listReloadEvent.reloadList({});
      dialogRef.close();
      console.log(`Dialog result: ${result}`);
    });
  }
}
