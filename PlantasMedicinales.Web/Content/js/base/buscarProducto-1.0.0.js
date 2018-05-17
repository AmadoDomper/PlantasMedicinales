(function ($) {
    var lstBuscaProd = [];
    $.fn.BuscarProducto = function (m) {
        m = m || {};

        m.funcionCancelar = m.FuncionCancelar || function () { };
        m.valor = m.valor || null;
        m.durante = m.durante || function () { };
        m.error = m.error || function () { };
        m.focusOpen = m.focusOpen || "";
        m.focusClose = m.focusClose || "";

        var tablaId = "tblProductos";
        var btnAceptar = "#vntBuscaProducto #btnProdAceptar";
        var tabla_Id = "#" + tablaId;
        var buscarId = "txtBuscar";
        var buscar_Id = "#" + buscarId;

        BuscarProducto(m.valor);

        if (!m.valor) {
            CrearVentana("", lstBuscaProd);
        } else {
            if (lstBuscaProd.length == 1) {
                Aceptar(0);
            } else {
                CrearVentana(m.valor, lstBuscaProd);

            }
        }


        function CrearVentana(valor, lista) {
            $.fn.Ventana({
                id: "vntBuscaProducto",
                titulo: "Buscar Producto",
                tamano: "lg",
                focusOpen: buscarId,
                focusClose: m.focusClose
            });

            var html = '<div class="row"><div class="col-xs-12 col-sm-9 col-md-12 col-lg-12"><div class="form-inline ng-pristine ng-valid"><input id="txtBuscar" type="text" onclick="this.select();" class="form-control " placeholder="Buscar producto..." tabindex="1" style="border-bottom-width: 1px;margin-bottom: 10px;width: 70%;"><button id="btnBuscar" type="button" style="border-bottom-width: 1px;margin-left: 5px;margin-bottom: 10px;" class="btn btn-sm btn-default"><span class="glyphicon glyphicon-search"></span></button></div></div><div class="row"><div id="' + 'cntBuscarProducto' + '" class="col-xs-12 col-sm-12 col-md-12 col-lg-12"></div></div><div class="row"><div class="col-md-3 col-md-offset-9 text-right m-t-10"><button id="btnProdAceptar" type="submit" class="btn btn-sm btn-primary m-r-5">Aceptar</button><button id="btnProdCancelar" type="submit" data-dismiss="modal" aria-hidden="true" class="btn btn-sm btn-default">Cancelar</button></div></div>';
            $("#vntBuscaProducto .panel-body").html(html);


            CrearTabla(lista);
            $("#txtBuscar").val(valor);
            $('#vntBuscaProducto').modal('show');
        }

        function Aceptar(index) {
            if (index == -1) {
                $.fn.Mensaje({ mensaje: "No se ha seleccionado ningún Producto", tamano: "sm" });
                $(buscar_Id).focus();
            } else {
                m["funcionAceptar"](lstBuscaProd[index]);
            }
        }


        $("#vntBuscaProducto input:radio").bind("click", function () {
            focus();
        });

        $(btnAceptar).bind("click", function () {
            var index = $(tabla_Id).find("tr.seleccionado").index();
            Aceptar(index);
        });

        $("#btnProdCancelar").bind("click", function () {
            m["funcionCancelar"]();
        });

        $("#btnBuscar").bind("click", function () { Buscar(tablaId, btnAceptar); });

        $(buscar_Id).bind("keydown", function (e) {
            if (e.which == 40 || e.which == 38 || e.which == 13) { e.preventDefault(); }
        });

        $(buscar_Id).bind("keyup", function (e) {
            if (e.which == 40) {
                e.preventDefault();
                if ($(tabla_Id).find("tbody tr").length == 0) return false;
                var s = 0
                s = $(tabla_Id).find("tr.seleccionado").index();
                if (s == -1) {
                    $(tabla_Id + " tbody tr").eq(0).addClass("seleccionado");
                    //$(buscar_Id).attr("value", $(tabla_Id).find("tr").eq(1).find("td").eq(0).html()).focus();
                    $(buscar_Id).val($(tabla_Id + " tbody tr").eq(0).find("td").eq(0).html()).focus();
                } else if (s < ($(tabla_Id + " tbody tr").length - 1)) {
                    $(tabla_Id + " tbody").find("tr.seleccionado").removeClass("seleccionado");
                    $(tabla_Id + " tbody").find("tr").eq(s + 1).addClass("seleccionado");
                    //$(buscar_Id).attr("value", $(tabla_Id).find("tr").eq(s + 1).find("td").eq(0).html()).focus();
                    $(buscar_Id).val($(tabla_Id).find("tbody tr").eq(s + 1).find("td").eq(0).html()).focus();
                }
                a = $(tabla_Id).find("tr.seleccionado").index();
                if (a > 3) {
                    dif = (a - 3) * 30;
                    $(tabla_Id).parent().animate({ scrollTop: dif }, 100);
                }
            }
            else if (e.which == 38) {
                e.preventDefault();
                if ($(tabla_Id).find("tbody tr").length == 0) return false;
                var s = 0;
                s = $(tabla_Id).find("tr.seleccionado").index();
                if (s > 0) {
                    $(tabla_Id).find("tr.seleccionado").removeClass("seleccionado");
                    $(tabla_Id).find("tbody tr").eq(s - 1).addClass("seleccionado");
                    //$(buscar_Id).attr("value", $(tabla_Id).find("tr").eq(s - 1).find("td").eq(0).html()).focus();
                    $(buscar_Id).val($(tabla_Id).find("tbody tr").eq(s - 1).find("td").eq(0).html()).focus();
                };
                var ftop = $(".seleccionado").offset().top - 12;
                var dtop = $(tabla_Id).parent().offset().top;
                if (ftop < dtop) {
                    a = $(tabla_Id).find("tr.seleccionado").index();
                    dif = a * 28;
                    $(tabla_Id).parent().animate({ scrollTop: dif }, 100);
                }

            }
            else if (e.which == 13) {
                Buscar(tablaId, btnAceptar);
            }
            else {
                $("tr.seleccionado").removeClass("seleccionado");
            }
        });
    }


    function Buscar(tablaId, btnAceptar) {
        if ($("#" + tablaId).find("tr.seleccionado").index() == -1) {
            var valor = $("#txtBuscar").val();
            BuscarProducto(valor);
            CrearTabla(lstBuscaProd)
        }
        else {
            $(btnAceptar).click();
        }
    }

    function BuscarProducto(valor) {
        var cProdId, cNombre;

        valor === null ? cNombre = "" : isNaN(valor) ? cNombre = valor : cProdId = valor;

        $.fn.Conexion({
            direccion: '/Producto/BuscarProductos',
            datos: { "nProdId": cProdId, "cProdDesc": cNombre },
            async: false,
            terminado: function (data) {
                lstBuscaProd = JSON.parse(data);
            },
            error: function (v, s) { $.fn.Mensaje({ mensaje: "Realizar la busqueda nuevamente" }); }
        });
    }

    function CrearTabla(lista) {
        $("#cntBuscarProducto").Tabla({
            tblId: "tblProductos",
            scrollVertical: "Si",
            cantRegVertical: 6,
            cabecera: "Cod&iacute;go,Descripci&oacute;n,Precio Unit,Medida,Lavado,Secado,Planchado,Otros",
            campos: "nPrId,cPrDesc,nPrPrecU,oPrMed.nom,bPrSerLav,bPrSerSec,bPrSerPla,bProdO",
            alinear: "C,L,C,C,C,C,C,C",
            cellLen: "50,320,80,55,55,55,80,0",
            tipoCampo: ",,D,,,,,,",
            datos: lista
        });
        IniciaTabla();
    }

    function IniciaTabla() {
        if (lstBuscaProd.length == 0) {
            $("#btnProdAceptar").addClass("disabled");
        } else {
            $("#btnProdAceptar").removeClass("disabled");
            $("#tblProductos").parent().scrollTop(0);

            $("#tblProductos tbody tr").bind({
                "dblclick": function () {
                    $("#btnProdAceptar").click();
                }
            });

            $(".seleccionado").bind("click", function () {
                $("#btnProdAceptar").click();
            });
        }
    }

})(jQuery);