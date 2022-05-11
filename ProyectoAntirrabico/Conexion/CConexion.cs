using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database; //INVOCANDO LAS LIBRERIAS DEL PAQUETE NuGet

namespace ProyectoAntirrabico.Conexion
{
    public class CConexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://appmascotas-a2b71-default-rtdb.firebaseio.com/");
    }
}
