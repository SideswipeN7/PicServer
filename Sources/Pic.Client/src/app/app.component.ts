import { Component } from '@angular/core';
import { MatDrawerMode } from '@angular/material/sidenav';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Pic-Client';
  public DarkTheme = 'dark-theme';
  public LightTheme = 'light-theme';
  public theme = 'dark-theme'

  public changeTheme(): void{
    this.theme = this.theme === this.LightTheme ? this.DarkTheme : this.LightTheme;
  }
}
