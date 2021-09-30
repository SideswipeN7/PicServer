import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
		path: 'albums',
		loadChildren: () => import('./photo-albums/photo-albums.module').then(m => m.PhotoAlbumsModule),
		data: {
			preload: false,
		},
	},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
