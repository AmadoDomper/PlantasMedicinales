using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlantasMedicinales.Entidades
{
    public class ListaPaginada
    {
        private int _nPage;
        private int _nPageSize;
        private int _nRows;
        private int _nPageTotal;
        private List<Object> _oLista = new List<Object>();

        [JsonProperty(PropertyName = "nPage")]
        public int nPage
        {
            get { return _nPage; }
            set { _nPage = value; }
        }

        [JsonProperty(PropertyName = "nPageSize")]
        public int nPageSize
        {
            get { return _nPageSize; }
            set { _nPageSize = value; }
        }

        [JsonProperty(PropertyName = "nRows")]
        public int nRows
        {
            get { return _nRows; }
            set { _nRows = value; }
        }

        [JsonProperty(PropertyName = "nPageTot")]
        public int nPageTotal
        {
            get { return _nPageTotal; }
            set { _nPageTotal = value; }
        }

        [JsonProperty(PropertyName = "oLista")]
        public List<Object> oLista
        {
            get { return _oLista; }
            set { _oLista = value; }
        }

    }
}
