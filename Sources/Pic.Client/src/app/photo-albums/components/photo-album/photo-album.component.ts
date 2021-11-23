import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { concatMap, filter, switchMap } from 'rxjs/operators';

import { AlbumInfo } from '../../models/album-info';
import { PhotoAlbumService } from '../../services/photo-album.service';
import { EditPhotoAlbumDialogComponent } from '../edit-photo-album-dialog/edit-photo-album-dialog.component';

@Component({
  selector: 'app-photo-album',
  templateUrl: './photo-album.component.html',
  styleUrls: ['./photo-album.component.scss']
})
export class PhotoAlbumComponent implements OnInit {
  albumInfo!: AlbumInfo;

  constructor(
    private activatedRoute: ActivatedRoute,
    public matDialog: MatDialog,
    private photoAlbumService: PhotoAlbumService,
  ) { }

  ngOnInit(): void {
    this.albumInfo = this.activatedRoute.snapshot.data.albumInfo;
  }

  edit(): void {
    const dialogRef = this.matDialog.open(EditPhotoAlbumDialogComponent, {
      width: '250px',
      data: { title: this.albumInfo.title } as AlbumInfo,
      hasBackdrop: true,
    });

    dialogRef.afterClosed()
      .pipe(
        filter(result => !!result),
        concatMap(result => this.photoAlbumService
          .edit(this.albumInfo.id, result)
          .pipe(switchMap(() => result))),
      )
      .subscribe(result => {
        this.albumInfo.title = result as string;
      });
  }
}
