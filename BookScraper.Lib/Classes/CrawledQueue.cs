namespace BookScraper.Lib
{
	public class CrawledQueue
	{
		public Queue<Page> PageQueue { get; set; }
		public bool Finished { get; set; }
	}
}
