using System;
using System.IO;
using System.Linq;

public class Icon
{
	public string Name { get; set; }

	public string FileName { get; set; }

	public string FilePath { get; set; }

	public string SvgContent { get; set; }
	
	public Icon(string path)
	{
		this.FilePath = path;
		this.FileName = Path
			.GetFileName(this.FilePath);
		this.Name = Path
			.GetFileNameWithoutExtension(this.FilePath)
			.Replace("'", @"\'");
	}
}