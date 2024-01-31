using BookScraper.Lib;

namespace Bookscraper.Tests
{
	public class HtmlClientTest
	{
		private WebHtmlClient client = new ();

		[Fact]
		public void WhenSimpleLocalRef_AddsToCurrent()
		{
			AssertCombinesPath("books.toscrape.com", "index.html", "books.toscrape.com/index.html");
		}

		[Fact]
		public void WhenCurrentEndsInIndex_RemoveIndex()
		{
			AssertCombinesPath("books.toscrape.com/index.html", "travel", "books.toscrape.com/travel");
		}

		[Fact]
		public void WhenLocalRefGoesUp_GoUp()
		{
			// TODO: Can we simplify? This should work, but of course not ideal, since we'd visit some pages multiple times
			AssertCombinesPath("books.toscrape.com/travel", "../index.html", "books.toscrape.com/travel/../index.html");
		}

		private void AssertCombinesPath(string urlBase, string localRef, string expectedResult)
		{
			string fullUrl = client.CombinePath(urlBase, localRef);

			Assert.Equal(expectedResult, fullUrl);
		}
	}
}
