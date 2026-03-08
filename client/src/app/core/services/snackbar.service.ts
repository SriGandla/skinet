import { Injectable, inject } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class SnackbarService {
  // use Angular Material's MatSnackBar for showing messages
  private snackBar = inject(MatSnackBar);

  error(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      panelClass: ['snack-error']
    });
  }

  success(message: string) {
    this.snackBar.open(message, 'Close', {
      duration: 5000,
      panelClass: ['snack-success']
    });
  }
}
