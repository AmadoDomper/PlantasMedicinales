using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantasMedicinales.Web.Models;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.LogicaNegocio;
using PlantasMedicinales.Seguridad.Filters;
using PlantasMedicinales.Web.Controllers.Base;
using Newtonsoft.Json;

namespace PlantasMedicinales.Web.Controllers
{
    public class UsuarioController : BaseController
    {

        //public ActionResult Index()
        //{
        //    return View();
        //}


        public ActionResult GestionarUsuarios()
        {
            return View();
        }

        public string ListaUsuariosPag(int nPage = 1, int nSize = 10, string cValor = null)
        {
            UsuarioLN oUsuarios = new UsuarioLN();
            ListaPaginada ListaUsuariosPag = oUsuarios.ListarUsuariosPag(nPage, nSize, cValor);

            return JsonConvert.SerializeObject(ListaUsuariosPag, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }


        public string CargarDatosUsuario(int nUsuId)
        {
            UsuarioLN oUsuarioLN = new UsuarioLN();
            Usuario oUsuario = new Usuario();

            oUsuario = oUsuarioLN.CargarDatosUsuario(nUsuId);

            return JsonConvert.SerializeObject(oUsuario, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        }

        public string RegistrarModificarUsuario(Usuario oUsu)
        {
            UsuarioLN oUsuarioLN = new UsuarioLN();

            var resultado = oUsuarioLN.RegistrarModificarUsuario(oUsu);

            return JsonConvert.SerializeObject(resultado, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }

        [RequiresAuthenticationAttribute]
        public string EliminarUsuario(int nUsuarioId)
        {
            UsuarioLN oUsuario = new UsuarioLN();
            int resultado;
            resultado = oUsuario.EliminarUsuario(nUsuarioId);

            return JsonConvert.SerializeObject(resultado, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }

    }
}