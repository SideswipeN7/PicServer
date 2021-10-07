import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core'
import { Subject } from 'rxjs'
import { takeUntil } from 'rxjs/operators'

import { Theme } from '../../enums/theme'
import { ThemeService } from '../../services/theme.service'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit, OnDestroy {
  private onDestroy = new Subject()  
  private theme!: Theme;

  @Output()
  public onMenuToggle = new EventEmitter<void>()

  public get themeIcon(): string {
    if(this.theme === Theme.Dark){
      return 'brightness_7';
    }

    return 'brightness_3';
  }

  constructor(private themeService: ThemeService) {}

  public ngOnDestroy(): void {
    this.onDestroy.next()
  }

  public ngOnInit(): void {
    this.themeService.theme$
    .pipe(takeUntil(this.onDestroy))
    .subscribe(newTheme => this.theme = newTheme as Theme);
  }

  public toggleTheme(): void {
    this.themeService.toggleTheme()
  }

  public toggleMenu(): void {
    this.onMenuToggle.emit()
  }
}

