import { Directive, EventEmitter, HostBinding, HostListener, Output } from "@angular/core";

@Directive({
  selector: '[appDragAndDrop]',
})
export class DragAndDropDirective {
  @HostBinding('class.fileover')
  fileOver: boolean = false;

  @Output()
  fileDropped = new EventEmitter<any>();

  // Dragover listener
  @HostListener('dragover', ['$event']) onDragOver(event: { preventDefault: () => void; stopPropagation: () => void; }) {
    console.log('drag over')
    event.preventDefault();
    event.stopPropagation();
    this.fileOver = true;
  }

  // Dragleave listener
  @HostListener('dragleave', ['$event']) public onDragLeave(event: { preventDefault: () => void; stopPropagation: () => void; }) {
    console.log('drag leave')
    event.preventDefault();
    event.stopPropagation();
    this.fileOver = false;
  }

  // Drop listener
  @HostListener('drop', ['$event']) public ondrop(event: { preventDefault: () => void; stopPropagation: () => void; dataTransfer: { files: any; }; }) {
    console.log('drop')
    event.preventDefault();
    event.stopPropagation();
    this.fileOver = false;
    let files = event.dataTransfer.files;
    if (files.length > 0) {
      this.fileDropped.emit(files);
    }
  }
}
