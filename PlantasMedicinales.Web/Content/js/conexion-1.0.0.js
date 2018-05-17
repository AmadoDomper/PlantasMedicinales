(function ($) {
    $.fn.Conexion = function (m) {

        var terminado = m.terminado || function () { };
        var durante = m.durante || function () { };
        var fError = m.error || function () { };
        var bloqueo = m.bloqueo || false;
        var async = m.async || true;
        var contentType = m.contentType || "application/x-www-form-urlencoded; charset=UTF-8";
        
        
        
        var resultadoajax;

        if (bloqueo) { BloquearCarga(); }

        $.ajax({
            type: "POST",
            async: async,
            url: m.direccion,
            data: m.datos,
            contentType: m.contentType,
            beforeSend: function () { durante() },
            error: function (v, status) { fError(v, status) },
            success: function (data) {
                if (bloqueo) { DesbloquearCarga(); }
                terminado(data);
                resultadoajax = data;
            }
        });
    }
})(jQuery);


function BloquearCarga() {

    var html = "";
    html = ('<div id="vntEspera" class="modal fade espera" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true" data-backdrop="static" data-keyboard="true"> <div class="modal-dialog modal-sm"> <div class="modal-content"> <div class="row"> <div class="col-xs-3 col-sm-3 col-md-3 col-lg-12"> <div class="spinnerX"><div class="rect1"></div> <div class="rect2"></div> <div class="rect3"></div> <div class="rect4"></div> <div class="rect5"></div> </div></div>  </div> <div class="row"><div class="col-xs-3 col-sm-3 col-md-3 col-lg-12"> <p style="text-align:center;font-size: 14px;"> Procesando... </p> </div></div></div> </div> </div>');
    $(html).appendTo('body');
    $("#vntEspera").modal('show');
}

function DesbloquearCarga() {
    $("#vntEspera").modal('hide');
    //$('.modal.in').modal('hide')
    //$("div#vntEspera").remove();
    //$(".modal-backdrop").remove();
}