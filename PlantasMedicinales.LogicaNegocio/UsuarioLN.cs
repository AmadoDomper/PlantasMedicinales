﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlantasMedicinales.Entidades;
using PlantasMedicinales.AccesoDatos;


namespace PlantasMedicinales.LogicaNegocio
{
    public class UsuarioLN
    {
        UsuarioAD oUsuarioAD;

        public UsuarioLN()
        {
            oUsuarioAD = new UsuarioAD();
        }

        public ListaPaginada ListarUsuariosPag(int nPage = 1, int nSize = 10,  string cValor = null)
        {
            return oUsuarioAD.ListarUsuariosPag(nPage, nSize, cValor);
        }

        public Usuario CargarDatosUsuario(int nUsuId)
        {
            return oUsuarioAD.CargarDatosUsuario(nUsuId);
        }

        public int RegistrarModificarUsuario(Usuario oUsuario)
        {
            return oUsuarioAD.RegistrarModificarUsuario(oUsuario);
        }

        public int EliminarUsuario(int nUsuarioId)
        {
            return oUsuarioAD.EliminarUsuario(nUsuarioId);
        }
    }
}
