using System;
using System.Collections.Generic;
using System.Text;
//LIBRERIAS NECESARIAS
using ProyectoAntirrabico.Model;
using ProyectoAntirrabico.Conexion;
using Firebase.Database.Query;
using Firebase.Database;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

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

        //Consultas  Mascotas Perididas con un ObservableCollection
        public async Task<ObservableCollection<MMascotasPerdidas>> MostrarMP()
        {
            var data = await Task.Run(() => CConexion.firebase
            .Child("MascotasPerdidas")
            .AsObservable<MMascotasPerdidas>()
            .AsObservableCollection());

            return data;
        }

        //Consultas  Mascotas Perididas con una lista
        public async Task<List<MMascotasPerdidas>> MostrarMPList()
        {
            return (await CConexion.firebase
                .Child("MascotasPerdidas")
                .OnceAsync<MMascotasPerdidas>()).Select(Mascota => new MMascotasPerdidas
                {
                    IdMascotaPerdida = Mascota.Key,
                    LinkFoto = Mascota.Object.LinkFoto,
                    Area = Mascota.Object.Area,
                    Edad = Mascota.Object.Edad,
                    Raza = Mascota.Object.Raza,
                    Sexo = Mascota.Object.Sexo

                }).ToList();
        }
    }
}
