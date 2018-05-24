using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.LogicaNegocio;
using PlantasMedicinales.Seguridad.Filters;
using PlantasMedicinales.Web.Controllers.Base;

namespace PlantasMedicinales.Web.Controllers
{
    public class MenuController : BaseController
    {
        MenuLN oMenuLN = new MenuLN();

        [HttpGet]
        public ActionResult ObtenerMenu()
        {
            int nRolId = ((Usuario)Session["Datos"]).nRolId;
            List<Menu> l_o = oMenuLN.ObtenerMenusFull(nRolId).ToList<Menu>();
            List<Menu> l_p = (from Menu m in l_o where m.nMenuId == m.nMenuPadre select m).ToList<Menu>();

            AgregarItem(ref l_p, l_o);
            return PartialView("_Menu", l_p);
        }
        public void AgregarItem(ref List<Menu> Lista, List<Menu> l_o)
        {
            foreach (Menu menu in Lista)
            {
                List<Menu> sl = (from Menu sm in l_o where menu.nMenuId == sm.nMenuPadre && menu.nMenuId != sm.nMenuId select sm).ToList<Menu>();

                if (sl != null && sl.Count() > 0)
                {
                    menu.listaMenu = sl;

                    AgregarItem(ref sl, l_o);
                }
                else menu.listaMenu = new List<Menu>();
            }
        }
    }
}