import { Injectable } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";

import { Theme } from "../enums/theme";

@Injectable({
    providedIn: 'root',
  })
export class ThemeService {
    private readonly themeKey = 'theme';
    private subject = new BehaviorSubject<Theme>(this.getTheme());
   
    public get theme$(): Observable<Theme> {
        return this.subject.asObservable();
    }

    public toggleTheme(): void {
        const newTheme = this.subject.value === Theme.Light ? Theme.Dark : Theme.Light;

        this.setTheme(newTheme);
    }

    private setTheme(theme: Theme): void {
        this.subject.next(theme);
        localStorage.setItem(this.themeKey, theme);
    }

    private getTheme(): Theme {
        return localStorage.getItem(this.themeKey) as Theme || Theme.Light;
    }
}
