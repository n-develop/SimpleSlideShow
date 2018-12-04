using SimpleSlideShow.Models;
using System;
using System.Collections.Generic;

namespace SimpleSlideShow.Services
{
    public interface ISlideShowService
    {
        List<Slide> GetNextImages(DateTime latestShown);
    }
}