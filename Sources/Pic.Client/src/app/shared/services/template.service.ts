import { Injectable, TemplateRef } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TemplateService {
  private headerTemplateSubject$ = new BehaviorSubject<TemplateRef<any> | null>(null);

  public headerTemplate$ = this.headerTemplateSubject$.asObservable();

  public setHeaderTemplate(templateRef: TemplateRef<any>): void {
    this.headerTemplateSubject$.next(templateRef);
  }
}
