using BookScraper.Lib;

var scraper = new Scraper(@"https://books.toscrape.com/", @"C:\Temp\scraps\");
var scrapeTask = Task.Run(scraper.ScrapeAsync);

while (!scrapeTask.IsCompleted)
{
	Thread.Sleep(2000);
	Console.WriteLine($"Visited {scraper.TotalPages} pages so far!");
}

Console.WriteLine("All done!");
