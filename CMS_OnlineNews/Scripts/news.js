(function($){
    var slCate = {
        init: function () {
            slCate.events();
        },
        events: function () {
            $('.fsvdct').each(function(index, element){
                var $this = $(this);
                $this.swiper({
                    paginationClickable: true,
                    preventClicks: false,
                    slidesPerView: 4,
                    spaceBetween: 10,
                    nextButton: $this.parent().find(".fsvdct-next")[0],
                    prevButton: $this.parent().find(".fsvdct-prev")[0]
                });
            });
        }
    };

	$(document).ready(function (){
        if ($(".fsvdct").length > 0) {
            slCate.init();
        }

	});
})(window.jQuery);