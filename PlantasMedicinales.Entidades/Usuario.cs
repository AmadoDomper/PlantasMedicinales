using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PlantasMedicinales.Entidades
{
    public class Usuario
    {
        private int _nUsuarioId;
        private string _cDni;
        private string _cContrasena;
        private string _cNombres;
        private string _cApellidoPa;
        private string _cApellidoMa;
        private string _cSexo;
        private string _cInstitucion;
        private bool _bEsInterno;
        private string _cTipoUsuario;
        private int _nPaisId;
        private string _cPais;
        private int _nCiudadId;
        private string _cCiudad;
        private string _cEmail;
        private DateTime _dFechaNacimiento;
        private string _cFechaNacimiento;
        private int _nRolId;
        private string _cRolDesc;
        private int _nEstado;

        [JsonProperty(PropertyName = "nUsuId")]
        public int nUsuarioId
        {
            get { return _nUsuarioId; }
            set { _nUsuarioId = value; }
        }

        [JsonProperty(PropertyName = "cDni")]
        public string cDni
        {
            get { return _cDni; }
            set { _cDni = value; }
        }

        [JsonProperty(PropertyName = "cCnt")]
        public string cContrasena
        {
            get { return _cContrasena; }
            set { _cContrasena = value; }
        }

        [JsonProperty(PropertyName = "cNom")]
        public string cNombres
        {
            get { return _cNombres; }
            set { _cNombres = value; }
        }

        [JsonProperty(PropertyName = "cApePa")]
        public string cApellidoPa
        {
            get { return _cApellidoPa; }
            set { _cApellidoPa = value; }
        }

        [JsonProperty(PropertyName = "cApeMa")]
        public string cApellidoMa
        {
            get { return _cApellidoMa; }
            set { _cApellidoMa = value; }
        }

        [JsonProperty(PropertyName = "cSexo")]
        public string cSexo
        {
            get { return _cSexo; }
            set { _cSexo = value; }
        }

        [JsonProperty(PropertyName = "cInst")]
        public string cInstitucion
        {
            get { return _cInstitucion; }
            set { _cInstitucion = value; }
        }

        [JsonProperty(PropertyName = "bEsInterno")]
        public bool bEsInterno
        {
            get { return _bEsInterno; }
            set { _bEsInterno = value; }
        }

        [JsonProperty(PropertyName = "cTipUsu")]
        public string cTipoUsuario
        {
            get { return _cTipoUsuario; }
            set { _cTipoUsuario = value; }
        }

        [JsonProperty(PropertyName = "nPaisId")]
        public int nPaisId
        {
            get { return _nPaisId; }
            set { _nPaisId = value; }
        }

        [JsonProperty(PropertyName = "cPais")]
        public string cPais
        {
            get { return _cPais; }
            set { _cPais = value; }
        }

        [JsonProperty(PropertyName = "nCiudadId")]
        public int nCiudadId
        {
            get { return _nCiudadId; }
            set { _nCiudadId = value; }
        }

        [JsonProperty(PropertyName = "cCiudad")]
        public string cCiudad
        {
            get { return _cCiudad; }
            set { _cCiudad = value; }
        }

        [JsonProperty(PropertyName = "cEmail")]
        public string cEmail
        {
            get { return _cEmail; }
            set { _cEmail = value; }
        }

        [JsonProperty(PropertyName = "dFecNac")]
        public DateTime dFechaNacimiento
        {
            get { return _dFechaNacimiento; }
            set { _dFechaNacimiento = value; }
        }

        [JsonProperty(PropertyName = "nRolId")]
        public int nRolId
        {
            get { return _nRolId; }
            set { _nRolId = value; }
        }

        [JsonProperty(PropertyName = "cRolDes")]
        public string cRolDesc
        {
            get { return _cRolDesc; }
            set { _cRolDesc = value; }
        }

        [JsonProperty(PropertyName = "nEstado")]
        public int nEstado
        {
            get { return _nEstado; }
            set { _nEstado = value; }
        }

        [JsonProperty(PropertyName = "cFechaNac")]
        public string cFechaNacimiento
        {
            get { return _cFechaNacimiento; }
            set { _cFechaNacimiento = value; }
        }

    }
}
