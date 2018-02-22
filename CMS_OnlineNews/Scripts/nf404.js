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
                    margin: 20,
                    nav: true,
                    navText: '',
                    dots: false,
                    lazyLoad: true
                });
            });
        }
    };

	$(document).ready(function (){
        if ($(".fsicte").length > 0) {
            slCate.init();
        }
	});
})(window.jQuery);