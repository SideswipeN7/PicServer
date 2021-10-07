import { Component } from '@angular/core';
import { Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { Theme } from './main/enums/theme';
import { ThemeService } from './main/services/theme.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  private onDestroy = new Subject()
  public title = 'Pic-Client';
  public theme!: Theme;

  constructor(private themeService: ThemeService) {}
  
  public ngOnDestroy(): void {
    this.onDestroy.next()
  }

  public ngOnInit(): void {
    this.themeService.theme$
    .pipe(takeUntil(this.onDestroy))
    .subscribe(newTheme => this.theme = newTheme as Theme);
  }
}
