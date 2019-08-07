import { Pipe, PipeTransform } from '@angular/core'; 
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

@Pipe({
    name: 'sanitize'
})
export class SanitizePipe implements PipeTransform {
    constructor() {} //protected sanitizer: DomSanitizer
    transform(content: string): any {
        // this.sanitizer.bypassSecurityTrustHtml(content);
        return '<code>Missing SVG Image</code>';
    }
}