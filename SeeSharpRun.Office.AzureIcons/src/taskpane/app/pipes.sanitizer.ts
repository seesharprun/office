import { Pipe, PipeTransform, Injectable, Inject, forwardRef } from '@angular/core'; 
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
    name: 'sanitize'
})
export class SanitizePipe implements PipeTransform {
    constructor(@Inject(forwardRef(() => DomSanitizer))private _sanitizer: DomSanitizer) {} // 
    transform(content: string): SafeHtml {
        return this._sanitizer.bypassSecurityTrustHtml(content);
    }
}