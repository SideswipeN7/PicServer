import { AddPhotosDialogComponent } from './../add-photos-dialog/add-photos-dialog.component';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { concatMap, filter, switchMap } from 'rxjs/operators';

import { AlbumInfo } from '../../models/album-info';
import { PhotoAlbumService } from '../../services/photo-album.service';

@Component({
  selector: 'app-photo-album',
  templateUrl: './photo-album.component.html',
  styleUrls: ['./photo-album.component.scss'],
})
export class PhotoAlbumComponent implements OnInit {
  maxSynopsisLength = 500;
  maxTitleLength = 200;
  albumInfo!: AlbumInfo;
  editAlbumInfo!: AlbumInfo;
  isEdit = false;
  canEdit = true;

  constructor(
    private activatedRoute: ActivatedRoute,
    public matDialog: MatDialog,
    private photoAlbumService: PhotoAlbumService,
  ) { }

  ngOnInit(): void {
    this.albumInfo = this.activatedRoute.snapshot.data.albumInfo;
  }

  toggleEdit(): void {
    this.isEdit = !this.isEdit;
    this.editAlbumInfo = { ...this.albumInfo };
  }

  save(): void {
  }

  add(): void {
    const dialogRef = this.matDialog.open(AddPhotosDialogComponent, {
      // width: '250px',
      // data: {} as AlbumInfo,
      hasBackdrop: true,
    });

    dialogRef.afterClosed()
      .pipe(
        filter(result => !!result),
        // switchMap((result: AlbumInfo) => this.photoAlbumService.create(result.title, result.synopsis)),
        // switchMap(() => this.photoAlbumService.getAlbums()),
      )
      .subscribe(result => {
        // this.photoAlbums = result;
      });
  }
}
