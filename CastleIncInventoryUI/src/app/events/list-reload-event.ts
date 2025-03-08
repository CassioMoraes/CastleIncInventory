import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ListReloadEvent {
  private listReload = new Subject<any>();

  event$ = this.listReload.asObservable();

  reloadList(data: any) {
    this.listReload.next(data);
  }
}
