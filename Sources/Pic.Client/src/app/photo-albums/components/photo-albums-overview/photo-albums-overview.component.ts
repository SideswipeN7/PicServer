import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { filter, switchMap } from 'rxjs/operators';
import { AlbumInfo } from '../../models/album-info';
import { PhotoAlbumService } from '../../services/photo-album.service';
import { CreatePhotoAlbumDialogComponent } from '../create-photo-album-dialog/create-photo-album-dialog.component';

@Component({
  selector: 'app-photo-albums-overview',
  templateUrl: './photo-albums-overview.component.html',
  styleUrls: ['./photo-albums-overview.component.scss']
})
export class PhotoAlbumsOverviewComponent implements OnInit {

  photoAlbums!: AlbumInfo[];

  constructor(
    private activatedRoute: ActivatedRoute,
    public matDialog: MatDialog,
    private photoAlbumService: PhotoAlbumService,
    ) { }

  ngOnInit(): void {
    this.photoAlbums = this.activatedRoute.snapshot.data.photoAlbums;
  }

  add(): void {
    const dialogRef = this.matDialog.open(CreatePhotoAlbumDialogComponent, {
      width: '250px',
      data: {} as AlbumInfo,
      hasBackdrop: true,
    });

    dialogRef.afterClosed()
    .pipe(
      filter(result => !!result),
      switchMap((result: AlbumInfo) => this.photoAlbumService.create(result.title, result.synopsis)),
      switchMap(() => this.photoAlbumService.getAlbums()),
    )
    .subscribe(result => {
      this.photoAlbums = result;      
    });
  }

}
