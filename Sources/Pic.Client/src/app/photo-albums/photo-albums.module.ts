import { NgModule } from "@angular/core";

import { SharedModule } from "../shared/shared.module";
import { PhotoAlbumMiniatureComponent } from "./components/photo-album-miniature/photo-album-miniature.component";
import { PhotoAlbumsOverviewComponent } from "./components/photo-albums-overview/photo-albums-overview.component";
import { PhotoAlbumsRoutingModule } from "./photo-albums-routing.module";
import { PhotoAlbumService } from "./services/photo-album.service";
import { PhotoAlbumResolverService } from "./services/resolvers/photo-album-resolver.service";
import { CreatePhotoAlbumDialogComponent } from './components/create-photo-album-dialog/create-photo-album-dialog.component';
import { PhotoAlbumComponent } from './components/photo-album/photo-album.component';
import { PhotoAlbumInfoResolverService } from "./services/resolvers/photo-album-info-resolver.service";
import { AddPhotosDialogComponent } from "./components/add-photos-dialog/add-photos-dialog.component";

@NgModule({
  imports: [
    SharedModule,
    PhotoAlbumsRoutingModule,
  ],
  declarations: [
    PhotoAlbumsOverviewComponent,
    PhotoAlbumMiniatureComponent,
    CreatePhotoAlbumDialogComponent,
    PhotoAlbumComponent,
    AddPhotosDialogComponent,
  ],
  entryComponents:[
    CreatePhotoAlbumDialogComponent,
  ],
  providers: [
    PhotoAlbumResolverService,
    PhotoAlbumInfoResolverService,
    PhotoAlbumService,
  ]
})
export class PhotoAlbumsModule { }
