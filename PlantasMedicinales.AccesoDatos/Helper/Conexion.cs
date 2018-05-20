using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlantasMedicinales.AccesoDatos.Helper
{
    public class Conexion
    {
        public static string cnsPlaMedicinales = "cnsPlanMedicinales";
        public static string cnsPlaMedicinalesSQL = ConfigurationManager.ConnectionStrings["cnsPlanMedicinales"].ToString();
    }
}
