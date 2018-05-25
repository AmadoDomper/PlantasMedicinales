using System.Collections.Generic;
using System.Linq;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.AccesoDatos;



namespace PlantasMedicinales.LogicaNegocio
{
    public class ConfiguracionLN
    {
        ConfiguracionAD oConfiguracionAD;

        public ConfiguracionLN()
        {
            oConfiguracionAD = new ConfiguracionAD();
        }

        public Rol CargaRolPermisos(int nRolId)
        {
            List<Menu> ListMenu = oConfiguracionAD.ListarMenuRol(nRolId);
            List<Modulo> ListModulo = oConfiguracionAD.ListarModuloRol(nRolId);
            List<Permiso> ListPermiso = oConfiguracionAD.ListarPermisoRol(nRolId);

            var RolPermisos = from lm in ListMenu
                              select new
                              {
                                  lm.nMenuId,
                                  lm.cMenuDesc,
                                  lm.bEstado,
                                  ListaModulos = from lmo1 in ListModulo
                                                 join lm2 in ListMenu
                                                 on lmo1.nMenuId equals lm2.nMenuId
                                                 where lmo1.nMenuId == lm.nMenuId
                                                 select new
                                                 {
                                                     lmo1.nModId,
                                                     lmo1.nMenuId,
                                                     lmo1.cModDesc,
                                                     lmo1.bEstado,
                                                     ListaPermisos = from lp in ListPermiso
                                                                     join lmo2 in ListModulo
                                                                     on lp.nModId equals lmo2.nModId
                                                                     where lp.nModId == lmo1.nModId
                                                                     select new
                                                                     {
                                                                         lp.nPermId,
                                                                         lp.nModId,
                                                                         lp.cPermDesc,
                                                                         lp.bEstado
                                                                     }
                                                 }
                              };

            Rol oRolPermisos = new Rol();
            oRolPermisos.nRolId = nRolId;

            foreach (var menu in RolPermisos)
            {
                Menu oMenu = new Menu();
                oMenu.nMenuId = menu.nMenuId;
                oMenu.cMenuDesc = menu.cMenuDesc;
                oMenu.bEstado = menu.bEstado;

                foreach (var modulo in menu.ListaModulos)
                {
                    Modulo oModulo = new Modulo();
                    oModulo.nModId = modulo.nModId;
                    oModulo.nMenuId = modulo.nMenuId;
                    oModulo.cModDesc = modulo.cModDesc;
                    oModulo.bEstado = modulo.bEstado;

                    foreach (var permiso in modulo.ListaPermisos)
                    {
                        Permiso oPermiso = new Permiso();

                        oPermiso.nPermId = permiso.nPermId;
                        oPermiso.nModId = permiso.nModId;
                        oPermiso.cPermDesc = permiso.cPermDesc;
                        oPermiso.bEstado = permiso.bEstado;

                        oModulo.ListaPermisos.Add(oPermiso);
                    }
                    oMenu.ListaModulos.Add(oModulo);
                }
                oRolPermisos.ListaMenus.Add(oMenu);
            }

            return oRolPermisos;
        }

        public int RegistrarActualizarRolPermisos(Rol lstRol)
        {

            ConfiguracionAD oConfAD = new ConfiguracionAD();

            List<Menu> ListMenu = new List<Menu>();
            List<Modulo> ListModulo = new List<Modulo>();
            List<Permiso> ListPermiso = new List<Permiso>();

            foreach (var menu in lstRol.ListaMenus)
            {
                Menu oMenu = new Menu();
                oMenu.nMenuId = menu.nMenuId;
                oMenu.bEstado = menu.bEstado;

                foreach (var modulo in menu.ListaModulos)
                {
                    Modulo oModulo = new Modulo();
                    oModulo.nModId = modulo.nModId;
                    oModulo.nMenuId = modulo.nMenuId;
                    oModulo.bEstado = modulo.bEstado;

                    foreach (var permiso in modulo.ListaPermisos)
                    {
                        Permiso oPermiso = new Permiso();

                        oPermiso.nPermId = permiso.nPermId;
                        oPermiso.nModId = permiso.nModId;
                        oPermiso.bEstado = permiso.bEstado;

                        ListPermiso.Add(oPermiso);
                    }
                    ListModulo.Add(oModulo);
                }
                ListMenu.Add(oMenu);
            }

            return oConfAD.RegistrarActualizarRolPermisos(lstRol.nRolId, lstRol.cRolDesc, ListMenu, ListModulo, ListPermiso);

        }

        public int EliminarRol(int nRolId)
        {
            return oConfiguracionAD.EliminarRol(nRolId);
        }
    }
}