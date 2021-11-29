import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { PhotoAlbumComponent } from "./components/photo-album/photo-album.component";
import { PhotoAlbumsOverviewComponent } from "./components/photo-albums-overview/photo-albums-overview.component";
import { PhotoAlbumInfoResolverService } from "./services/resolvers/photo-album-info-resolver.service";
import { PhotoAlbumResolverService } from "./services/resolvers/photo-album-resolver.service";

const routes: Routes = [
  {
    path: '',
    resolve: { photoAlbums: PhotoAlbumResolverService },
    component: PhotoAlbumsOverviewComponent
  },
  {
    path: ':id',
    resolve: { albumInfo: PhotoAlbumInfoResolverService },
    component: PhotoAlbumComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhotoAlbumsRoutingModule { }
