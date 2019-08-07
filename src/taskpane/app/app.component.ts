import { Component } from '@angular/core';
import { Asset } from './types.asset';
import { Assets } from './constants.resources';
const template = require('./app.component.html');

@Component({
	selector: 'app-home',
	template
})
export class AppComponent {
	assets : Asset[];
	ngOnInit(): void {
		this.assets = Assets;
	}
	async insert(content) {
		Office.context.document.setSelectedDataAsync(content,
			{
				coercionType: Office.CoercionType.XmlSvg,
				imageWidth: 200
			},
			result => {
				if (result.status === Office.AsyncResultStatus.Failed) {
					console.error(result.error.message);
				}
			}
		);
	}
}