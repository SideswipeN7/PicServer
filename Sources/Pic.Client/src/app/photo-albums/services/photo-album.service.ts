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

  public getAlbum(id: number): Observable<AlbumInfo> {
    return this.httpClient.get<AlbumInfo>(`${this.url}/${id}`);
  }

  public create(title: string, synopsis: string): Observable<number> {
    return this.httpClient.post<number>(`${this.url}/add`, { title, synopsis });
  }

  public edit(id: number, title: string): Observable<void> {
    return this.httpClient.put<void>(`${this.url}/${id}`, { title });
  }
}
