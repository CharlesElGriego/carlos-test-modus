import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material';

@Injectable({
  providedIn: 'root'
})
export class SnackbarService {

  constructor(private snackBar: MatSnackBar) { }

  showError(message: string) {
    this.snackBar.open(message, 'close', {
      duration: 3000,
      panelClass: ['snack-alert']
    });
  }
}
