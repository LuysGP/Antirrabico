using System;
using System.Collections.Generic;
using System.Text;
//LIBRERIAS NECESARIAS
using ProyectoAntirrabico.Model;
using ProyectoAntirrabico.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoAntirrabico.Data
{
    public class DMascotasPerdidas
    {
        //Insercion de Mascotas Perdidas
        public async Task InsertarMascotasPerdidas(MMascotasPerdidas parametros)
        {
            await CConexion.firebase
                .Child("MascotasPerdidas")
                .PostAsync(new MMascotasPerdidas()
                {
                    Area = parametros.Area,
                    Colores = parametros.Colores,
                    Edad = parametros.Edad,
                    Especie = parametros.Especie,
                    LinkFoto = parametros.LinkFoto,
                    Raza = parametros.Raza,
                    Sexo = parametros.Sexo
                });
        }
    }
}
