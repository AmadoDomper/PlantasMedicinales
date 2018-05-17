(function ($) {
    $.fn.Ventana = function (m) {
        m = m || {};
        m.id = m.id || ""; //OK
        m.titulo = m.titulo || "Ventana - Sin Titulo"; //OK
        m.funcion = m.funcion || function () { };
        m.funcionCerrar = m.funcionCerrar || function () { };
        m.tamano = m.tamano || "";
        m.cuerpo = m.cuerpo || "";
        m.focusOpen = m.focusOpen || "";
        m.focusClose = m.focusClose || "";

        var cssModal = "modal-dialog";

        switch (m.tamano) {
            case "sm": cssModal += " modal-sm"; break
            case "md": cssModal += " modal-md"; break
            case "lg": cssModal += " modal-lg"; break
        }

        var html = "";
        html += '<div class="modal fade" id="' + m.id + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-focus-on="input:first">' +
                    '<div class="' + cssModal + '">' +
                       '<div class="panel panel-inverse">' +
                           '<div class="panel-heading">' +
                                    m.titulo +
                               '<button type="button" class="close" data-dismiss="modal" aria-hidden="true" style="margin-top: 0px;">&times;</button>' +
                           '</div>' +
                           '<div class="panel-body">' + m.cuerpo +
                           '</div>' +
                       '</div>' +
                   '</div>' +
               '</div>'

        $(html).appendTo('body');

        $("div#" + m.id).on('hidden.bs.modal', function (e) {
            $("div#" + m.id).remove();
            m.funcionCerrar();
            $("#" + m.focusClose).focus();
        });

        $('.modal').on('show.bs.modal', function (event) {
            var idx = $('.modal:visible').length;
            $(this).css('z-index', 1050 + (10 * idx));
        });

        $('.modal').on('shown.bs.modal', function (event) {
            var idx = ($('.modal:visible').length) - 1; // raise backdrop after animation.
            //$('.modal-backdrop').not('.stacked').css('z-index', 1049 + (10 * idx));
            $('.modal-backdrop').not('.stacked').addClass('stacked');
            $("#" + m.focusOpen).focus();
        });
    }
})(jQuery);