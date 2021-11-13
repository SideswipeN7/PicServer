import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { PhotoAlbumsOverviewComponent } from "./components/photo-albums-overview/photo-albums-overview.component";
import { PhotoAlbumResolverService } from "./services/resolvers/photo-album-resolver.service";

const routes: Routes = [
  {
    path: '',
    resolve: { photoAlbums: PhotoAlbumResolverService },
    component: PhotoAlbumsOverviewComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PhotoAlbumsRoutingModule { }
