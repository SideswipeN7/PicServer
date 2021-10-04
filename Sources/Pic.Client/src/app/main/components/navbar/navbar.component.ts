import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  @Input()
  theme: string | null = null;;
  @Output()
  onThemeToggle = new EventEmitter<void>();
  @Output()
  onMenuToggle = new EventEmitter<void>();


  constructor() { }

  public ngOnInit(): void {
  }

  public toggleTheme(): void{
    this.onThemeToggle.emit();
  }

  public toggleMenu(): void{
    this.onMenuToggle.emit();
  }

}
