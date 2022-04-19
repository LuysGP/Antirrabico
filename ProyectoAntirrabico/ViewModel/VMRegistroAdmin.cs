using Firebase.Auth;
using GalaSoft.MvvmLight.Command;
using ProyectoAntirrabico.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public string Area
        {
            get { return _Area; }
            set { SetValue(ref _Area, value); }
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
            Area = null;
            Correo = null;
            Contraseña = null;

            await Navigation.PopAsync();
        }
        #endregion
        #region COMANDOS
        public ICommand Registrarcommand
        {
            get 
            {
                return new RelayCommand(Registrar);
            }
        }
        public ICommand Cancelarcommand => new Command(Cancelar);
        //public ICommand ProcesoSimpcommand => new Command(async () => await ProcesoSimple());
        #endregion
    }
}
