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
                    margin: 0,
                    nav: true,
                    navText: '',
                    dots: false,
                    lazyLoad: true
                });
            });
        }
    };

    var sldtsld = {
        init: function () {
            sldtsld.events();
        },
        events: function () {
            $('.fsdtsld').each(function(index, element){
                var $this = $(this);
                i = $this.attr('data-items');
                $this.owlCarousel({
                    items : i,
                    margin: 0,
                    nav: true,
                    navText: '',
                    dots: true
                });
            });
        }
    };

    var avatas = {
        init: function () {
            avatas.events();
        },
        events: function () {
            $('.fhdcmtava').textAvatar({
                width: 30
            });
        }
    };

    var slDtImg = {
        init: function () {
            slDtImg.events();
        },
        events: function () {
            $(".fancybox-thumb").fancybox({
                prevEffect	: 'none',
                nextEffect	: 'none',
                helpers	: {
                    title	: {
                        type: 'outside'
                    },
                    thumbs	: {
                        width	: 120,
                        height	: 80
                    }
                }
            });

        }
    };

    var slDtVideo = {
        init: function () {
            slDtVideo.events();
        },
        events: function () {
            $(".various").fancybox({
                maxWidth	: 800,
                maxHeight	: 600,
                fitToView	: false,
                width		: '70%',
                height		: '70%',
                autoSize	: false,
                closeClick	: false,
                openEffect	: 'none',
                closeEffect	: 'none'
            });
        }
    };

    var cddetail = {
        init: function () {
            cddetail.events();
        },
        events: function () {
            $(".fs-cdos")
                .countdown("2018/01/01", function(event) {
                    $(this).html(
                        event.strftime('%D <span>NGÀY</span> %H : %M : %S')
                    );
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

        /*countdown prod*/
        if ($(".fs-cdos").length > 0) {
            cddetail.init();
        }

        /*zoom img*/
        var $easyzoom = $('.easyzoom').easyZoom();
        var api1 = $easyzoom.filter('.easyzoom--with-thumbnails').data('easyZoom');

        $('.thumbnails').on('click', 'a', function(e) {
            var $this = $(this);
            e.preventDefault();
            $('.thumbnails li').removeClass('active');
            $this.parent().addClass('active');
            api1.swap($this.data('standard'), $this.attr('href'));
        });

        /*Slide img detail*/
        if ($(".fancybox-thumb").length > 0) {
            slDtImg.init();
        }

        /*video detail*/
        if ($(".various").length > 0) {
            slDtVideo.init();
        }

        /*SLIDE CATE*/
        if ($(".fsicte").length > 0) {
            slCate.init();
        }

        /*SLIDE DETAIL*/
        if ($(".fsdtsld").length > 0) {
            sldtsld.init();
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

        /*scroll*/
        $('a[toscroll]').click(function(){
            var link = $(this).attr('href');
            $('.fs-dttabs li').removeClass('active');
            $(this).parent().addClass('active');
            if($(link).length > 0){
                var posi = $(link).offset().top;
                $('body,html').animate({scrollTop:posi-50},1000);
            }
        });
        var scrollheight = $('.fs-header').height() + $('.fs-breadcrumb').height() + $('.fs-dtprodif').height()+ $('.fs-dtprodsame').height() + 50;
        $(window).bind('scroll', function () {
            if ($(window).scrollTop() > scrollheight) {
                $('.fs-dttabsmain').addClass('fs-dttabfix');
            } else {
                $('.fs-dttabsmain').removeClass('fs-dttabfix');
            }
        });

        /*tab cate*/
        $(document).on('click','#fs-dttabsl li a',function(e){
            e.preventDefault();
            $(this).parent().addClass("active");
            $(this).parent().siblings().removeClass("active");
            var tab = $(this).attr("href");
            $(".fs-dttabi").not(tab).css("display", "none");
            $(tab).fadeIn();
            slCate.init();
        });

        /*view more*/
        $(document).on('click','.fs-dtcvmo span',function(){
            $(this).parent().parent().addClass('dtshow');
        });

        /*view rate*/
        $(document).on('click','.fs-dtrtbtnnx span,.fs-dttranobtn',function(){
            $('.fs-dtrtcmt').slideDown();
        });
        $(document).on('click','.fs-dtrtbot-huy',function(){
            $('.fs-dtrtcmt').slideUp();
        });


        /*form nhan thong tin*/
        $(document).on('click','.fs-dtbtnnp',function(){
            $('.fs-dtpnoti,.fs-dtprice,.fs-dtich,.fs-dticolor,.fs-dtbtns,.fs-dtnsbot').hide();
            $('.fs-feback').show();
        });

        /*comment*/
        if ($(".fhdcmtava").length > 0) {
            avatas.init();
        }
        $('input.fs-cmbtnfile[type=file]').change(function(){
            $(this).simpleUpload("/", {
                allowedExts: ["jpg", "jpeg", "jpe", "jif", "jfif", "jfi", "png", "gif"],
                allowedTypes: ["image/pjpeg", "image/jpeg", "image/png", "image/x-png", "image/gif", "image/x-gif"],
                maxFileSize: 5000000, //5MB in bytes
                start: function(file){
                    //upload started
                    this.block = $('<div class="block"><span class="delbtn">×</span></div>');
                    this.progressBar = $('<div class="progressBar"></div>');
                    this.cancelButton = $('<div class="cancelButton">×</div>');
                    var that = this;
                    this.cancelButton.click(function(){
                        that.upload.cancel();
                        //now, the cancel callback will be called
                    });
                    this.block.append(this.progressBar).append(this.cancelButton);
                    $('#uploads').append(this.block);
                },
                progress: function(progress){
                    //received progress
                    this.progressBar.width(progress + "%");
                },
                success: function(data){
                    //upload successful
                    this.progressBar.remove();
                    this.cancelButton.remove();
                    if (data.success) {
                        //now fill the block with the format of the uploaded file
                        var format = data.format;
                        var formatDiv = $('<div class="format"></div>').text(format);
                        this.block.append(formatDiv);
                    } else {
                        //our application returned an error
                        var error = data.error.message;
                        var errorDiv = $('<div class="error"></div>').text(error);
                        this.block.append(errorDiv);
                    }

                },
                error: function(error){
                    //upload failed
                    this.progressBar.remove();
                    this.cancelButton.remove();
                    var error = error.message;
                    var errorDiv = $('<div class="error"></div>').text(error);
                    this.block.append(errorDiv);
                },
                cancel: function(){
                    //upload cancelled
                    this.block.fadeOut(400, function(){
                        $(this).remove();
                    });
                }
            });
        });



    });
})(window.jQuery);