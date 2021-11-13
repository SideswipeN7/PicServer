import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable, of } from "rxjs";

import { AlbumInfo } from "../../models/album-info";
import { PhotoAlbumService } from "../photo-album.service";

@Injectable()
export class PhotoAlbumResolverService implements Resolve<Observable<AlbumInfo[]>> {
	constructor(private photoAlbumService: PhotoAlbumService) { }

	resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<AlbumInfo[]> {
		return of([] as AlbumInfo[]);

		return this.photoAlbumService.getAlbums();
	}
}
