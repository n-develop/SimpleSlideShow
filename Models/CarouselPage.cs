using System.Collections.Generic;

namespace SimpleSlideShow.Models
{
    public class CarouselPage
    {
        public string Title { get; set; }

        public List<Slide> Images { get; set; }
    }
}