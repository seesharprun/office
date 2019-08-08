using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Category
{
	public string Name { get; set; }
	
	public string FolderName { get; set; }
	
	public string FolderPath { get; set; }	
	
	public List<Icon> Icons { get; set; }
	
	public Category(string path)
	{
		this.FolderPath = path;
		this.FolderName = this.FolderPath
			.Split(Path.DirectorySeparatorChar)
			.LastOrDefault();
		this.Name = this.FolderName?
			.Replace("Symbols", String.Empty)
			.Replace("Symbol", String.Empty)
			.Replace("Color", String.Empty)
			.Replace("Service", String.Empty)
			.Replace("Category", String.Empty)
			.Replace("Icons", String.Empty)
			.Replace("Icon", String.Empty)
			.Replace("_", String.Empty)
			.Replace("'", @"\'")
			.Trim();
		this.Icons = new List<Icon>();
	}
}