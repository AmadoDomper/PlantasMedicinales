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
using System.IO;

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

        [RequiresAuthenticationAttribute]
        public string ListaPlantasPag(int nPage = 1, int nSize = 10, string cValor = null)
        {
            PlinianLN oPlantas = new PlinianLN();
            ListaPaginada ListaPlantasPag = oPlantas.ListarPlantasPag(nPage, nSize, cValor);

            return JsonConvert.SerializeObject(ListaPlantasPag, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }

        [RequiresAuthenticationAttribute]
        public string RegistrarModificarInventario(Plinian oInv)
        {
            PlinianLN oPlinianLN = new PlinianLN();

            var resultado = oPlinianLN.RegistrarModificarPlinian(oInv);

            return JsonConvert.SerializeObject(resultado, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }

        [RequiresAuthenticationAttribute]
        public string CargarDatosIventario(int nInv)
        {
            PlinianLN oPlinianLN = new PlinianLN();
            Plinian oPlinian = new Plinian();

            oPlinian = oPlinianLN.CargarDatosPlinian(nInv);

            return JsonConvert.SerializeObject(oPlinian, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

        }

        [RequiresAuthenticationAttribute]
        public string EliminarIventario(int nInv)
        {
            PlinianLN oPlinianLN = new PlinianLN();
            int resultado;
            resultado = oPlinianLN.EliminarPlinian(nInv);

            return JsonConvert.SerializeObject(resultado, Formatting.None,
            new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });
        }

        public ActionResult CargarImagen(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (var file in files)
            {
                string filePath = Guid.NewGuid() + Path.GetExtension(file.FileName);
                file.SaveAs(Path.Combine(Server.MapPath("~/ArchivosSubidos"), filePath));

                //Aquí poner código para grabar la ruta en la base de datos
            }

            return Json("Archivo cargado correctamente");
        }



        public JsonResult ImageUpload(InventarioViewModel model)
        {

            var file = model.ImageFile;

            if (file != null)
            {

                var fileName = Path.GetFileName(file.FileName);
                var extention = Path.GetExtension(file.FileName);
                var filenamewithoutextension = Path.GetFileNameWithoutExtension(file.FileName);

                file.SaveAs(Server.MapPath("/ArchivosSubidos/" + file.FileName));
            }
            return Json(file.FileName, JsonRequestBehavior.AllowGet);
        }



    }
}