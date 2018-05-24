using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlantasMedicinales.Entidades
{
    public class Permiso
    {
        private int _nPermId;
        private int _nModId;
        private string _cPermDesc;
        private Boolean _bEstado;

        [JsonProperty(PropertyName = "nPermId")]
        public int nPermId
        {
            get { return _nPermId; }
            set { _nPermId = value; }
        }

        [JsonProperty(PropertyName = "nModId")]
        public int nModId
        {
            get { return _nModId; }
            set { _nModId = value; }
        }

        [JsonProperty(PropertyName = "cPermDesc")]
        public string cPermDesc
        {
            get { return _cPermDesc; }
            set { _cPermDesc = value; }
        }

        [JsonProperty(PropertyName = "bEst")]
        public Boolean bEstado
        {
            get { return _bEstado; }
            set { _bEstado = value; }
        }
    }
}