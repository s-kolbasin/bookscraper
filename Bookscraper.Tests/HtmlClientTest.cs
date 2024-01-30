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
		public void WhenLocalRefGoesUp_GoUp()
		{
			AssertCombinesPath("books.toscrape.com/travel", "../index.html", "books.toscrape.com/index.html");
		}

		private void AssertCombinesPath(string urlBase, string localRef, string expectedResult)
		{
			string fullUrl = client.CombinePath(urlBase, localRef);

			Assert.Equal(expectedResult, fullUrl);
		}
	}
}
