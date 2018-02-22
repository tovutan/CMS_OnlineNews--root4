(function($){
    $(document).ready(function (){
        /*search*/
        $(document).on('focus','.fs-stxt',function(){
            $(".fs-sresult").show();
        });
        $(document).on('focusout','.fs-stxt',function(){
            $(".fs-sresult").hide();
        });

        $(document).on('click','.fs-bh-btn',function(){
            $(".fs-bh-load").show();
            setTimeout(function(){
                $(".fs-bh-load,.fs-bh-check").hide();
                $(".fs-bh-info").show();
            }, 2500);
        });
        $(document).on('click','.fs-bhif-back',function(){
            $(".fs-bh-check").show();
            $(".fs-bh-info").hide();
        });

    });
})(window.jQuery);