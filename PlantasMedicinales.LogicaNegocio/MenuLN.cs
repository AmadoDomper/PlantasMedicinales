using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.AccesoDatos;

namespace PlantasMedicinales.LogicaNegocio
{
    public class MenuLN
    {
        MenuAD oMenuAD;

        public MenuLN()
        {
            oMenuAD = new MenuAD();
        }

        public List<Menu> ObtenerMenusFull(int nRolId)
        {
            try
            {
                return oMenuAD.ObtenerMenuFull(nRolId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    }
}
