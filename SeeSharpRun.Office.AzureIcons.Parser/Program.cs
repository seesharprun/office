using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{
    public static async Task Main(string[] args)
    {
        string iconsPath = Path.Combine(@"azure-icons-master", @"azure-icons");
	
        var categories = Directory
            .EnumerateDirectories(iconsPath)
            .Where(d => 
                !d.Contains("breadcrumb", StringComparison.OrdinalIgnoreCase) && 
                !d.Contains("flat", StringComparison.OrdinalIgnoreCase)
            )
            .Select(d => new Category(d))
            .ToList<Category>();
		
        foreach(var category in categories)
        {
            var icons = Directory
                .EnumerateFiles(category.FolderPath)
                .Where(f => 
                    Path.GetExtension(f) == ".svg"
                )
                .Select(f => new Icon(f))
                .ToList<Icon>();

            foreach (var icon in icons)
            {
                string rawSvg = await File.ReadAllTextAsync(icon.FilePath);
                icon.SvgContent = rawSvg;
            }
            
            category.Icons.AddRange(icons);
        }

		StringBuilder builder = new StringBuilder();

		builder.AppendLine("import { Asset } from './types.asset';");
		builder.AppendLine();
		builder.AppendLine("export var Assets: Asset[] = [");

		var assetQuery = 
			from category in categories 
			from icon in category.Icons 
			select new 
			{ 
				Category = category.Name, 
				Title = icon.Name, 
				Content = icon.SvgContent 
			};

		foreach (var asset in assetQuery)
		{
			builder.AppendLine("\t{");

			builder.AppendLine($"\t\ttitle: '{asset.Title}',");

			builder.AppendLine($"\t\tcategory: '{asset.Category}',");

			builder.AppendLine($"\t\tcontent: `{asset.Content}`");

			builder.AppendLine("\t},");
		}
		
		builder.Remove(builder.Length - 3, 1);
		
		builder.AppendLine("]; ");

		string code = builder.ToString();

        string codeFilePath = Path.Combine(iconsPath, @"constants.resources.ts");

        await File.WriteAllTextAsync(codeFilePath, code);
	}
}