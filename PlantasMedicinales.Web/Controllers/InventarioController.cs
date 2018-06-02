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
    [RequiresAuthenticationAttribute]
    public class InventarioController : BaseController
    {
        // GET: Inventario
        public ActionResult Inventarios()
        {
            return View();
        }

        public string ListaPlantasPag(int nPage = 1, int nSize = 10, string cValor = null)
        {
            PlinianLN oPlantas = new PlinianLN();
            ListaPaginada ListaUsuariosPag = oPlantas.ListarPlantasPag(nPage, nSize, cValor);

            return JsonConvert.SerializeObject(ListaUsuariosPag, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }

        public string RegistrarModificarInventario(Plinian oInv)
        {
            PlinianLN oPlinianLN = new PlinianLN();

            var resultado = oPlinianLN.RegistrarModificarPlinian(oInv);

            return JsonConvert.SerializeObject(resultado, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }
    }
}