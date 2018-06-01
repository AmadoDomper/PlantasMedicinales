using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.AccesoDatos;


namespace PlantasMedicinales.LogicaNegocio
{
    public class PlinianLN
    {

        PlinianAD oPlinianAD;

        public PlinianLN()
        {
            oPlinianAD = new PlinianAD();
        }

        public ListaPaginada ListarPlantasPag(int nPage = 1, int nSize = 10, string cValor = null)
        {
            return oPlinianAD.ListarPlantasPag(nPage, nSize, cValor);
        }

        public Usuario CargarDatosPlinian(int nPlinianId)
        {
            return oPlinianAD.CargarDatosPlinian(nPlinianId);
        }

        public int RegistrarModificarPlinian(Plinian oPlinian)
        {
            return oPlinianAD.RegistrarModificarPlinian(oPlinian);
        }

        public int EliminarPlinian(int nPlinianId)
        {
            return oPlinianAD.EliminarPlinian(nPlinianId);
        }


    }
}