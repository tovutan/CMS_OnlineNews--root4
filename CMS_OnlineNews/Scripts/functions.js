(function($){
    var slCate = {
        init: function () {
            slCate.events();
        },
        events: function () {
            $('.fsicte').each(function(index, element){
                var $this = $(this);
                i = $this.attr('data-items');
                $this.owlCarousel({
                    items : i,
                    slideBy: i,
                    margin: 0,
                    nav: true,
                    navText: '',
                    dots: false,
                    lazyLoad: true
                });
            });
        }
    };

	$(document).ready(function (){
        /*search*/
        $(document).on('focus','.fs-stxt',function(){
            $(".fs-sresult").show();
        });
        $(document).on('focusout','.fs-stxt',function(){
            $(".fs-sresult").hide();
        });

        /*SLIDE BANER HOME*/
        var sync1 = $("#fowl1");
        var sync2 = $("#fowl2");
        var slidesPerPage = $("#fowl2 .item").length;
        var syncedSecondary = true;
        if(slidesPerPage > 0){
            sync1.owlCarousel({
                items : 1,
                margin: 5,
                nav: true,
                navText: '',
                dots: false,
                mouseDrag: false,
                lazyLoad: true,
                autoplay: true,
                autoplaySpeed: 1500,
                autoplayTimeout: 6000,
                autoplayHoverPause: true,
                loop: true,
                responsiveRefreshRate : 200
            }).on('changed.owl.carousel', syncPosition);
            sync2.on('initialized.owl.carousel', function () {
                sync2.find(".owl-item").eq(0).addClass("current");
            }).owlCarousel({
                items : slidesPerPage,
                dots: false,
                nav: false,
                mouseDrag: false,
                smartSpeed: 200,
                responsiveRefreshRate : 100
            }).on('changed.owl.carousel', syncPosition2);
        }
        function syncPosition(el) {
           var count = el.item.count-1;
            var current = Math.round(el.item.index - (el.item.count/2) - .5);
            if(count < 2){ current = Math.round(el.item.index - (el.item.count)); }
            sync2.find(".owl-item").removeClass("current").eq(current).addClass("current");
            var onscreen = sync2.find('.owl-item.active').length - 1;
            var start = sync2.find('.owl-item.active').first().index();
            var end = sync2.find('.owl-item.active').last().index();
            if (current > end) { sync2.data('owl.carousel').to(current, 100, true); }
            if (current < start) { sync2.data('owl.carousel').to(current - onscreen, 100, true); }
        }
        function syncPosition2(el) {
            if(syncedSecondary) {
                var number = el.item.index;
                sync1.data('owl.carousel').to(number, 100, true);
            }
        }
        sync1.on('mouseenter',function(){
            $(this).closest('.owl-carousel').trigger('stop.owl.autoplay');
        });
        sync1.on('mouseleave',function(){
            $(this).closest('.owl-carousel').trigger('play.owl.autoplay',[500]);
        });
        sync2.on("click", ".owl-item", function(e){
            e.preventDefault();
            var number = $(this).index();
            sync1.data('owl.carousel').to(number, 300, true);
        });

        /*SLIDE CATE*/
        if ($(".fsicte").length > 0) {
            slCate.init();
        }

        /*Popover sale*/
        $(document).on('click','.fs-iclbkm',function(e){
            $(".fsicte .item").removeClass('fshows');
            $(this).parent().addClass('fshows');
            e.stopPropagation();
        });
        $(document).on('click',function(){
            $(".fsicte .item").removeClass('fshows');
        });

	});
})(window.jQuery);