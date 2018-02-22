(function ($) {
    $(document).ready(function () {
        //CKEDITOR.replace('FullDesc');
        //CKFinder.setupCKEditor(null, '/Plugins/ckfinder')
        CKEDITOR.config.height = 500;
        $('[data-type="select2"]').select2()
        $('[data-mask]').inputmask()
        $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' });
        $("#btnImageURL").on("click", function () {
            var finder = new CKFinder();
            //finder.basePath = '../';
            finder.selectActionFunction = SetFileField;
            finder.popup();
        });
        function SetFileField(fileUrl) {
            $("#imgImageURL").attr("src", fileUrl);
            $("input[name=AvataImage]").val(fileUrl);
        }
        $(".kendo-upload-image").kendoUpload({
            multiple: false,
            validation: {
                allowedExtensions: [".gif", ".jpg", ".png", ".jpeg"]
            }
        });
        $(".kendo-upload-image2").kendoUpload({
            async: {
                chunkSize: 11000,// bytes
                saveUrl: "chunkSave",
                removeUrl: "remove",
                autoUpload: true
            }
        });

        var url = $(".auto-gen-url");
        if (url != null)
        {
            $("[name='" + url.data("url-name") + "'").on('input', function () {
                url.val(getSlug($(this).val()));
            });
        }

        $('select.taginput').select2({
            multiple: true,
            data: $('select.taginput').data("selector"),
            ajax: {
                url: $(this).data("ajax-url"),
                dataType: 'json',
                delay: 750,
                data: function (params) {
                    return {
                        text: params.term
                    }
                }
            },
            processResults: function (data, params) {
                // parse the results into the format expected by Select2
                // since we are using custom formatting functions we do not need to
                // alter the remote JSON data, except to indicate that infinite
                // scrolling can be used
                //params.page = params.page || 1;

                return {
                    results: data,
                    //pagination: {
                    //    more: (params.page * 30) < data.total_count
                    //}
                };
            },
            cache: true,
            minimumInputLength: 1
            //    typeaheadjs: {
            //        name: 'tagname',
            //        display: 'name',
            //        source: tagsDataNames
        });
    });
})(window.jQuery);