using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database; //INVOCANDO LAS LIBRERIAS DEL PAQUETE NuGet

namespace ProyectoAntirrabico.Conexion
{
    public class CConexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://appprueba-4a0cf-default-rtdb.firebaseio.com/");
    }
}
