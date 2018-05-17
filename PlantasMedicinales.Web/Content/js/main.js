function CrearLista(id, datos, bAgro) {
    bAgro = bAgro || false;
    html = "";
    datamin = "";
    html += '<option data-index="-1" value="">-SELECCIONE-</option>';

    for (i in datos) {
        datamin = ""
        if (!(typeof (datos[i].min) === 'undefined' || datos[i].min == null) && bAgro) {
            datamin = 'data-min="' + datos[i].min + '"';
        }

        html += '<option data-index="' + i + '" value="' + datos[i].id + '" ' + datamin + '>' + datos[i].nom + '</option>';
    }
    $(id).html(html)
}

function CrearSubLista(idIni, idSec, lista, bAgro) {
    bAgro = bAgro || false;

    var Listar = function () {
        var sub;
        var indice = $(idIni).find('option:selected').attr('data-index');

        if (indice == "-1") { sub = []; } else { sub = lista[indice].sub }
        CrearLista(idSec, sub, bAgro);
    };
    Listar();
    $("body").on("change", idIni, function () {
        Listar();
    });
}

function number_format(number, decimals, dec_point, thousands_sep) {
    var n = !isFinite(+number) ? 0 : +number,
        prec = !isFinite(+decimals) ? 0 : Math.abs(decimals),
        sep = (typeof thousands_sep === 'undefined') ? ',' : thousands_sep,
        dec = (typeof dec_point === 'undefined') ? '.' : dec_point,
        s = '',
        toFixedFix = function (n, prec) {
            var k = Math.pow(10, prec);
            return '' + Math.round(n * k) / k;
        };
    // Fix for IE parseFloat(0.55).toFixed(0) = 0;
    s = (prec ? toFixedFix(n, prec) : '' + Math.round(n)).split('.');
    if (s[0].length > 3) {
        s[0] = s[0].replace(/\B(?=(?:\d{3})+(?!\d))/g, sep);
    }
    if ((s[1] || '').length < prec) {
        s[1] = s[1] || '';
        s[1] += new Array(prec - s[1].length + 1).join('0');
    }
    return s.join(dec);
}

function formatDate(dateValue, format) {
    var fmt = format.toUpperCase();
    var re = /^(M|MM|D|DD|YYYY)([-/]{1})(M|MM|D|DD|YYYY)(2)(M|MM|D|DD|YYYY)$/;
    //if (!re.test(fmt)) { fmt = "MM/DD/YYYY"; }
    if (fmt.indexOf("M") == -1) { fmt = "MM/DD/YYYY"; }
    if (fmt.indexOf("D") == -1) { fmt = "MM/DD/YYYY"; }
    if (fmt.indexOf("YYYY") == -1) { fmt = "MM/DD/YYYY"; }
    var M = "" + (dateValue.getMonth() + 1);
    var MM = "0" + M;
    MM = MM.substring(MM.length - 2, MM.length);
    var D = "" + (dateValue.getDate());
    var DD = "0" + D;
    DD = DD.substring(DD.length - 2, DD.length);
    var YYYY = "" + (dateValue.getFullYear());
    var sep = "/";
    if (fmt.indexOf("-") != -1) { sep = "-"; }
    var pieces = fmt.split(sep);
    var result = "";

    switch (pieces[0]) {
        case "M": result += M + sep; break;
        case "MM": result += MM + sep; break;
        case "D": result += D + sep; break;
        case "DD": result += DD + sep; break;
        case "YYYY": result += YYYY + sep; break;
    }

    switch (pieces[1]) {
        case "M": result += M + sep; break;
        case "MM": result += MM + sep; break;
        case "D": result += D + sep; break;
        case "DD": result += DD + sep; break;
        case "YYYY": result += YYYY + sep; break;
    }
    switch (pieces[2]) {
        case "M": result += M; break;
        case "MM": result += MM; break;
        case "D": result += D; break;
        case "DD": result += DD; break;
        case "YYYY": result += YYYY; break;
    }
    return result;
}

function SetRangoFecha(id) {
    $(id).datepicker({
        format: "dd/mm/yyyy",
        weekStart: 1,
        todayBtn: "linked",
        language: "es",
        daysOfWeekHighlighted: "0",
        autoclose: true,
        toggleActive: true
    });
}

function SetFecha(id) {
    $(id).datepicker({
        format: "dd/mm/yyyy",
        weekStart: 1,
        todayBtn: "linked",
        language: "es",
        daysOfWeekDisabled: "0",
        daysOfWeekHighlighted: "0",
        autoclose: true,
        toggleActive: true
    });
}

function val_09(e) {
    tecla = (document.all) ? e.keyCode : e.which;
    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    // else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /[0-9]/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_09D(e) {
    tecla = (document.all) ? e.keyCode : e.which;

    if (tecla == 8) return true;
    else if (tecla == 0) return true;
    else if (tecla == 9) return true;
    else if (tecla == 46) return true;
    // else if (tecla == e.keyCode || tecla == e.which) return true;
    patron = /^[-+]?[0-9]+(\.[0-9]{2})?$/;
    te = String.fromCharCode(tecla);
    return patron.test(te);
}

function val_09DC(e, field) {
    key = e.keyCode ? e.keyCode : e.which
    // backspace
    if (key == 8) return true
    if (key == 0) return true
    // 0-9
    if (key > 47 && key < 58) {
        if (field.value == "") return true
        regexp = /[.][0-9]{2}$/
        return !(regexp.test(field.value))
    }
    // .
    if (key == 46) {
        if (field.value == "") return false
        regexp = /^[0-9]+$/
        return regexp.test(field.value)
    }
    // other key
    return false


}

function CrearHidden(contenedor, name, valor) {
    $(contenedor).append("<input type='hidden' name='" + name + "' value='" + valor + "' />");
}

function ObtenerIndiceLista(lista, valor) {
    var indice = -1;
    for (i in lista) {
        if (lista[i].id == valor) {
            indice = i;
            break;
        }
    }
    return indice;
}

function ImpedirCopiarCortarPegar() {
    $("input").attr("onpaste", "return false");
    $("input").attr("oncut", "return false");
    $("input").attr("oncopy", "return false");
}

function restaFechas(f1, f2) {
    var aFecha1 = f1.split('/');
    var aFecha2 = f2.split('/');
    var fFecha1 = Date.UTC(aFecha1[2], aFecha1[1] - 1, aFecha1[0]);
    var fFecha2 = Date.UTC(aFecha2[2], aFecha2[1] - 1, aFecha2[0]);
    var dif = fFecha2 - fFecha1;
    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
    return dias;
}

function sumaFecha(d, fecha) {
    var Fecha = new Date();
    var sFecha = fecha || (Fecha.getDate() + "/" + (Fecha.getMonth() + 1) + "/" + Fecha.getFullYear());
    var sep = sFecha.indexOf('/') != -1 ? '/' : '-';
    var aFecha = sFecha.split(sep);
    var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
    fecha = new Date(fecha);
    fecha.setDate(fecha.getDate() + parseInt(d));
    var anno = fecha.getFullYear();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();
    mes = (mes < 10) ? ("0" + mes) : mes;
    dia = (dia < 10) ? ("0" + dia) : dia;
    var fechaFinal = dia + sep + mes + sep + anno;
    return (fechaFinal);
}

//$(function () {
//    $(window).bind("load resize", function () {
//        $header = $('header').height();
//        $nav = $('nav').height() + 1;
//        $footer = $('footer').height();

//        topOffset = 50;
//        height = (this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height;
//        height = height - ($header + $nav + $footer);
//        if (height < 1) height = 1;
//        if (height > topOffset) {
//            $('div#contenido').css("min-height", (height) + "px");
//        }val_09(event)
//    })
//})

function alerta($id, $msg) {
    $($id).html('<div class="alert alert-danger alert-dismissible text-center" role="alert" style="margin-bottom: 10px;"><button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">x</span><span class="sr-only">Close</span></button><strong>Error! </strong>' + $msg + '</div>');
}

function advertencia($id, $msg) {
    $($id).html('<div class="alert alert-warning alert-dismissible text-center" role="alert" style="margin-bottom: 10px;"><button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">x</span><span class="sr-only">Close</span></button><strong>Advertencia! </strong>' + $msg + '</div>');
}

function hCombos() {
    this.ids = [];
    this.info = [];
    this.num = {};
    this.objs = [];
    this.pre = [];
    this.ocupado = false;

    this.init = function () {
        var clase = this;
        var id, obj;
        for (var n = 0; n < this.ids.length; n++) {
            id = this.ids[n];
            this.num[id] = n;
            obj = document.getElementById(id);
            if (n != this.ids.length - 1) {
                obj.onchange = function () {
                    if (clase.ocupado == false) {
                        clase.ocuapo == true;
                        clase.change(this, this.id);
                        clase.ocupado = false;
                    }
                };
            }
            this.objs.push(obj);
        }
        this.refreshOpts(0, this.info);

        if (this.pre.length > 0) {
            var combo, options;
            for (var n = 0; n < this.pre.length; n++) {
                combo = this.objs[n];
                options = combo.getElementsByTagName("option");
                for (var m = 0; m < options.length; m++) {
                    if (options[m].value == this.pre[n]) {
                        options[m].selected = "selected";
                        if (combo.onchange) combo.onchange();
                    }
                }
            }
        }

    };

    this.change = function (obj, id) {
        var arbol = this.info;
        var numNivel = this.num[id];
        var arbolDes = '';
        var arbolId = '';
        var arbolHijo = {};
        var restantes = 0;

        for (var n = 0; n < this.ids.length; n++) {
            arbolId = this.objs[n].selectedIndex - 1;
            if (arbolId == -1) {
                restantes = n + 1;
                break;
            }

            if (arbolId > -1) {
                arbolDes = arbol[arbolId].nom;
            }

            if (n == numNivel) {
                this.refreshOpts(n + 1, arbol[arbolId].sub);
            }

            arbol = arbol[arbolId].sub;
        }
        if (restantes < this.ids.length)
            for (var n = restantes; n < this.ids.length; n++) {
                this.refreshOpts(n, []);
            }
    };

    this.refreshOpts = function (nCombo, valores) {
        if (!this.objs[nCombo]) return;
        var combo = this.objs[nCombo];
        var preVal = combo.value;
        combo.innerHTML = '';

        var opt = this.newOpt('', '-SELECCIONE-');
        combo.appendChild(opt);

        for (x in valores) {
            opt = this.newOpt(valores[x].id, valores[x].nom);
            combo.appendChild(opt);
        }
    };

    this.newOpt = function (value, innerHTML) {
        var opt = document.createElement('option');
        opt.value = value;
        opt.innerHTML = innerHTML;
        return opt;
    };
};

function LimpiaOptCombos(combos) {
    opt = '<option data-index="-1" value="">-SELECCIONE-</option>';
    for (var i = 0; i < combos.length; i++) {
        $("#" + combos[i]).html(opt);
    }
}
function ObtenerDetUbigeo(cod, combo) {
    $.fn.Conexion({
        direccion: '/Constante/ObtenerDetUbigeo',
        datos: { cod: cod },
        terminado: function (data, textStatus, jqXHR) {
            CrearLista("#" + combo, JSON.parse(data));
        }
    });
}


function decimalAdjust(type, value, exp) {
    // Si el exp no está definido o es cero...
    if (typeof exp === 'undefined' || +exp === 0) {
        return Math[type](value);
    }
    value = +value;
    exp = +exp;
    // Si el valor no es un número o el exp no es un entero...
    if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0)) {
        return NaN;
    }
    // Shift
    value = value.toString().split('e');
    value = Math[type](+(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp)));
    // Shift back
    value = value.toString().split('e');
    return +(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp));
}

// Decimal round
if (!Math.round10) {
    Math.round10 = function (value, exp) {
        return decimalAdjust('round', value, exp);
    };
}