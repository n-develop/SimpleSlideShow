using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SimpleSlideShow.Models;
using SimpleSlideShow.Services;

namespace SimpleSlideShow.Controllers
{
    public class SlideShowController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ISlideShowService _slideShowService;

        public SlideShowController(IConfiguration configuration, ISlideShowService slideShowService)
        {
            _configuration = configuration;
            _slideShowService = slideShowService;
        }

        public IActionResult Carousel()
        {
            var model = new CarouselPage();
            model.Title = _configuration.GetValue("PageTitle", "SimpleSlideShow");
            model.Images = _slideShowService.GetNextImages(DateTime.MinValue);
            return View(model);
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
            return Json(_slideShowService.GetNextImages(DateTime.MinValue));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
