import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { OverviewComponent } from "./components/overview/overview.component";
import { PhotoAlbumResolverService } from "./services/resolvers/photo-album-resolver.service";

const routes: Routes = [
  {
    path: '',
    resolve: { photoAlbums: PhotoAlbumResolverService },
    component: OverviewComponent
  }
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule]
})
export class PhotoAlbumsRoutingModule { }
