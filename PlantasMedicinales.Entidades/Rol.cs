using System.Collections.Generic;
using Newtonsoft.Json;

namespace PlantasMedicinales.Entidades
{
    public class Rol
    {
        private int _nRolId;
        private string _cRolDesc;

        private List<Menu> _ListaMenus = new List<Menu>();

        [JsonProperty(PropertyName = "nRolId")]
        public int nRolId
        {
            get { return _nRolId; }
            set { _nRolId = value; }
        }

        [JsonProperty(PropertyName = "cRolDesc")]
        public string cRolDesc
        {
            get { return _cRolDesc; }
            set { _cRolDesc = value; }
        }

        [JsonProperty(PropertyName = "ListaMenus")]
        public List<Menu> ListaMenus
        {
            get { return _ListaMenus; }
            set { _ListaMenus = value; }
        }
    }
}