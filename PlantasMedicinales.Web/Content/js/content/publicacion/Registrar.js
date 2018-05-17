var lsFeatures = Array();
//var lsVectorLayers = Array();
var indexFeature = 0;

function quitarElemento(id) {

    //map.getLayers().forEach(function (layer) {
    //    if (layer instanceof ol.layer.Vector) {
    //        if (layer.getSource().getFeatures()[0].getId() == id) {
    //            map.removeLayer(layer);
    //        }
    //    }
    //});

    var layer = map.getLayers().getArray()[1].getSource();
    layer.removeFeature(layer.getFeatureById(id));

    for (var i = 0; i < lsFeatures.length; i++) {
        if (lsFeatures[i].n == id) {
            lsFeatures.splice(i, 1);
            //map.removeLayer(lsVectorLayers[i])
            //lsVectorLayers.splice(i, 1);
            //indexFeature--;
            break;
        }
    }
}



/*Control del mapa*/

var vistaMap = new ol.View({
    center: ol.proj.transform([-75, -9], 'EPSG:4326', 'EPSG:3857'),
    zoom: 5
});

var map = new ol.Map({
    target: 'map',
    view: vistaMap,

    controls: ol.control.defaults().extend([
        new ol.control.ScaleLine(),
        new ol.control.ZoomSlider(),
        new ol.control.FullScreen()
    ])

});

map.on('pointermove', function (evt) {
    map.getTargetElement().style.cursor =
        map.hasFeatureAtPixel(evt.pixel) ? 'pointer' : '';
});

var wmsLayer2 = new ol.layer.Tile({
    source: new ol.source.OSM({
        projection: 'EPSG:3857',
        url: 'http://mt{0-3}.google.com/vt/lyrs=m&x={x}&y={y}&z={z}',
        attributions: [
        ]
    })
});
map.addLayer(wmsLayer2);

/*Features*/

var styleFunction = (function () {
    /* jshint -W069 */
    var styles = {};
    var image = new ol.style.Circle({
        radius: 3,
        fill: new ol.style.Fill({ color: '#ff4444' }),
        //stroke: new ol.style.Stroke({color: '#FF0000', width: 1})
    });
    styles['Point'] = [new ol.style.Style({ image: image })];
    styles['default'] = [new ol.style.Style({
        stroke: new ol.style.Stroke({
            color: 'green',
            width: 10
        }),
        fill: new ol.style.Fill({
            color: 'rgba(255, 5, 0, 0.1)'
        }),
        image: image
    })];
    return function (feature, resolution) {
        return styles[feature.getGeometry().getType()] || styles['default'];
    };
    /* jshint +W069 */
})();


var vectorLayer = new ol.layer.Vector({
    source: new ol.source.Vector({
    }),
    style: styleFunction
})

map.addLayer(vectorLayer);

function map_AgregarPunto(punto,index) {
    var point_feature = new ol.Feature({});
    var point_geom = new ol.geom.Point(ol.proj.transform([+punto[0], +punto[1]], 'EPSG:4326', 'EPSG:3857'));
    point_feature.setGeometry(point_geom);

    map.getLayers().getArray()[1].getSource().addFeature(point_feature);

    point_feature.setId(index);
    console.log(index);
}

var features = Array();

function ColorId(id, c) {
    map.getLayers().forEach(function (layer) {
        if (layer instanceof ol.layer.Vector) {
            console.log(layer);
            layer.getSource().forEachFeature(function (feature) {
                console.log(feature.getId());
                if (feature.getId() == id) {
                    console.log(feature);
                    features.push(feature);
                    console.log(features);
                    feature.setStyle(new ol.style.Style({
                        image: new ol.style.Circle({
                            radius: 5,
                            fill: new ol.style.Fill({
                                color: 'yellow'
                            })
                        }),
                        zIndex: 100000
                    }));
                    return true;
                }
            });
        }
    });
}

function LimpiarColor() {
    if (features.length > 0) {
        features[0].setStyle(new ol.style.Style({
            image: new ol.style.Circle({
                radius: 3,
                fill: new ol.style.Fill({
                    color: '#ff4444'
                })
            })
        }));

        features = Array();
    }
}


function CargarGrilla() {

    $("#jsGrid").jsGrid({
        width: "100%",
        height: "400px",
        sorting: true,
        paging: false,
        deleteConfirm: "¿Estás seguro de eliminar?",
        noDataContent: "Sin datos",
        //data: datos,

        fields: [
            { name: "Longitud", type: "text", align: "center", width: 100 },
            { name: "Latitud", type: "text", align: "center", width: 100 },
            { type: "control", editButton: false }
        ],
        onItemDeleted: function (args) {
            quitarElemento(args.item.n);
            console.log(lsFeatures);
        },
        rowClick: function myfunction(args) {
            //alert(args.item.n);
            LimpiarColor();
            ColorId(args.item.n);
        }
    });
}


/*Fin control del mapa*/

$(document).ready(function () {
    $('#ddlTipo').dropdowlist({
        dataShow: 'cDesc',
        dataValue: 'nTipoId',
        dataselect: 'nTipoId',
        datalist: Model.lsTipos
    });

    var myDate = new Date();
    var year = myDate.getFullYear(); var values = '<option value="">Elige una opción</option>';
    for (var i = 1900; i < year + 1; i++) {
        values += '<option value="' + i + '">' + i + '</option>';
    }
    $("#txtAnoPublicacion").html(values);

    $('#ddlTema').dropdowlist({
        dataShow: 'cDesc',
        dataValue: 'nTemaId',
        dataselect: 'nTemaId',
        datalist: Model.lsTemas
    });

    /*Grilla*/


    CargarGrilla();
    /*Fin de la grilla*/

    /*multiselet tema*/

    //function formatDatosTemas(lsTemas) {
    //    var datos = new Array();
    //    for (var i = 0; i < lsTemas.length; i++) {
    //        var fila = { label: lsTemas[i].tem_descripcion, title: lsTemas[i].tem_descripcion, value: lsTemas[i].tem_idtema };
    //        datos.push(fila);
    //    }
    //    return datos;
    //}

    //$('#ddlTema').multiselect({
    //    nonSelectedText: 'Elige un tema',
    //    buttonWidth: '250'
    //});
    //$('#ddlTema').multiselect('dataprovider', formatDatosTemas(Model.lsTemas));

    /*fin multiselect tema*/



    $('#btAddPunto').click(function () {
        $().addPunto({
            alAceptar: function (lat, lng) {
                indexFeature++;
                var info = lng + '|' + lat;
                var item = { "n": indexFeature, "Tipo": 1, "Info": info, "Longitud": lng, "Latitud": lat };
                $("#jsGrid").jsGrid("insertItem", item);

                lsFeatures.push(item);
                map_AgregarPunto([lng, lat], indexFeature);
            }
        });
    });

    /* $('#btAddLinea').click(function () {
         $().addLinea({
             alAceptar: function (lat1, lng1, lat2, lng2) {
 
             }
         });
     });*/

    $('#btenviar').click(function () {

        if ($('#frm').smkValidate()) {
            $.fn.Conexion({
                direccion: '../Publicacion/RegistrarPublicacion',
                bloqueo: true,
                datos: {
                    "pub_anopublicacion": $('#txtAnoPublicacion').val(),
                    "pub_referenciabibliografica": $('#txtReferencia').val(),
                    "pub_enlace": $('#txtEnlace').val(),
                    "tip_idtipo": $('#ddlTipo').val(),
                    "ls_tem_idtema": $('#ddlTema').val() /* $('#ddlTema').val().join(',')*/,
                    "features": JSON.stringify(lsFeatures),
                    "pub_titulo": $('#txtTitulo').val()
                },
                terminado: function (data) {
                    data = JSON.parse(data);
                    $.fn.Mensaje({ titulo: "Mensaje", mensaje: "La operación se realizó correctamente." });
                    Limpiar();
                    ListarMisPub(null,null,false);
                    vista("#target1");
                }
            });
        }


    });

});