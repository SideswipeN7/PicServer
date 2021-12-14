import { Directive, TemplateRef } from '@angular/core';

import { TemplateService } from '../services/template.service';

@Directive({
  selector: '[appHeader]',
})
export class HeaderDirective {
  constructor(private element: TemplateRef<any>, private templateService: TemplateService) {
    this.templateService.setHeaderTemplate(this.element);
  }
}
