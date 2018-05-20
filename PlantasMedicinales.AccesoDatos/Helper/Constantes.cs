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
        public const string sp_validaAcceso = "sp_validaAcceso";

        public const string stp_sel_ObtenerUsuarioContrasena = "stp_sel_ObtenerUsuarioContrasena";
        public const string stp_del_Usuario = "stp_del_Usuario";
        #endregion

        //Milenium 2017
        #region DocSunat
        public const string stp_sel_ListarDocSunat = "sp_listdocSUNAT";
        #endregion

        #region Sucursal
        public const string stp_sel_ListarNombreSucursal = "sp_listNomSuc";
        #endregion

        #region TipoCambio
        public const string stp_sel_ListarTipoMoneda = "sp_ListTipoMoneda";
        #endregion

        #region Cliente
        public const string stp_ins_Clientes = "sp_RegClientes";
        public const string stp_sel_ListarClientes = "sp_listClientes";
        public const string stp_sel_FiltrarClientes = "sp_filtraClientes";
        public const string sp_upd_Clientes = "sp_updClientes";
        public const string stp_sel_ClientesxDni = "sp_selClientesxDNI";
        public const string stp_del_EliminarCliente = "sp_Delete_Cliente";
        #endregion

        #region TarifaSucursal
        public const string stp_sel_ObtenerTarifaSucursal = "sp_selecTarifas";

        #endregion

        #region Ticketera
        public const string stp_sel_ObtenerNumeroTicket = "spMostrarNumeroTicket";
        #endregion

        #region Giro
        public const string stp_ins_RegistrarGiro = "sp_regEnvioGiroRecepcionista_DEMO_3";
        public const string sp_sel_ValidaGiros = "sp_sel_ValidaGirosWeb";
        public const string stp_sel_ConsultaSaldoAgenciaMargenPermisos = "sp_consultaSALDO_MARGEN_AGENCIA_ESTADO";
        #endregion

        //End Milenium 2017

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

        #region PersonaNat
        public const string stp_ins_upd_ClienteNatural = "stp_ins_upd_ClienteNatural";
        public const string stp_sel_ClienteNatural = "stp_sel_ClienteNatural";
        #endregion

        #region PersonaJur
        public const string stp_ins_upd_ClienteJuridico = "stp_ins_upd_ClienteJuridico";
        public const string stp_sel_ClienteJuridico = "stp_sel_ClienteJuridico";
        #endregion

        #region Usuarios
        public const string stp_sel_ListarUsuarios = "stp_sel_ListarUsuarios";
        public const string stp_sel_Usuario = "stp_sel_Usuario";
        public const string stp_ins_upd_Usuario = "stp_ins_upd_Usuario";
        public const string stp_sel_Usuarios = "stp_sel_Usuarios";
        #endregion

        #region Producto
        public const string stp_sel_ListarProductos = "stp_sel_ListarProductos";
        public const string stp_sel_Producto = "stp_sel_Producto";
        public const string stp_ins_upd_Producto = "stp_ins_upd_Producto";
        public const string stp_sel_BuscarProductos = "stp_sel_BuscarProductos";
        public const string stp_del_Producto = "stp_del_Producto";
        #endregion

        #region NotaEntrega
        public const string stp_ins_NotaEntrega = "stp_ins_NotaEntrega";
        public const string stp_sel_BuscarNotaEntregas = "stp_sel_BuscarNotaEntregas";
        public const string stp_sel_CargarNotaEntrega = "stp_sel_CargarNotaEntrega";
        public const string stp_sel_ListaNotaEntProductos = "stp_sel_ListaNotaEntProductos";
        public const string stp_ins_RealizarCobroServicio = "stp_ins_RealizarCobroServicio";
        public const string stp_ins_ConfirmarEntrega = "stp_ins_ConfirmarEntrega";
        public const string stp_ins_RealizarAnularComprobante = "stp_ins_RealizarAnularComprobante";
        public const string stp_ins_RealizarAnularNota = "stp_ins_RealizarAnularNota";
        public const string stp_ins_ModificarComentario = "stp_ins_ModificarComentario";
        public const string stp_sel_BuscarNotaEntPend = "stp_sel_BuscarNotaEntPend";
        #endregion

        #region Caja
        public const string stp_ins_SalidaEfectivoPagoProveedor = "stp_ins_SalidaEfectivoPagoProveedor";
        public const string stp_ins_SalidaEfectivoOtros = "stp_ins_SalidaEfectivoOtros";
        public const string stp_ins_IngresoEfectivo = "stp_ins_IngresoEfectivo";
        public const string stp_sel_BuscarMovCaja = "stp_sel_BuscarMovCaja";
        public const string stp_sel_ConfirmacionDineroPendiente = "stp_sel_ConfirmacionDineroPendiente";
        public const string stp_sel_CajaDiaAbierto = "stp_sel_CajaDiaAbierto";
        public const string stp_ins_RegistrarAsigMonto = "stp_ins_RegistrarAsigMonto";
        public const string stp_ins_ConfirmarDineroEntrega = "stp_ins_ConfirmarDineroEntrega";
        #endregion


        #region CierreDeCaja
        public const string stp_sel_ListaNotasAnticipo = "stp_sel_ListaNotasAnticipo";
        public const string stp_sel_ListaNotasPagadas = "stp_sel_ListaNotasPagadas";
        public const string stp_sel_ListaPagoProveedores = "stp_sel_ListaPagoProveedores";
        public const string stp_sel_ListaDetalleCierre = "stp_sel_ListaDetalleCierre";
        public const string stp_sel_ListaCajeros = "stp_sel_ListaCajeros";
        public const string stp_sel_ListaCierre = "stp_sel_ListaCierre";
        public const string stp_sel_UltimaFechaCajaDia = "stp_sel_UltimaFechaCajaDia";
        public const string stp_ins_RealizarCierreCaja = "stp_ins_RealizarCierreCaja";
        public const string stp_ins_RealizarCierreCajaDia = "stp_ins_RealizarCierreCajaDia";
        public const string stp_sel_ObtenerDatosCierre = "stp_sel_ObtenerDatosCierre";
        public const string stp_sel_ObtenerDatosCierreDia = "stp_sel_ObtenerDatosCierreDia";
        public const string stp_sel_UsuarioIniciaDia = "stp_sel_UsuarioIniciaDia";
        public const string stp_sel_UltimoSaldoCaja = "stp_sel_UltimoSaldoCaja";
        #endregion

        #region AperturaCaja
        public const string stp_ins_AperturarCaja = "stp_ins_AperturarCaja";
        #endregion

        #region Ubigeo
        public const string stp_sel_Departamento = "stp_sel_Departamento";
        public const string stp_sel_Provincia = "stp_sel_Provincia";
        public const string stp_sel_Distrito = "stp_sel_Distrito";
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

        #region Impresion
        public const string stp_sel_ObtenerDatosTicket = "stp_sel_ObtenerDatosTicket";
        public const string stp_sel_ObtenerDatosNotaEntImp = "stp_sel_ObtenerDatosNotaEntImp";
        public const string stp_sel_ListaNotaEntProductos_TicketId = "stp_sel_ListaNotaEntProductos_TicketId";
        #endregion


        #region Reportes
        public const string stp_sel_ObtenerComprasProveedores = "stp_sel_ObtenerComprasProveedores";
        public const string stp_sel_ObtenerVentasIngresos = "stp_sel_ObtenerVentasIngresos";
        public const string stp_sel_ObtenerNotaEntregas = "stp_sel_ObtenerNotaEntregas";
        #endregion
    }
}

