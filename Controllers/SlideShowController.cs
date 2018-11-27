using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimpleSlideShow.Models;

namespace SimpleSlideShow.Controllers
{
    public class SlideShowController : Controller
    {
        private static DateTime _latestShown = DateTime.MinValue;
        private readonly IConfiguration _configuration;
        private readonly string _contentRoot;

        public SlideShowController(IConfiguration configuration)
        {
            _configuration = configuration;
            _contentRoot = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }

        public IActionResult Index()
        {
            var model = new IndexPage();
            model.Title = _configuration.GetValue("PageTitle", "SimpleSlideShow"); 
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Next()
        {
            return Json(GetNextImage());
        }

        private List<string> GetNextImage()
        {
            // TODO Move to service, to keep stuff testable
            var dir = new System.IO.DirectoryInfo(_contentRoot + "/wwwroot/images/slideshow/");
            var files = dir.GetFiles().Where(f => f.CreationTime > _latestShown).OrderBy(f => f.CreationTime).ToList();
            _latestShown = files.LastOrDefault()?.CreationTime ?? _latestShown;
            return files.Select(f => "/images/slideshow/" + f.Name).ToList();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
