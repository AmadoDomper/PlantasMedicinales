using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlantasMedicinales.Entidades
{
    public class Menu
    {
        private int _nMenuId;
        private int _nMenuPadre;
        private string _cMenuDesc;
        private string _cMenuIcono;
        private int _nMenuposicion;
        private string _cMenuUrl;
        private string _cMenuEstado;
        private int _cMenuPadreId;

        private Boolean _bEstado;
        private List<Modulo> _ListaModulos = new List<Modulo>();

        //**********************
        private int _tipoPermiso;
        private List<Menu> _listaMenu;
        //**********************
        private bool _seleccionado;

        public int nMenuId
        {
            get { return _nMenuId; }
            set { _nMenuId = value; }
        }

        [JsonIgnore]
        public int nMenuPadre
        {
            get { return _nMenuPadre; }
            set { _nMenuPadre = value; }
        }

        public string cMenuDesc
        {
            get { return _cMenuDesc; }
            set { _cMenuDesc = value; }
        }

        [JsonIgnore]
        public string cMenuIcono
        {
            get { return _cMenuIcono; }
            set { _cMenuIcono = value; }
        }

        [JsonIgnore]
        public int nMenuposicion
        {
            get { return _nMenuposicion; }
            set { _nMenuposicion = value; }
        }

        [JsonIgnore]
        public string cMenuUrl
        {
            get { return _cMenuUrl; }
            set { _cMenuUrl = value; }
        }

        [JsonIgnore]
        public string cMenuEstado
        {
            get { return _cMenuEstado; }
            set { _cMenuEstado = value; }
        }

        [JsonIgnore]
        public int cMenuPadreId
        {
            get { return _cMenuPadreId; }
            set { _cMenuPadreId = value; }
        }

        [JsonIgnore]
        public int tipoPermiso
        {
            get { return _tipoPermiso; }
            set { _tipoPermiso = value; }
        }

        [JsonIgnore]
        public List<Menu> listaMenu
        {
            get { return _listaMenu; }
            set { _listaMenu = value; }
        }

        [JsonIgnore]
        public bool seleccionado
        {
            get { return _seleccionado; }
            set { _seleccionado = value; }
        }

        [JsonProperty(PropertyName = "lstMods")]
        public List<Modulo> ListaModulos
        {
            get { return _ListaModulos; }
            set { _ListaModulos = value; }
        }

        [JsonProperty(PropertyName = "bEst")]
        public Boolean bEstado
        {
            get { return _bEstado; }
            set { _bEstado = value; }
        }
    }
}
