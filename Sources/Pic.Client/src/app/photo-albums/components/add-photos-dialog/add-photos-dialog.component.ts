import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { AlbumInfo } from '../../models/album-info';

@Component({
  selector: 'app-add-photos-dialog',
  templateUrl: './add-photos-dialog.component.html',
})
export class AddPhotosDialogComponent {
  constructor(private dialogRef: MatDialogRef<AddPhotosDialogComponent>) { }

  onCancel(): void {
    this.dialogRef.close();
  }

  onUploadClicked($event: any): void {
  }

  onSelectedFilesChanged($event: any): void {
  }
}
