# bookscraper

A small console app that scrapes the target site into a specified folder.

========== How to run ============

The application receives two console line arguments: the root URL of the site to scrape, and the target folder where to save the resources. If not specified, they are set to defaults:
https://books.toscrape.com/
C:\Temp\scraps\

========== How it works ============

The solution has three projects:
Bookscraper.Console
Bookscraper.Lib
Bookscraper.Test

Lib has the logic implemented, mostly within the Scraper class. Console starts and instance of the Scraper class and prints out the ongoing progress information to the console. Test project has tests on (some) classes from Lib.

========== How it actually works =============

Scraper uses two components: Crawler and Downloader.

Crawler recursively scans all pages for links. If it is the first time the page is visited, Crawler also enqueues it for the further download.

Downloader (currently under development) visits the queued pages and downloads them, as well as any referenced resources, to the hard drive.

This approach has some overhead in that we visit (and parse) every page twice, but it is relatively small because the real bottleneck is expected to be disk IO. Besides, it allows to better understand how much progress was made.

========== Third party libraries ==============

https://flurl.dev/
Flurl: a library for parsing and combining URLs. MIT license.

https://html-agility-pack.net/
HTML Agility Pack: a library for parsing HTML DOM. MIT license.