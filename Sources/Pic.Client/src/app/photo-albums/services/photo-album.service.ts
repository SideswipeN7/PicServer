import { HttpClient } from '@angular/common/http';
import { Injectable } from "@angular/core"
import { Observable } from 'rxjs';

import { AlbumInfo } from '../models/album-info';

@Injectable()
export class PhotoAlbumService {
  private url = 'api/photo-albums'

  constructor(private httpClient: HttpClient) { }

  public getAlbums(): Observable<AlbumInfo[]> {
    return this.httpClient.get<AlbumInfo[]>(this.url);
  }

  public create(title: string): Observable<number> {
    return this.httpClient.post<number>(`${this.url}/add`,{title});
  }
}
