import { HttpClient } from '@angular/common/http';
import { Injectable, SkipSelf } from "@angular/core"
import { Observable, Subscription } from 'rxjs';
import { AlbumInfo } from '../models/album-info';

Injectable()
export class PhotoAlbumService {
  private url = 'api/products'

  constructor(@SkipSelf() private httpClient: HttpClient) { }

  public getAlbums(): Observable<AlbumInfo[]> {
    return this.httpClient.get<AlbumInfo[]>(this.url);
  }
}
