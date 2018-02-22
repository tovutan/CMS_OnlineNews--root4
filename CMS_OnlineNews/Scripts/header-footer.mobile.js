(function($){
    var menumain = {
        init: function () {
            menumain.events();
        },
        events: function () {
            $('.menumain').swiper({
                paginationClickable: true,
                preventClicks: false,
                freeMode: true,
                spaceBetween: 0,
                slidesPerView: 'auto'
            });
        }
    };

	$(document).ready(function (){
        if ($(".menumain").length > 0) {
            menumain.init();
        }

        $(document).on('click','.mf-frsearch',function(e){
            e.preventDefault();
            $('.mf-search').addClass('active');
            $('.mf-sarm,.mf-sarm-most').show();
        });
        $('.mf-frsearch').keyup(function(){
            if($('.mf-frsearch').val().length > 0){
                $('.mf-search').addClass('active');
                $('.mf-sarm-most').hide();
                $('.mf-sarm,.mf-sarm-rs').show();

            }else{
                $('.mf-search').removeClass('active');
                $('.mf-sarm').hide();
            }
        });

        $(document).on('click','.mf-hdimn',function(e){
            e.preventDefault();
            $('.mf-mnleft').addClass("active");
            $('.mf-overlay').show();
        });
        $(document).on('click','.mf-overlay,.mf-mnclose',function(e){
            e.preventDefault();
            $('.mf-mnleft').removeClass("active");
            $('.mf-overlay').hide();
        });

        $(document).on('click','.mf-ftiflink',function(e){
            e.preventDefault();
            $('.mf-ftif-ex').slideToggle();
            $('html, body').animate({ scrollTop: $(".mf-ftif").offset().top - 185 }, 1000);
        });

        $(document).on('click','.mf-isearch',function(e){
            e.preventDefault();
            $('.mf-search').slideToggle();
        });

        $(window).scroll(function () {
            if ($(this).scrollTop() > 100) {
                $('.mf-backtop').fadeIn();
            } else {
                $('.mf-backtop').fadeOut();
            }
        });
        $(document).on('click','.mf-backtop',function(e){
            e.preventDefault();
            $("html, body").animate({ scrollTop: 0 }, 600);
            return false;
        });

	});
})(window.jQuery);