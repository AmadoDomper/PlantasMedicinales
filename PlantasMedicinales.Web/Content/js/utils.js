function esDecimal(n) {
    return n.match(/^-?[0-9]+([.][0-9]*)?$/);
}

(function ($) {
    $.fn.addPoligono = function (t) {
        t.alAceptar = t.alAceptar || function (lsLat,lsLng) { };


        var html = '<div id="myModal" class="modal fade">' +
                    '<div class="modal-dialog">' +
                        '<div class="modal-content">' +
                            '<div class="modal-header">' +
                                '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                '<h4 class="modal-title">Ingrese el polígono</h4>' +
                            '</div>' +
                            '<div class="modal-body">' +
                                '<p class="text-warning">Ingresa las coordenadas (Lat, Lng)</p>' +
                                '<p class="text-warning"><small>Debe usar el sistema de referencia EPSG:4326</small></p>' +

                                '<div class="row"><div class="col-lg-9"></div>' +
                                    '<div class="col-lg-3">' +
                                    '<button type="button" id="mdaddpoint_btaddpunto" class="btn btn-success btn-block">Agregar vértice</button>' +
                                '</div></div>'+

                                '<div class="row" id="mdaddpoint_dvPuntos">' +
                                       //aqui van las fila de los puntos
                                '</div>' +

                                    '<p  class="text-warning" id="mdaddpoint_txtMsj" class="text-warning"><small></small></p>' +

                            '</div>' +
                            '<div class="modal-footer">' +
                                '<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>' +
                                '<button type="button" id="mdaddpoint_btAceptar" class="btn btn-primary">Aceptar</button>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>';

        var m = $(html);
        $(m).modal()
        m.modal('show');

        var $lat = $(m).find("#mdaddpoint_lat");
        var $lng = $(m).find("#mdaddpoint_lng");
        var $dv = null;
        var nVert = 0;
        $(m).find("#mdaddpoint_btaddpunto").click(function () {
            nVert++;
            $dv = $(m).find("#mdaddpoint_dvPuntos");
            var html = '<div id="mdaddpoint_fila_' + nVert + '">'+
                       '<div class="col-md-5"><div class="form-group"><label>Lat</label><input type="text" class="form-control mdaddpoint_lat" placeholder="Lat"></div></div>' +
                       '<div class="col-md-5"><div class="form-group"><label>Lng</label><input type="text" class="form-control mdaddpoint_lng" placeholder="Lng"></div></div>' +
                       '<div class="col-md-2"><div class="form-group"><label>&nbsp;&nbsp;&nbsp;</label><button type="button" class="btn btn-primary btn-warning btquitar" data-id="' + nVert + '">Quitar</button></div></div></div>';
            $fila = $(html);
            $dv.append($fila);
            $fila.find('.btquitar').click(function () {
                var id=$(this).data('id');
                $("#mdaddpoint_fila_"+id).remove();
            });
        });


        
        
        
        $(m).find("#mdaddpoint_btAceptar").click(function () {
            var lsLats = Array();
            var lsLngs = Array();

            var lats = $(m).find(".mdaddpoint_lat")

            if (lats.length >= 2) {

                for (var i = 0; i < lats.length; i++) {
                    lsLats.push($(lats[i]).val())
                }
                var lngs = $(m).find(".mdaddpoint_lng")
                for (var i = 0; i < lngs.length; i++) {
                    lsLngs.push($(lngs[i]).val())
                }

                //validar el formato decimal
                var sonDecimales = true;
                for (var i = 0; i < lngs.length; i++) {
                    if (!esDecimal(lsLngs[i]) || !esDecimal(lsLats[i])) {
                        sonDecimales = false;
                        break;
                    }
                }
                if (!sonDecimales) {
                    $(m).find("#mdaddpoint_txtMsj").html('Los datos deben ser números en formato decimal');
                }
                else {
                    t.alAceptar(lsLats, lsLngs);
                    console.log(lsLats);
                    console.log(lsLngs);
                }
            }
            else {
                $(m).find("#mdaddpoint_txtMsj").html('El polígono debe tener por lo menos 2 vertices');
            }

        });
    }
})(jQuery);



(function ($) {
    $.fn.addPunto = function (t) {
        t.alAceptar = t.alAceptar|| function (x,y) { } ;


        var html = '<div id="myModal" class="modal fade">' +
                    '<div class="modal-dialog">' +
                        '<div class="modal-content">' +
                            '<div class="modal-header">' +
                                '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                '<h4 class="modal-title">Ingrese el punto</h4>' +
                            '</div>' +
                            '<div class="modal-body">' +
                                '<p class="text-warning">Ingresa las coordenadas (Longitud, Latitud)</p>' +
                                '<p class="text-warning"><small>Debe usar el sistema de referencia EPSG:4326</small></p>' +
                                '<div class="row">' +
                                      '<div class="col-md-6"><div class="form-group"><label>Longitud: </label><input type="text" class="form-control" placeholder="Longitud" id="mdaddpoint_lng"></div></div>' +
                                      '<div class="col-md-6"><div class="form-group"><label>Latitud: </label><input type="text" class="form-control" placeholder="Latitud" id="mdaddpoint_lat"></div></div>' +
                                '</div>' +
                                
                                    '<p  class="text-warning" id="mdaddpoint_txtMsj" class="text-warning"><small></small></p>' +
                                
                            '</div>' +
                            '<div class="modal-footer">' +
                                '<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>' +
                                '<button type="button" id="mdaddpoint_btAceptar" class="btn btn-primary">Aceptar</button>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>';

        var m = $(html);
        $(m).modal()
        m.modal('show');

        var $lat = $(m).find("#mdaddpoint_lat");
        var $lng = $(m).find("#mdaddpoint_lng");

        $(m).find("#mdaddpoint_btAceptar").click(function () {
            $(m).find("#mdaddpoint_txtMsj").html('');
            if (esDecimal($lat.val()) && esDecimal($lng.val())) {
                t.alAceptar($lat.val(),$lng.val());
            }
            else {
                $(m).find("#mdaddpoint_txtMsj").html('Los datos deben ser números en formato decimal');
            }
            
        });
    }
})(jQuery);


(function ($) {
    $.fn.addLinea = function (t) {
        t.alAceptar = t.alAceptar || function (x1,y1,x2,y2) { };


        var html = '<div id="myModal" class="modal fade">' +
                    '<div class="modal-dialog">' +
                        '<div class="modal-content">' +
                            '<div class="modal-header">' +
                                '<button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>' +
                                '<h4 class="modal-title">Ingrese la línea</h4>' +
                            '</div>' +
                            '<div class="modal-body">' +
                                '<p class="text-warning">Ingresa las coordenadas (Lat, Lng)</p>' +
                                '<p class="text-warning"><small>Debe usar el sistema de referencia EPSG:4326</small></p>' +
                                '<div class="row">' +


                                      '<div class="col-md-6"><div class="form-group"><label>Lat1: </label><input type="text" class="form-control" placeholder="Lat1" id="mdaddpoint_lat1"></div></div>' +
                                      '<div class="col-md-6"><div class="form-group"><label>Lng1: </label><input type="text" class="form-control" placeholder="Lng2" id="mdaddpoint_lng1"></div></div>' +
                                      '<div class="col-md-6"><div class="form-group"><label>Lat2: </label><input type="text" class="form-control" placeholder="Lat1" id="mdaddpoint_lat2"></div></div>' +
                                      '<div class="col-md-6"><div class="form-group"><label>Lng2: </label><input type="text" class="form-control" placeholder="Lng2" id="mdaddpoint_lng2"></div></div>' +

                                '</div>' +

                                    '<p  class="text-warning" id="mdaddpoint_txtMsj" class="text-warning"><small></small></p>' +

                            '</div>' +
                            '<div class="modal-footer">' +
                                '<button type="button" class="btn btn-default" data-dismiss="modal">Cerrar</button>' +
                                '<button type="button" id="mdaddpoint_btAceptar" class="btn btn-primary">Aceptar</button>' +
                            '</div>' +
                        '</div>' +
                    '</div>' +
                '</div>';

        var m = $(html);
        $(m).modal()
        m.modal('show');

        var $lat1 = $(m).find("#mdaddpoint_lat1");
        var $lng1 = $(m).find("#mdaddpoint_lng1");
        var $lat2 = $(m).find("#mdaddpoint_lat2");
        var $lng2 = $(m).find("#mdaddpoint_lng2");

        $(m).find("#mdaddpoint_btAceptar").click(function () {
            $(m).find("#mdaddpoint_txtMsj").html('');
            if (esDecimal($lat1.val()) &&  esDecimal($lng1.val()) &&  esDecimal($lat2.val()) && esDecimal($lng2.val())) {
                t.alAceptar($lat1.val(), $lng1.val(), $lat2.val(), $lng2.val());
            }
            else {
                $(m).find("#mdaddpoint_txtMsj").html('Los datos deben ser números en formato decimal');
            }

        });
    }
})(jQuery);




(function ($) {
    $.fn.dropdowlist = function (m) {

        m.dataShow = m.dataShow || "";
        m.dataValue = m.dataValue || "";
        m.dataselect = m.dataselect || "";
        m.datalist = m.datalist || null;
        m.contenedor = m.contenedor || this;
        m.placeholder = m.placeholder || 'Elige una opción'

        $(m.contenedor).html('');

        m.contenedor.append('<option value="">' + m.placeholder + '</option>');

        for (var i = 0; i < m.datalist.length; i++) {
            if (m.dataselect != "") {
                if (m.dataselect == eval("m.datalist[i]." + m.dataValue)) {
                    m.contenedor.append('<option data-index="' + i + '" value="' + eval("m.datalist[i]." + m.dataValue) + '" selected="true" datashow="' + eval("m.datalist[i]." + m.dataShow) + '">' + eval("m.datalist[i]." + m.dataShow) + '</option>');
                }
                else {
                    m.contenedor.append('<option data-index="' + i + '" value="' + eval("m.datalist[i]." + m.dataValue) + '"  datashow="' + eval("m.datalist[i]." + m.dataShow) + '">' + eval("m.datalist[i]." + m.dataShow) + '</option>');
                }
            }
            else {

                m.contenedor.append('<option data-index="' + i + '" value="' + eval("m.datalist[i]." + m.dataValue) + '"  datashow="' + eval("m.datalist[i]." + m.dataShow) + '">' + eval("m.datalist[i]." + m.dataShow) + '</option>');
            }
        }
    }
})(jQuery);
