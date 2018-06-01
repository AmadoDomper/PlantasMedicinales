using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlantasMedicinales.Entidades
{
    public class Plinian
    {
        private int _nId;
        private string _cCodigo;
        private string _cNombresComunes;
        private string _cSinonimia;
        private string _cNombreCientifico;
        private string _cFamilia;
        private string _cDescripCientifica;
        private string _cHabitat;
        private string _cDistribucion;
        private string _cCompoQuimica;
        private string _cToxicidad;
        private string _cEtnomedicinal;
        private string _cManejo;
        private string _cInteracciones;
        private string _cUsos;
        private string _cVaucher;
        private string _cRefeBiblio;
        private string _cFoto;
        private Byte _nEstado;

        [JsonProperty(PropertyName = "nId")]
        public int nId
        {
            get
            {
                return _nId;
            }

            set
            {
                _nId = value;
            }
        }

        [JsonProperty(PropertyName = "cCod")]
        public string cCodigo
        {
            get
            {
                return _cCodigo;
            }

            set
            {
                _cCodigo = value;
            }
        }

        [JsonProperty(PropertyName = "cNomCom")]
        public string cNombresComunes
        {
            get
            {
                return _cNombresComunes;
            }

            set
            {
                _cNombresComunes = value;
            }
        }

        [JsonProperty(PropertyName = "cSino")]
        public string cSinonimia
        {
            get
            {
                return _cSinonimia;
            }

            set
            {
                _cSinonimia = value;
            }
        }

        [JsonProperty(PropertyName = "cNomCie")]
        public string cNombreCientifico
        {
            get
            {
                return _cNombreCientifico;
            }

            set
            {
                _cNombreCientifico = value;
            }
        }

        [JsonProperty(PropertyName = "cFam")]
        public string cFamilia
        {
            get
            {
                return _cFamilia;
            }

            set
            {
                _cFamilia = value;
            }
        }

        [JsonProperty(PropertyName = "cDesc")]
        public string cDescripCientifica
        {
            get
            {
                return _cDescripCientifica;
            }

            set
            {
                _cDescripCientifica = value;
            }
        }

        [JsonProperty(PropertyName = "cHab")]
        public string cHabitat
        {
            get
            {
                return _cHabitat;
            }

            set
            {
                _cHabitat = value;
            }
        }

        [JsonProperty(PropertyName = "cDist")]
        public string cDistribucion
        {
            get
            {
                return _cDistribucion;
            }

            set
            {
                _cDistribucion = value;
            }
        }

        [JsonProperty(PropertyName = "cComQui")]
        public string cCompoQuimica
        {
            get
            {
                return _cCompoQuimica;
            }

            set
            {
                _cCompoQuimica = value;
            }
        }

        [JsonProperty(PropertyName = "cToxi")]
        public string cToxicidad
        {
            get
            {
                return _cToxicidad;
            }

            set
            {
                _cToxicidad = value;
            }
        }

        [JsonProperty(PropertyName = "cEtno")]
        public string cEtnomedicinal
        {
            get
            {
                return _cEtnomedicinal;
            }

            set
            {
                _cEtnomedicinal = value;
            }
        }

        [JsonProperty(PropertyName = "cManejo")]
        public string cManejo
        {
            get
            {
                return _cManejo;
            }

            set
            {
                _cManejo = value;
            }
        }

        [JsonProperty(PropertyName = "cInterac")]
        public string cInteracciones
        {
            get
            {
                return _cInteracciones;
            }

            set
            {
                _cInteracciones = value;
            }
        }

        [JsonProperty(PropertyName = "cUsos")]
        public string cUsos
        {
            get
            {
                return _cUsos;
            }

            set
            {
                _cUsos = value;
            }
        }

        [JsonProperty(PropertyName = "cVaucher")]
        public string cVaucher
        {
            get
            {
                return _cVaucher;
            }

            set
            {
                _cVaucher = value;
            }
        }

        [JsonProperty(PropertyName = "cRefBi")]
        public string cRefeBiblio
        {
            get
            {
                return _cRefeBiblio;
            }

            set
            {
                _cRefeBiblio = value;
            }
        }

        [JsonProperty(PropertyName = "cFoto")]
        public string cFoto
        {
            get
            {
                return _cFoto;
            }

            set
            {
                _cFoto = value;
            }
        }

        [JsonProperty(PropertyName = "nEstado")]
        public Byte nEstado
        {
            get
            {
                return _nEstado;
            }

            set
            {
                _nEstado = value;
            }
        }
    }
}
