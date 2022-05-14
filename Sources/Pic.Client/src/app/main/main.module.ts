import { ModuleWithProviders, NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';

@NgModule({
  declarations: [SidebarComponent, NavbarComponent],
  imports: [SharedModule],
  providers: [],
  exports: [SidebarComponent, NavbarComponent],
})
export class MainModule {
  static forRoot(): ModuleWithProviders<MainModule> {
    return {
      ngModule: MainModule,
      providers: [],
    };
  }
}
