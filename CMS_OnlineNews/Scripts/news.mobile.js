(function($){
    var sldtNews = {
        init: function () {
            sldtNews.events();
        },
        events: function () {
            $('.mfnslder').swiper({
                paginationClickable: true,
                preventClicks: false,
                spaceBetween: 5,
                slidesPerView: 1,
                autoplay: 3500,
                autoplayDisableOnInteraction: false,
                pagination: '.mfnslder .swiper-pagination'
            });
        }
    };
	$(document).ready(function (){
        if ($(".mfnslder").length > 0) {
            sldtNews.init();
        }

        $(document).on('click','.mfn-dtvcmt a',function(e){
            e.preventDefault();
            $('html, body').animate({ scrollTop: $(".mfn-cmts").offset().top - 60 }, 1000);
        });

        $(document).on('click','.mfn-dtcontent img',function(e){
            e.preventDefault();
            var srcImg = $(this).attr("src");
            $('.mfn-dtmdisrc').attr('src',srcImg);
            $('#mfndtimg').modal('show');
        });

        /*news - zoom font*/
        var section = '#contents *';
        var originalFontSize = $(section).css('font-size');
        $(document).on('click','.mfn-dtfont-s',function(e){
            decreaseFont();

        });
        $(document).on('click','.mfn-dtfont-b',function(e){
            increaseFont();
        });
        function resetFont(){
            $(section).css('font-size', originalFontSize);
        }
        function increaseFont() {
            $(section).each(function(idx, el){
                var currentFontSize = $(this).css('font-size'),
                    currentFontSizeNum = parseFloat(currentFontSize, 10),
                    newFontSize = currentFontSizeNum / 0.8;
                $(this).css('font-size', newFontSize);
            });
        }
        function decreaseFont(){
            $(section).each(function(idx, el){
                var currentFontSize = $(this).css('font-size');
                var currentFontSizeNum = parseFloat(currentFontSize, 10);
                var newFontSize = currentFontSizeNum*0.8;
                $(this).css('font-size', newFontSize);
            });
        }

	});
})(window.jQuery);