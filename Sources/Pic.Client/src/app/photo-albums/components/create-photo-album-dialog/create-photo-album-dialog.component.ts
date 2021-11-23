import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { AlbumInfo } from '../../models/album-info';

@Component({
  selector: 'app-create-photo-album-dialog',
  templateUrl: './create-photo-album-dialog.component.html',
})
export class CreatePhotoAlbumDialogComponent {
  constructor(
    private dialogRef: MatDialogRef<CreatePhotoAlbumDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public albumInfo: AlbumInfo,
  ) { }

  onCancel(): void {
    this.dialogRef.close();
  }
}
