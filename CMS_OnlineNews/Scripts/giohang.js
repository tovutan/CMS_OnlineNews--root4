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
        /*SLIDE CATE*/
        if ($(".fsicte").length > 0) {
            slCate.init();
        }

        $(document).on('click','.fsghbtn',function(){
            var $button = $(this);
            var oldValue = $button.parent().find("input").val();
            if ($button.text() == "+") {
                var newVal = parseFloat(oldValue) + 1;
            } else {
                if (oldValue > 1) {
                    var newVal = parseFloat(oldValue) - 1;
                } else {
                    newVal = 1;
                }
            }
            $button.parent().find("input").val(newVal);
        });

    });
})(window.jQuery);