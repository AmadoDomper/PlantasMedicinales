﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using PlantasMedicinales.Web.Models;
using PlantasMedicinales.Entidades;


namespace PlantasMedicinales.Web.Controllers.Base
{
    public class LogInController : BaseController
    {
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Logear()
        {
            string UserName = Request["txtusuario"];
            string Password = Request["txtpassword"];

            //validamos usuario
            bool validar = Membership.Provider.ValidateUser(UserName, Password);

            if (validar)
            {
                //registramos usuario
                FormsService.SignIn(UserName, true);
                Usuario oUsuario = new Usuario();
                oUsuario = (Usuario)Session["Datos"];

                return RedirectToAction("Index", "Gestion");
            }
            // Si llegamos a este punto, es que se ha producido un error y volvemos a mostrar el formulario
            return RedirectToAction("Login", "Login");
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult MantenerSession()
        {
            if (System.Web.HttpContext.Current.Session["Datos"] != null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        public ActionResult CerrarSession()
        {
            FormsService.SignOut();
            Roles.DeleteCookie();
            Session.RemoveAll();
            return RedirectToAction("LogIn", "LogIn");
        }

    }
}