import 'zone.js'; // Required for Angular
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import AppModule from './app/app.module';

Office.initialize = reason => {
    // Bootstrap the app
    platformBrowserDynamic().bootstrapModule(AppModule).catch(error => console.error(error));
};