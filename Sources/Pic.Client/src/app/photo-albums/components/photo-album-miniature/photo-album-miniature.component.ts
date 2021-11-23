import { NgIf } from '@angular/common';
import { Byte } from '@angular/compiler/src/util';
import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-photo-album-miniature',
  templateUrl: './photo-album-miniature.component.html',
  styleUrls: ['./photo-album-miniature.component.scss']
})
export class PhotoAlbumMiniatureComponent {
  @Input()
  id!: number;
  @Input()
  title!: string;
  @Input()
  synopsis: string | null = null;
  @Input()
  miniature: Byte[] | null = null;

  constructor(private router: Router) { }

  onViewClick(): void {
    this.router.navigate(['albums', this.id])
  }
}
