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
using System.Collections.ObjectModel;

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
                    Nombre = parametros.Nombre,
                    Edad = parametros.Edad,
                    Especie = parametros.Especie,
                    LinkFoto = parametros.LinkFoto,
                    Raza = parametros.Raza,
                    Sexo = parametros.Sexo
                }
                );
        }

        //CONSULTAR
        public async Task<ObservableCollection<MMascotasAdopocion>> MostrarMA()
        {
            var data = await Task.Run(() => CConexion.firebase
            .Child("MascotasAdopcion")
            .AsObservable<MMascotasAdopocion>()
            .AsObservableCollection());

            return data;
        }

        public async Task<List<MMascotasAdopocion>> MostrarMAList()
        {
            return (await CConexion.firebase
                .Child("MascotasAdopcion")
                .OnceAsync<MMascotasAdopocion>()).Select(Mascota => new MMascotasAdopocion
                {
                    IdMascotaAdopcion = Mascota.Key,
                    LinkFoto = Mascota.Object.LinkFoto,
                    Nombre = Mascota.Object.Nombre,
                    Area = Mascota.Object.Area,
                    Edad = Mascota.Object.Edad,
                    Raza = Mascota.Object.Raza,
                    Sexo = Mascota.Object.Sexo
                }).ToList();
        }
    }

}
