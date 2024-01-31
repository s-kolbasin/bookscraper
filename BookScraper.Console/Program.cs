using BookScraper.Lib;

string rooUrl = @"https://books.toscrape.com/";
string targetFolder = @"C:\Temp\scraps\";

if (args.Length > 2)
{
	rooUrl = args[1];
	targetFolder = args[2];
}

var scraper = new Scraper(rooUrl, targetFolder);
var scrapeTask = Task.Run(scraper.ScrapeAsync);

while (!scrapeTask.IsCompleted)
{
	Thread.Sleep(2000);
	Console.WriteLine($"Visited {scraper.TotalPages} pages so far!");
}

Console.WriteLine("All done!");
