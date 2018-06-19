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
    public class CatalogoController : Controller
    {
        // GET: Catalogo
        public ActionResult Index()
        {
            return View();
        }

        public string ListaCatalogo(int nPage = 1, int nSize = 12, string cValor = null)
        {
            PlinianLN oPlantas = new PlinianLN();
            ListaPaginada ListaUsuariosPag = oPlantas.ListarPlantasPag(nPage, nSize, cValor);

            return JsonConvert.SerializeObject(ListaUsuariosPag, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }

        public string CargarDatos(int nInv)
        {
            PlinianLN oPlinianLN = new PlinianLN();
            Plinian oPlinian = new Plinian();

            oPlinian = oPlinianLN.CargarDatosPlinian(nInv);

            return JsonConvert.SerializeObject(oPlinian, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        }
    }
}