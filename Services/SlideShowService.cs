using System;
using System.Collections.Generic;
using System.Linq;
using SimpleSlideShow.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SimpleSlideShow.Services
{
    public class SlideShowService : ISlideShowService
    {
        private readonly IConfiguration _configuration;
        private static string[] animations = { "animate-top", "animate-bottom", "animate-right", "animate-left" };
        private readonly string _contentRoot;

        public SlideShowService(IConfiguration configuration)
        {
            _configuration = configuration;
            _contentRoot = _configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }
        public List<Slide> GetNextImages(DateTime latestShown)
        {
            var dir = new System.IO.DirectoryInfo(_contentRoot + "/wwwroot/images/slideshow/");
            var files = dir.GetFiles("*.jpg").Where(f => f.CreationTime > latestShown).OrderBy(f => f.CreationTime).ToList();
            latestShown = files.LastOrDefault()?.CreationTime ?? latestShown;
            var random = new Random();
            return files.Select(f =>
            {
                var captionPath = f.FullName.Replace(f.Extension, ".txt");
                var slide = new Slide
                {
                    Image = "/images/slideshow/" + f.Name,
                    Animation = animations[random.Next(animations.Length)]
                };
                if (File.Exists(captionPath)) {
                    slide.Caption = File.ReadAllText(captionPath);
                }
                return slide;
            }).ToList();
        }
    }
}