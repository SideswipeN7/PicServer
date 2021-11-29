import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Observable } from "rxjs";

import { AlbumInfo } from "../../models/album-info";
import { PhotoAlbumService } from "../photo-album.service";

@Injectable()
export class PhotoAlbumInfoResolverService implements Resolve<Observable<AlbumInfo>> {
	constructor(private photoAlbumService: PhotoAlbumService) { }

	resolve(route: ActivatedRouteSnapshot, _state: RouterStateSnapshot): Observable<AlbumInfo> {
		return this.photoAlbumService.getAlbum(route.params.id);
	}
}
