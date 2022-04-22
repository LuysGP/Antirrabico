using System;
using System.Collections.Generic;
using System.Text;
//LIBRERIAS REQUERIDAS
using ProyectoAntirrabico.Model;
using ProyectoAntirrabico.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoAntirrabico.Data
{
    public class DAdministradores
    {
        //Inserción de administradores
        public async Task InsertarAdmin(MAdmistradores parametros)
        {
            await CConexion.firebase
                .Child("Administradores")
                .PostAsync(new MAdmistradores()
                {
                    Apellidos = parametros.Apellidos,
                    Nombres = parametros.Nombres,
                    Area = parametros.Area,
                    LinkFoto = parametros.LinkFoto,
                    Contraseña = parametros.Contraseña,
                    Correo = parametros.Correo
                });
        }
    }
}
