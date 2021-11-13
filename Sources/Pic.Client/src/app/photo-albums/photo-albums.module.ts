import { NgModule } from "@angular/core";

import { SharedModule } from "../shared/shared.module";
import { PhotoAlbumMiniatureComponent } from "./components/photo-album-miniature/photo-album-miniature.component";
import { PhotoAlbumsOverviewComponent } from "./components/photo-albums-overview/photo-albums-overview.component";
import { PhotoAlbumsRoutingModule } from "./photo-albums-routing.module";
import { PhotoAlbumService } from "./services/photo-album.service";
import { PhotoAlbumResolverService } from "./services/resolvers/photo-album-resolver.service";

@NgModule({
  imports: [
    SharedModule,
    PhotoAlbumsRoutingModule,
  ],
  declarations: [
    PhotoAlbumsOverviewComponent,
    PhotoAlbumMiniatureComponent,
  ],
  providers: [
    PhotoAlbumResolverService,
    PhotoAlbumService,
  ]
})
export class PhotoAlbumsModule { }
