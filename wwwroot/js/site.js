var currentSlide = 0;
var lastUpdated = new Date();
carousel();

function carousel() {
    nextImages();

    var slides = document.getElementsByClassName("slide");
    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    currentSlide++;
    if (currentSlide > slides.length) {
        currentSlide = 1
    }
    slides[currentSlide - 1].style.display = "block";
    setTimeout(carousel, 4000);
}

function nextImages() {
    fetch('/SlideShow/Next?date=' + lastUpdated.toISOString())
        .then(function(response) {
            return response.text();
        })
        .then(function(data) {
            if (data.trim().length > 0) {
                lastUpdated = new Date();
                var carouselDiv = document.getElementById("carousel");
                carouselDiv.insertAdjacentHTML('beforeend', data);
            }

        });
}