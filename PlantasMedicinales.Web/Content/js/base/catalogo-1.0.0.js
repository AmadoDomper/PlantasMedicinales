

(function ($) {
    $.fn.Catalogo = function (m) {

        var w = m.datos;
        m.tblId = m.tblId || "";
        m.textSearchId = m.textSearchId || "";
        m.numerado = m.numerado || "No";
        m.contenedor = m.contenedor || this;
        m.cabecera = m.cabecera || "";
        m.clickEvent = m.clickEvent || function () { };
        m.pag = m.pag || false;
        m.pagDato = m.pagDato || {};
        m.pagEvent = m.pagEvent || function () { };
        m.claseSobre = m.claseSobre || "Si";
        m.scrollVertical = m.scrollVertical || "No";
        m.cantRegVertical = m.cantRegVertical || 4;
        m.campos = m.campos || "";
        m.tipoCampo = m.tipoCampo || "";
        m.tblStyle = m.tblStyle || "table-bordered"
        m.visible = m.visible || "";
        m.subLista = m.subLista || "Si";
        m.cargando = m.cargando || false;
        m.cellLen = m.cellLen || false;
        m.alinear = m.alinear || false;
        m.empty = m.empty || "No existen datos";
        m.edit = m.edit || false;
        m.search = m.search || false;
        m.check = m.check || false;
        m.checkHead = m.checkHead || false;
        m.editEvent = m.editEvent || function () { };
        m.checkEvent = m.checkEvent || function () { };
        m.checkHeadEvent = m.checkHeadEvent || function () { };
        m.searchEvent = m.searchEvent || function () { };
        m.click = m.click || false;
        m.elim = m.elim || false;
        m.elimEvent = m.elimEvent || function () { };
        m.tipoCatalogo = m.tipoCatalogo || "ficha";

        var col = m.cabecera.split(",");
        var tipo = m.tipoCampo.split(","); //D:double, F: Fecha, C: CheckBox
        var camp;
        if (m.campos != "") {
            camp = m.campos.split(",");
        } else { camp = [] }

        var cssTbl = "table-responsive";

        if (m.scrollVertical == "Si") {
            cssTbl += " scrollvertical-" + m.cantRegVertical;
        }

        if (m.pagDato.nRows <= m.pagDato.nPageSize) { m.pag = false; }

        var html = '';

        //Opciones

        html += '<div class="btn-toolbar" role="toolbar">';
        html += '<div id="btnCatalogoTipo" class="btn-group text-center">';
        html += '<button for="cntFichas" type="button" class="btn btn-default btn-success" aria-label="Left Align">Ficha</button>';
        html += '<button for="cntTabla" type="button" class="btn btn-default" aria-label="Center Align">Tabla</button>';
        html += '</div>';
        html += '</div>';


        var i = 0;
        //var j = 0;
        var ficha = '';
        var c = 3;

        html += '<div><div id="cntFichas">';
        for (i in m.datos) {
            if (camp.length > 0) {
                

                ficha += '<div class="col-xs-12 col-sm-6 col-md-4 col-lg-' + (12 / c) + '">';
                ficha += '<div class="ficha thumbnail">';
                ficha += '<div class="ficha-img">';
                ficha += '<img class="img-responsive" id="targetImg" style="max-height:323px;" src="/ArchivosSubidos/' + eval("m.datos[i].cFoto") + '">';
                ficha += '</div>';
                ficha += '<div class="ficha-desc">';
                ficha += '<label class="nombre-comun control-label m-r-5">' + eval("m.datos[i].cNomCom") + '</label>';
                ficha += '<label class="nombre-cient control-label m-r-5">' + eval("m.datos[i].cNomCie") + '</label>';
                ficha += '<label class="familia control-label m-r-5">' + eval("m.datos[i].cFam") + '</label>';
                ficha += '</div>';
                ficha += '</div>';
                ficha += '</div>';
                
                //j++;
                //if (j == c) {
                //    html += '<div class="row">' + ficha + '</div>';
                //    j = 0;
                //    ficha = '';
                //}
            }
        }

        if (ficha != '') {
            html += '<div class="row">' + ficha + '</div>';
        }

        html += '</div>';

        html += '<div class="' + cssTbl + '" style="display:none;" id="cntTabla" ><table data-edit="false" id="' + m.tblId + '" class="table ' + m.tblStyle + ' table-hover">';

        //Cabecera
        html += '<thead><tr>';
        if (m.checkHead) { html += '<th><input style="cursor: pointer;text-align: center;vertical-align: middle;" id="chkAll" type="checkbox"></th>'; }
        if (m.numerado === "Si") { html += '<th>N°</th>'; }
        for (i in col) { html += '<th>' + col[i] + '</th>'; }
        if (m.edit) { html += '<th>Edit.</th>'; }
        if (m.search) { html += '<th>Det.</th>'; }
        if (m.elim) { html += '<th>Elim.</th>'; }
        html += '</tr></thead>';

        //Cuerpo
        html += '<tbody>';
        var i = 0;
        for (i in m.datos) {
            html += '<tr>';
            if (m.numerado == "Si")
                html += '<td>' + i + 1 + '</td>';

            if (camp.length > 0) {
                var dat;
                var k = 0;
                for (k in camp) {
                    dat = eval("m.datos[i]." + camp[k]);

                    if (tipo[k] == "D") {
                        dat = number_format(dat, 2)
                    }
                    if (tipo[k] == "D3") {

                        if ((eval("m.datos[i].oPrMed.nom")) == "Kg") {
                            dat = number_format(dat, 3);
                        } else {
                            dat = number_format(dat, 0);
                        }
                    }
                    if (tipo[k] == "F") {
                        dat = moment(dat).format("DD/MM/YYYY hh:mm:ss");
                    }

                    if (tipo[k] == "C" || tipo[k] == "C1") {
                        dat = '<input type="checkbox"' + (dat ? "checked" : "") + '>'
                    } else {
                        dat = (typeof (dat) === "boolean" ? "<span style='color:#" + (dat ? "43C73C'" : "C73C3C'") + " class='glyphicon glyphicon-" + (dat ? "ok'" : "remove'") + " aria-hidden='true'></span>" : dat);
                    }

                    html += '<td>' + (dat == null ? "" : dat) + '</td>';
                }

                if (m.edit) {
                    html += '<td class="edit" style="cursor: pointer;text-align: center;vertical-align: middle;"><span style="color: #3C86C7;font-size:15px;" class="glyphicon glyphicon-pencil" aria-hidden="true"></span></td>';
                }
                if (m.search) {
                    html += '<td class="search" style="cursor: pointer;text-align: center;vertical-align: middle;"><span style="color: #3C86C7;font-size:15px;" class="glyphicon glyphicon-search" aria-hidden="true"></span></td>';
                }
                if (m.elim) {
                    html += '<td class="elim" style="cursor: pointer;text-align: center;vertical-align: middle;"><span style="color: #C73C3C;font-size:15px;" class="glyphicon glyphicon-trash" aria-hidden="true"></span></td>';
                }

            }
            else {
                if (m.subLista == "No") {
                    html += '<td>' + m.datos[i] + '</td>';
                } else {
                    var j = 0;
                    for (j in m.datos[i]) {
                        html += '<td>' + m.datos[i][j] + '</td>';
                    }
                }
            }

            html += '</tr>';
        }
        //}

        if (typeof (m.datos) != 'undefined' && m.datos.length == 0) {
            html += '<tr><td colspan="' + camp.length + (m.edit ? 1 : 0) + (m.elim ? 1 : 0) + (m.search ? 1 : 0) + '"><h1 class="text-center m-t-10"><small>' + m.empty + '</small></h1></td></tr>';
        }


        html += '</tbody></table></div></div>';

        if (m.pag && m.datos.length > 0) {

            html += '<div class="text-center" id="cntPaginacion">';
            html += '<ul class="pagination m-t-10 m-b-10">';
            html += '<li class="previous" id="example1_previous">';
            html += '<a data-dt-idx="0" tabindex="0">Anterior</a></li>';


            var ini = 1;
            var fin = m.pagDato.nPageTot;
            //var nPag = 10
            if (m.pagDato.nPageTot > 10) {

                fin = ini + 9;

                if (m.pagDato.nPage > 6 && m.pagDato.nPage <= (m.pagDato.nPageTot - 4)) {
                    ini = m.pagDato.nPage - 5;
                    fin = ini + 9;
                } else if (m.pagDato.nPage > (m.pagDato.nPageTot - 4)) {
                    ini = m.pagDato.nPageTot - 9;
                    fin = m.pagDato.nPageTot;
                }

            }

            for (var i = ini; i <= fin ; i++) {
                html += '<li><a data-dt-idx="' + i + '" tabindex="0">' + i + '</a></li>';
            }

            html += '<li class="next" id="example1_next">';
            html += '<a data-dt-idx="' + (m.pagDato.nPageTot + 1) + '" tabindex="0">Siguiente</a>';
            html += '</li></ul></div>';
        }

        $(m.contenedor).html(html);

        $("#" + m.tblId + " tbody tr").bind("click", function () {
            if ($("#" + m.tblId).attr("data-edit") == "false") {
                $("#" + m.tblId + " tbody tr").removeClass("seleccionado");
                $(this).addClass("seleccionado");
            }
        })

        if (m.cellLen) {
            m.cellLen = m.cellLen.split(",");
            var i = 0;
            for (elem in m.cellLen) {

                if (m.cellLen[elem] == "0") {
                    $('#' + m.tblId + ' th:nth-child(' + (i + 1) + ')').hide();
                    $('#' + m.tblId + ' td:nth-child(' + (i + 1) + ')').hide();
                } else {
                    $("#" + m.tblId).find('th:eq(' + i + ')').css("width", m.cellLen[i] + "px");
                }
                i++;
            }
        }

        if (m.alinear) {
            var $a;
            var i = 0;
            $a = m.alinear.split(",");
            for (i in $a) { $("#" + m.tblId + " tbody tr").find('td:eq(' + i + ')').css("text-align", $a[i] == 'L' ? 'Left' : $a[i] == 'C' ? 'Center' : $a[i] == 'R' ? 'Right' : '').css("vertical-align", "middle"); }
        }


        if (m.edit) {
            $("#" + m.tblId + " tbody tr .edit").bind("click", function () {
                m["editEvent"]($(this).parent());
            });
        }

        if (m.elim) {
            $("#" + m.tblId + " tbody tr .elim").bind("click", function () {
                var nPage = 1;
                var fila = $(this).parent();

                if (m.pag) {
                    nPage = $("#cntPaginacion .active a").attr("data-dt-idx");
                    if ($("#tblClientes tbody tr").length == 1 && nPage > 1) {
                        nPage = nPage - 1;
                    }
                }

                $.fn.Mensaje({
                    mensaje: "&iquest;Est&aacutes seguro que deseas eliminar el registro?",
                    tamano: "md",
                    tipo: "SiNo",
                    funcionAceptar: function () {
                        m["elimEvent"](fila, nPage);
                    }
                });
            });
        }

        if (m.dblClick) {
            $("#" + m.tblId + " tbody tr").bind("dblclick", function () {
                m["editEvent"]($(this));
            });
        }

        if (m.click) {
            $("#" + m.tblId + " tbody tr").bind("click", function () {
                m["clickEvent"]($(this));
            });
        }

        if (m.check) {
            $("#" + m.tblId + " tbody tr input").bind("click", function (e) {
                var fila = $(this).parent().parent();
                CheckAll();
                m["checkEvent"](fila, this);

                if (fila.attr("class") != "seleccionado") {
                    e.stopPropagation();
                }
            });
        }

        if (m.checkHead) {
            $('#chkAll').click(function (e) {
                $(this).closest('table').find('tr:visible td input:checkbox:not(:disabled)').prop('checked', this.checked);

                m["checkHeadEvent"]();
            });
        }

        if (m.pag) {
            $('#cntPaginacion [data-dt-idx=' + m.pagDato.nPage + ']').parent().addClass("active");
            $('#cntPaginacion [data-dt-idx=' + m.pagDato.nPage + ']').focus();

            if (m.pagDato.nPage == 1) {
                $("#cntPaginacion .previous").addClass("disabled")
            } else if (m.pagDato.nPage == m.pagDato.nPageTot) {
                $("#cntPaginacion .next").addClass("disabled")
            } else {
                $("#cntPaginacion .previous,#cntPaginacion .next").removeClass("disabled");
            }

            $('#cntPaginacion a').click(function () {
                var nPag = $(this).attr("data-dt-idx");
                var nAct = $("#cntPaginacion .active a").attr("data-dt-idx")

                if (nPag == 0) {
                    nPag = nAct - 1;
                } else if (nPag == (m.pagDato.nPageTot + 1)) {
                    nPag = (nAct * 1) + 1;
                }

                if (nPag != nAct && (nPag != 0 && nPag != m.pagDato.nPageTot + 1)) {
                    m["pagEvent"](nPag, m.pagDato.nPageSize);
                }
            });
        }

        $("#btnCatalogoTipo button").click(function () {
            var $target = $('#' + $(this).attr('for')),
                $other = $target.siblings();

            $("#btnCatalogoTipo button").removeClass("btn-success");
            $(this).addClass("btn-success");
            $target.show();
            $other.hide();
        });



        if (m.textSearchId != "") {
            $('#' + m.textSearchId).keyup(function () {
                searchTable($(this).val());
                CheckAll();
            });

            function searchTable(inputVal) {
                var table = $("#" + m.tblId);
                table.find('tr').each(function (index, row) {
                    var allCells = $(row).find('td');
                    if (allCells.length > 0) {
                        var found = false;
                        allCells.each(function (index, td) {
                            var regExp = new RegExp(inputVal, 'i');
                            if (regExp.test($(td).text())) {
                                found = true;
                                return false;
                            }
                        });
                        if (found == true) $(row).show(); else $(row).hide();
                    }
                });
            }
        }

        function CheckAll() {
            var c = $("#" + m.tblId).find('tr:visible td input:checkbox:not(:checked)').size();
            var t = $("#" + m.tblId).find('tr:visible td input:checkbox').size();
            $("#chkAll").prop('checked', c == 0 && t != 0 ? true : false);
        }

    }
})(jQuery);

(function ($) {
    $.uiTableFilter = function (jq, phrase, column, ifHidden) {
        var new_hidden = false;
        if (this.last_phrase === phrase) return false;

        var phrase_length = phrase.length;
        var words = phrase.toLowerCase().split(" ");

        // these function pointers may change
        var matches = function (elem) { elem.show() }
        var noMatch = function (elem) { elem.hide(); new_hidden = true }
        var getText = function (elem) { return elem.text() }

        if (column) {
            var index = null;
            $(jq).find("thead > tr:last > th").each(function (i) {
                if ($.trim($(this).text()) == column) {
                    index = i; return false;
                }
            });
            if (index == null) throw ("given column: " + column + " not found")

            getText = function (elem) {
                return $(elem.find(
                  ("td:eq(" + index + ")"))).text()
            }
        }

        // if added one letter to last time,
        // just check newest word and only need to hide
        if ((words.size > 1) && (phrase.substr(0, phrase_length - 1) ===
              this.last_phrase)) {

            if (phrase[-1] === " ")
            { this.last_phrase = phrase; return false; }

            var words = words[-1]; // just search for the newest word

            // only hide visible rows
            matches = function (elem) {; }
            var elems = $(jq).find("tbody:first > tr:visible")
        }
        else {
            new_hidden = true;
            var elems = $(jq).find("tbody:first > tr")
        }

        elems.each(function () {
            var elem = $(this);
            $.uiTableFilter.has_words(getText(elem), words, false) ?
              matches(elem) : noMatch(elem);
        });

        last_phrase = phrase;
        if (ifHidden && new_hidden) ifHidden();
        return jq;
    };

    $.uiTableFilter.last_phrase = ""

    $.uiTableFilter.has_words = function (str, words, caseSensitive) {
        var text = caseSensitive ? str : str.toLowerCase();
        for (var i = 0; i < words.length; i++) {
            if (text.indexOf(words[i]) === -1) return false;
        }
        return true;
    }
})(jQuery);
