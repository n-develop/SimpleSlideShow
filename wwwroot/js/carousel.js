var currentSlide = 0;
carousel();

function carousel() {
    var slides = document.getElementsByClassName("slide");
    for (var i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    currentSlide++;
    if (currentSlide > slides.length) {
        currentSlide = 1
    }
    slides[currentSlide - 1].style.display = "block";
    setTimeout(carousel, 8000);
}