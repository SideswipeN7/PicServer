import { NgModule } from "@angular/core";
import { SharedModule } from "../shared/shared.module";
import { OverviewComponent } from './components/overview/overview.component';
import { PhotoAlbumsRoutingModule } from "./photo-albums-routing.module";
import { PhotoAlbumResolverService } from "./services/resolvers/photo-album-resolver.service";

@NgModule({
	imports: [
		SharedModule,
		PhotoAlbumsRoutingModule,
	],
	declarations: [
    OverviewComponent,
  ],
  providers: [
    PhotoAlbumResolverService,
  ]
})
export class PhotoAlbumsModule { }
