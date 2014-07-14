$(function () {

    var searchAjaxSubmit = function () {
        $form = $(this);


        var options = {
            type: $form.attr("method"),
            url: $form.attr("action"),
            data: $form.serialize()
        };


        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-otf-target"));
            $target.replaceWith(data);
            // we can add effects here!, do any manipulations that we want

        });

        return false;
    }


    var createAutoComplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-otf-autocomlete")
        };

        $input.autocomplete(options);

    }

    $("form[data-otf-ajax='true']").submit(searchAjaxSubmit);
    $("input[data-otf-autocomlete]").each(createAutoComplete);

    $('#slides').slidesjs({
        width: 960,
        height: 310,
        navigation: {
            active: false,
            effect: "slide"
        },
        pagination: {
            active: false,
            effect: "slide"
        },
        play: {
            active: false,
            effect: "slide",
            interval: 5000,
            auto: true,
            swap: true,
            pauseOnHover: false,
            restartDelay: 2500
        },
    });

    $("input[data-spin-product-id]").each(
        function () {
            $input = $(this);
            $input.spinedit({
                minimum: 1,
                maximum: 100,
                step: 1,
                value: 1,
                numberOfDecimals: 0
            });
        });
});