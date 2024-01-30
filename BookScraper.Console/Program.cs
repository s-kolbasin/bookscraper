using BookScraper.Lib;

var scraper = new Scraper(@"D:\Projects\1337\", @"https://books.toscrape.com/");
await scraper.Scrape();

Console.WriteLine("All done!");
