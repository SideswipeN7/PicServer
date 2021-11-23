import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

import { AlbumInfo } from '../../models/album-info';

@Component({
  selector: 'app-edit-photo-album-dialog',
  templateUrl: './edit-photo-album-dialog.component.html',
})
export class EditPhotoAlbumDialogComponent {
  constructor(
    private dialogRef: MatDialogRef<EditPhotoAlbumDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public albumInfo: AlbumInfo,
  ) { }

  onCancel(): void {
    this.dialogRef.close();
  }
}
