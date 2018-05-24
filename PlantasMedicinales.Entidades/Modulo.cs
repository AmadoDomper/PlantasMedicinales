using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlantasMedicinales.Entidades
{
    public class Modulo
    {
        private int _nModId;
        private int _nMenuId;
        private string _cModDesc;
        private Boolean _bEstado;


        private List<Permiso> _ListaPermisos = new List<Permiso>();

        [JsonProperty(PropertyName = "nModId")]
        public int nModId
        {
            get { return _nModId; }
            set { _nModId = value; }
        }

        [JsonProperty(PropertyName = "nMenuId")]
        public int nMenuId
        {
            get { return _nMenuId; }
            set { _nMenuId = value; }
        }

        [JsonProperty(PropertyName = "cModDesc")]
        public string cModDesc
        {
            get { return _cModDesc; }
            set { _cModDesc = value; }
        }

        [JsonProperty(PropertyName = "lstPerms")]
        public List<Permiso> ListaPermisos
        {
            get { return _ListaPermisos; }
            set { _ListaPermisos = value; }
        }

        [JsonProperty(PropertyName = "bEst")]
        public Boolean bEstado
        {
            get { return _bEstado; }
            set { _bEstado = value; }
        }
    }
}
