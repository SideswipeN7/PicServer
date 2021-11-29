import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { concatMap, filter, switchMap } from 'rxjs/operators';

import { AlbumInfo } from '../../models/album-info';
import { PhotoAlbumService } from '../../services/photo-album.service';

@Component({
  selector: 'app-photo-album',
  templateUrl: './photo-album.component.html',
  styleUrls: ['./photo-album.component.scss']
})
export class PhotoAlbumComponent implements OnInit {
  maxSynopsisLength = 200;
  albumInfo!: AlbumInfo;
  editAlbumInfo!: AlbumInfo;
  isEdit = false;

  constructor(
    private activatedRoute: ActivatedRoute,
    public matDialog: MatDialog,
    private photoAlbumService: PhotoAlbumService,
  ) { }

  ngOnInit(): void {
    this.albumInfo = this.activatedRoute.snapshot.data.albumInfo;
  }

  edit(): void {
    this.isEdit = !this.isEdit;
    this.editAlbumInfo = { ...this.albumInfo };
  }
}
