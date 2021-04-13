$(window)
    .resize(function () {
        if ($(window).width() > 1090) {
            $(".sidebar").removeClass("collapse");
            
        } else {
            $(".sidebar").addClass("collapse");
        }
    })
    .resize();