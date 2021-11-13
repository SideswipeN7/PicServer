import { Component, OnInit } from '@angular/core'
import { SidebarItem } from '../../models/sidebar-item.model'

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss'],
})
export class SidebarComponent implements OnInit {
  public menuItems!: SidebarItem[]

  constructor() {}

  public ngOnInit(): void {
    this.initMenuItems();
  }

  private initMenuItems():void {
    this.menuItems = [
      {
        displayName: 'Home',
        icon: 'home',
        routerLink: '/',
        isExact: true,
      },
      {
        displayName: 'Albums',
        icon: 'collections',
        routerLink: '/albums',
        isExact: false,
      },
    ];
  }
}
