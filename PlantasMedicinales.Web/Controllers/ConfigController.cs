using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.LogicaNegocio;
using PlantasMedicinales.Seguridad.Filters;
using PlantasMedicinales.Web.Controllers.Base;
using PlantasMedicinales.Web.Helper;
using Newtonsoft.Json;

namespace PlantasMedicinales.Web.Controllers
{
    public class ConfigController : BaseController
    {
        public ActionResult Config()
        {
            return View();
        }

        public JsonResult ListaRoles()
        {
            RolLN oRolLN = new RolLN();
            List<Rol> ListaRoles = new List<Rol>();
            ListaRoles = oRolLN.ListarRoles();
            return Json(JsonConvert.SerializeObject(ListaRoles, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }

        public JsonResult CargaRolPermisos(int nRolId)
        {
            ConfiguracionLN oConfigLN = new ConfiguracionLN();
            Rol lstRol = new Rol();

            lstRol = oConfigLN.CargaRolPermisos(nRolId);
            return Json(JsonConvert.SerializeObject(lstRol));
        }

        public JsonResult RegistrarRolPermisos(string oJsonRol)
        {
            int nReg = 0;
            ConfiguracionLN ConfLN = new ConfiguracionLN();

            Rol lstRol = JsonConvert.DeserializeObject<Rol>(oJsonRol);

            if (lstRol.nRolId != Constantes.Rol_Administrador)
            {
                nReg = ConfLN.RegistrarActualizarRolPermisos(lstRol);
            }
            else
            {
                nReg = -1;
            }

            return Json(nReg);
        }

        public JsonResult EliminarRol(int nRolId)
        {
            int nReg = 0;
            ConfiguracionLN ConfLN = new ConfiguracionLN();
            nReg = ConfLN.EliminarRol(nRolId);

            return Json(nReg);
        }
    }
}