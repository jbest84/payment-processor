# Overview #
> This is a C# library for communicating with the Authorize.NET payment gateway (using the Advanced Integration Method -  AIM). Echeck is also supported.

  * Easy to use
  * Extensible through the user of interfaces
  * Code is clean and well documented
  * Tracing statements so you can see what is being sent/recieved
  * Very flexible open source license

# April 25th, 2011 #
> Added github mirror: https://github.com/skeeterbug84/payment-processor

# Update February 15th, 2011 #
> payment-processor is now available as [NuGet](http://www.nuget.org/Packages/Packages/Details/payment-processor-1-12) package.

# Update October 8th, 2010 #
> The old SVN repository was migrated to mercurial (hg).

# New 1.12 Release #
  * Fixed an issue in MerchantInfo.ToString()
  * Added a quick start project (Thanks to matokuzma for this contribution).

# New 1.11 Release #
> Version 1.11 has a fix in AuthorizeRequest.

# 1.10 Released #
> The current version is now 1.10. The XInfo container classes now implement a common interface (IInfo) that the AuthorizeRequest classes take advantage of. Upgrading will require some changes to the AuthorizeRequest CTor call, see [DevelopmentNotes](DevelopmentNotes.md). For a complete list of changes, check out the [Changelog](Changelog.md).
