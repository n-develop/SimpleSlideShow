var images = [];

$(function () {
    setInterval(nextImages, 10000);
});

function nextImages() {
    $.ajax("/SlideShow/Next").done(function(data) {
        data.forEach(element => {
            if (!images.includes(element)) {
                images.unshift(element);
            }
        });
        
        if (images.length > 0) {
            var first = images.shift();
            document.getElementById("img-container").style.backgroundImage = "url('".concat(first).concat("')");
            images.push(first);
        }
    });
}