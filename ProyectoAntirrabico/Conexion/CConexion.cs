using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database; //INVOCANDO LAS LIBRERIAS DEL PAQUETE NuGet

namespace ProyectoAntirrabico.Conexion
{
    public class CConexion
    {
        public static FirebaseClient fireBase = new FirebaseClient("https://appmascotas-f970f-default-rtdb.firebaseio.com/");
    }
}
