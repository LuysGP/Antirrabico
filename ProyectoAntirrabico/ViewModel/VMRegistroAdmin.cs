using Firebase.Auth;
using Plugin.Media.Abstractions;
using ProyectoAntirrabico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProyectoAntirrabico.ViewModel
{
    public class VMRegistroAdmin : BaseViewModel
    {
        #region VARIABLES
        string _Nombres;
        string _Apellidos;
        string _Area;
        string _Correo;
        string _Contraseña;
        string _LinkFoto;

        #endregion
        #region CONSTRUCTOR
        public VMRegistroAdmin(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Nombres
        {
            get { return _Nombres; }
            set { SetValue(ref _Nombres, value); }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { SetValue(ref _Apellidos, value); }
        }

        public string LinkFoto
        {
            get { return _LinkFoto; }
            set { SetValue(ref _LinkFoto, value); }
        }

        public string Area
        {
            get { return _Area; }
            set { SetValue(ref _Area, value); }
        }

        public string SeleccionArea
        {
            get { return _Area; }
            set { SetProperty(ref _Area, value);
                Area = _Area;
            }
        }

        public string Correo
        {
            get { return _Correo; }
            set { SetValue(ref _Correo, value); }
        }

        public string Contraseña
        {
            get { return _Contraseña; }
            set { SetValue(ref _Contraseña, value); }
        }

        #endregion
        #region PROCESOS
        public async void Registrar()
        {
            //Validaciones para el usuario y contraseña

            if (string.IsNullOrEmpty(this._Correo))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Necesita ingresar un correo", "Aceptar"
                );
                return;
            }
            if (string.IsNullOrEmpty(this._Contraseña))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Necesita ingresar una contraseña", "Aceptar"
                );
                return;
            }

            string ClaveWebAPI = "AIzaSyCM5hy5-xg6TQGsqmsBqkyknZl-fef_D6E";

            try
            {
                var authProvider = new FirebaseAuthProvider(new FirebaseConfig(ClaveWebAPI));
                var auth = await authProvider.CreateUserWithEmailAndPasswordAsync(Correo.ToString(), Contraseña.ToString());
                string gettoken = auth.FirebaseToken;

                await Navigation.PopAsync();
            }
            catch (Exception E)
            {
                await DisplayAlert("Alerta", E.Message, "Ok");
            }
        }
        public async void Cancelar()
        {
            Nombres = null;
            Apellidos = null;
            LinkFoto = null;
            SeleccionArea = null;
            Correo = null;
            Contraseña = null;
            Foto = null;

            await Navigation.PopAsync();
        }

        public async void TomarFoto()
        {
            var camara = new StoreCameraMediaOptions();
            camara.PhotoSize = PhotoSize.Full;
            camara.SaveToAlbum = true;

            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(camara);

            if(foto!=null)
            {
                Foto = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }

        public async Task AbrirNavegador()
        {
            await Browser.OpenAsync("https://imgbb.com/", BrowserLaunchMode.SystemPreferred);
        }
        #endregion
        #region COMANDOS
        public ICommand Registrarcommand => new Command(Registrar);
        public ICommand Cancelarcommand => new Command(Cancelar);

        //Comando que ejecuta el proceso TomarFoto
        public ICommand TomarFotocommand => new Command(TomarFoto);

        public ICommand AbrirNavcommand => new Command(async () => await AbrirNavegador());
        #endregion
    }
}
