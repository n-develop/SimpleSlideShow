# SimpleSlideShow

## What is SimpleSlideShow?

SimpleSlideShow is a small ASP.NET Core application that scans a folder for image files and will show them in a slideshow.

## Just another slideshow app?

Yes, you might be right. But I had a couple of requirements that are not met by most slideshow apps out there.

* Cross-platform
  * I wanted an app that runs on Windows, Linux and my Raspberry Pi
* Reload the directory
  * For my scenario it was important to always scan for new images, because new pictures are added with a relatively high frequency.
* Always show the latest picuters
    * I always want to see the latest pictures and don't want to wait for a whole new cycle.


## How to use?

### Run it!

Just `dotnet restore`, `dotnet build`, `dotnet run` and you're good.

