import { ModuleWithProviders, NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";
import { RouterModule } from "@angular/router";
import { MaterialDesignModule } from "../shared/material-design.module";
import { NavbarComponent } from "./components/navbar/navbar.component";
import { SidebarComponent } from "./components/sidebar/sidebar.component";

@NgModule({
	declarations: [
    SidebarComponent,
    NavbarComponent,
	],
	imports: [
    MaterialDesignModule,
    RouterModule,
    BrowserModule,
	],
  providers: [],
  exports: [
    SidebarComponent,
    NavbarComponent,
  ]
})
export class MainModule {

	static forRoot(): ModuleWithProviders<MainModule> {
		return {
			ngModule: MainModule,
			providers: []
		};
	}
}
