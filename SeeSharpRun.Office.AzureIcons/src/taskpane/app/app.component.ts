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
	split(assets: Asset[]): Asset[][] {
		var results = [];
		for (var i = 0; i < assets.length; i += 3) {
			var row = [];
			for (var j = 0; j < 3; j++) {
				var value = assets[i + j];
				if (!value) break;
				row.push(value);
			}
			results.push(row);
		}
		return results;
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