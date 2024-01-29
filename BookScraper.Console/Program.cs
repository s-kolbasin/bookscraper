using BookScraper.Lib;

var scraper = new Scraper(@"D:\Projects\1337\");
await scraper.Scrape();

Console.WriteLine("All done!");
