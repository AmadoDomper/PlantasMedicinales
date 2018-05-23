using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlantasMedicinales.AccesoDatos.Helper
{
    public static class Procedimiento
    {

        #region Usuario
        public const string sp_sel_ValidaAcceso = "sp_sel_ValidaAcceso";

        public const string stp_sel_ObtenerUsuarioContrasena = "stp_sel_ObtenerUsuarioContrasena";
        public const string stp_del_Usuario = "stp_del_Usuario";
        #endregion

        #region Cliente
        public const string stp_ins_Clientes = "sp_RegClientes";
        public const string stp_sel_ListarClientes = "sp_listClientes";
        public const string stp_sel_FiltrarClientes = "sp_filtraClientes";
        public const string sp_upd_Clientes = "sp_updClientes";
        public const string stp_sel_ClientesxDni = "sp_selClientesxDNI";
        public const string stp_del_EliminarCliente = "sp_Delete_Cliente";
        #endregion

        #region Constante
        public const string stp_sel_constante = "stp_sel_constante";
        #endregion

        #region Menu
        public const string stp_sel_SeleccionarMenuFull = "stp_sel_SeleccionarMenuFull";
        public const string stp_sel_RS_SeleccionarOperacionMenu_Web = "stp_sel_RS_SeleccionarOperacionMenu_Web";
        public const string stp_sel_RS_ListarOperaciones_Web = "stp_sel_RS_ListarOperaciones_Web";
        #endregion

        #region Persona
        public const string stp_sel_RS_getAllUsers = "stp_sel_RS_getAllUsers";
        //public const string stp_sel_ListarClientes = "stp_sel_ListarClientes";
        public const string stp_sel_BuscarClientes = "stp_sel_BuscarClientes";
        public const string stp_sel_BuscarProveedores = "stp_sel_BuscarProveedores";
        public const string stp_del_Cliente = "stp_del_Cliente";
        #endregion

        #region Usuarios
        public const string stp_sel_ListarUsuarios = "stp_sel_ListarUsuarios";
        public const string stp_sel_Usuario = "stp_sel_Usuario";
        public const string stp_ins_upd_Usuario = "stp_ins_upd_Usuario";
        public const string stp_sel_Usuarios = "stp_sel_Usuarios";
        #endregion


        #region Roles
        public const string stp_sel_Roles = "stp_sel_Roles";
        public const string stp_sel_PermisoUsuarioRol = "stp_sel_PermisoUsuarioRol";
        #endregion

        #region Configuracion
        public const string stp_sel_MenuRol = "stp_sel_MenuRol";
        public const string stp_sel_ModuloRol = "stp_sel_ModuloRol";
        public const string stp_sel_PermisoRol = "stp_sel_PermisoRol";
        public const string stp_ins_upd_RolPermisos = "stp_ins_upd_RolPermisos";
        public const string stp_del_EliminarRol = "stp_del_EliminarRol";
        #endregion
    }
}

