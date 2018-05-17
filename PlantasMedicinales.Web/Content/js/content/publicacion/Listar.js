

var db = {

    loadData: function (filter) {
        return $.grep(Model.lsPublicaciones, function (client) {
            return (!filter.pub_titulo || client.pub_titulo.indexOf(filter.pub_titulo) > -1)
                && (!filter.pub_idpublicacion || client.pub_idpublicacion == filter.pub_idpublicacion);
        });
    }
};


$(document).ready(function () {
    /*Grilla*/
    $("#jsGrid").jsGrid({
        width: "100%",
        height: "400px",
        sorting: true,
        paging: true,
        controller: db,
        filtering: true,
        //deleteConfirm: "¿Estás seguro de eliminar?",
        noDataContent: "Sin datos",
        data: Model.lsPublicaciones,
        fields: [
            { name: "nPubliId", title: "ID", type: "text" },
            { name: "cTitulo", title: "Titulo", type: "text", width: 200 },
            { type: "control", deleteButton: false }
        ],
        onItemDeleted: function (args) {

        },
        editItem: function (item) {
            $('#idpub').val(item.nPubliId);
            $('#frm').submit();
        }
    });
    /*Fin de la grilla*/
});

