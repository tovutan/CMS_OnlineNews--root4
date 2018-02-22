(function($){
    var slCate = {
        init: function () {
            slCate.events();
        },
        events: function () {
            $('.fsicte').each(function(index, element){
                var $this = $(this);
                i = $this.attr('data-items');
                function ctitem(i){
                    n= "false";
                    if (i==1){
                        n= "true";
                        return n;
                    }
                };
                $this.owlCarousel({
                    items : i,
                    margin: 0,
                    nav: true,
                    navText: '',
                    dots: false,
                    lazyLoad: true,
                    autoplaySpeed: 1500,
                    autoplayTimeout: 5000,
                    autoplayHoverPause: true,
                    autoplay: ctitem(i),
                    loop: ctitem(i)
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

        /*SLIDE CATE*/
        if ($(".fsicte").length > 0) {
            slCate.init();
        }

        /*Popover sale*/
        $(document).on('click','.fs-iclbkm',function(e){
            $(".fsicte .item,.fs-ilap-labelbox,.fs-lpitem,.fs-lpil-if,.fs-ilap-if").removeClass('fshows');
            $(this).parent().addClass('fshows');
            e.stopPropagation();
        });
        $(document).on('click',function(){
            $(".fsicte .item,.fs-ilap-labelbox,.fs-lpitem,.fs-lpil-if,.fs-ilap-if").removeClass('fshows');
        });

        /*Changer view cate*/
        $(document).on('click','.fs-vgrid',function(){
            $('.fs-ctf-hrview li').removeClass("active");
            $(this).parent().addClass("active");
            $(".fs-carow").removeClass('viewlist').addClass('viewgrid');
        });
        $(document).on('click','.fs-vlist',function(){
            $('.fs-ctf-hrview li').removeClass("active");
            $(this).parent().addClass("active");
            $(".fs-carow").removeClass('viewgrid').addClass('viewlist');
        });
	});
})(window.jQuery);