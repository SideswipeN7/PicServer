import {
  AfterViewInit,
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
  ViewChild,
  ViewContainerRef,
} from '@angular/core'
import { Subject } from 'rxjs'
import { takeUntil } from 'rxjs/operators'
import { TemplateService } from '../../../shared/services/template.service'

import { Theme } from '../../enums/theme'
import { ThemeService } from '../../services/theme.service'

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss'],
})
export class NavbarComponent implements OnInit, OnDestroy, AfterViewInit {
  @ViewChild('header', { read: ViewContainerRef, static: false })
  private header!: ViewContainerRef;
  private onDestroy = new Subject()
  private theme!: Theme;

  @Output()
  public onMenuToggle = new EventEmitter<void>()

  public get themeIcon(): string {
    if (this.theme === Theme.Dark) {
      return 'brightness_7';
    }

    return 'brightness_3';
  }

  constructor(
    private themeService: ThemeService,
    private templateService: TemplateService,
  ) { }

  public ngOnDestroy(): void {
    this.onDestroy.next()
  }

  public ngOnInit(): void {
    this.themeService.theme$
      .pipe(takeUntil(this.onDestroy))
      .subscribe(newTheme => this.theme = newTheme as Theme);
  }

  public ngAfterViewInit(): void {
    this.templateService
      .headerTemplate$
      .pipe(takeUntil(this.onDestroy))
      .subscribe(template => {
        if (!this.header) {
          return;
        }

        this.header.clear();

        if (template) {
          this.header.createEmbeddedView(template);
        }
      });
  }

  public toggleTheme(): void {
    this.themeService.toggleTheme()
  }

  public toggleMenu(): void {
    this.onMenuToggle.emit()
  }
}

