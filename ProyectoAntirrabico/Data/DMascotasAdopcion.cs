using System;
using System.Collections.Generic;
using System.Text;
//LIBRERIAS NECESARIAS
using ProyectoAntirrabico.Model;
using ProyectoAntirrabico.Conexion;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;

namespace ProyectoAntirrabico.Data
{
    public class DMascotasAdopcion
    {
        //INSERTAR
        public async Task InsertarMA(MMascotasAdopocion parametros)
        {
            await CConexion.firebase
                .Child("MascotasAdopcion")
                .PostAsync(new MMascotasAdopocion()
                {
                    Area = parametros.Area,
                    Colores = parametros.Colores,
                    Edad = parametros.Edad,
                    Especie = parametros.Especie,
                    LinkFoto = parametros.LinkFoto,
                    Raza = parametros.Raza,
                    Sexo = parametros.Sexo
                }
                );
        }

        //CONSULTAR
        public async Task<List<MMascotasAdopocion>> MostrarMA()
        {
            return (await CConexion.firebase
                .Child("MascotasAdopcion")
                .OnceAsync<MMascotasAdopocion>()).Select(item => new MMascotasAdopocion
                {
                    IdMascotaAdopcion = item.Key,
                    LinkFoto = item.Object.LinkFoto,
                    Nombre = item.Object.Nombre,
                    Area = item.Object.Area,
                    Sexo = item.Object.Sexo,
                    Edad = item.Object.Edad,
                    Raza = item.Object.Raza
                }).ToList();
        }
    }

}
