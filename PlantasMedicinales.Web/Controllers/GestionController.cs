using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Web.Security;
using System.Net;
using PlantasMedicinales.Seguridad.Filters;
using PlantasMedicinales.Web.Controllers.Base;


namespace PlantasMedicinales.Web.Controllers
{
    [RequiresAuthenticationAttribute]
    public class GestionController : BaseController
    {
        // GET: Gestion
      [RequiresAuthenticationAttribute]
        public ActionResult Index()
        {
            return View();
        }
    }
}