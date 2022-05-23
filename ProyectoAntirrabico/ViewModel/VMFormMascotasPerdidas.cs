using System;
using System.Collections.Generic;
using System.Text;
//LIBRERIAS NECESARIAS
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.Media.Abstractions;
using ProyectoAntirrabico.Views;
using ProyectoAntirrabico.Model;
using ProyectoAntirrabico.Data;

namespace ProyectoAntirrabico.ViewModel
{
    public class VMFormMascotasPerdidas:BaseViewModel
    {
        #region VARIABLES
        string _txtLinkFoto;
        string _txtArea;
        string _txtEspecie;
        string _txtSexo;
        string _txtEdad;
        string _txtColores;
        string _txtRaza;

        #endregion
        #region CONSTRUCTOR
        public VMFormMascotasPerdidas(INavigation navigation)
        {
            Navigation = navigation;
            ValidarConexionInternet();
        }
        #endregion
        #region OBJETOS
        public string txtLinkFoto
        {
            get { return _txtLinkFoto; }
            set { SetValue(ref _txtLinkFoto, value); }
        }

        public string txtArea
        {
            get { return _txtArea; }
            set { SetValue(ref _txtArea, value); }
        }

        public string SeleccionArea
        {
            get { return _txtArea; }
            set
            {
                SetProperty(ref _txtArea, value);
                txtArea = "Localizado en "+_txtArea;
            }
        }
        public string txtEspecie
        {
            get { return _txtEspecie; }
            set { SetValue(ref _txtEspecie, value); }
        }

        public string txtSexo
        {
            get { return _txtSexo; }
            set { SetValue(ref _txtSexo, value); }
        }

        public string SeleccionSexo
        {
            get { return _txtSexo; }
            set
            {
                SetProperty(ref _txtSexo, value);
                txtSexo = _txtSexo;
            }
        }

        public string txtEdad
        {
            get { return _txtEdad; }
            set { SetValue(ref _txtEdad, value); }
        }

        public string txtColores
        {
            get { return _txtColores; }
            set { SetValue(ref _txtColores, value); }
        }

        public string txtRaza
        {
            get { return _txtRaza; }
            set { SetValue(ref _txtRaza, value); }
        }

        #endregion
        #region PROCESOS
        public async void TomarFoto()
        {
            var camara = new StoreCameraMediaOptions();
            camara.PhotoSize = PhotoSize.Full;
            camara.SaveToAlbum = true;

            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(camara);

            if (foto != null)
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

        public async void Cancelar()
        {
            Foto = null;
            txtLinkFoto = null;
            SeleccionArea = null;
            txtEspecie = null;
            SeleccionSexo = null;
            txtEdad = null;
            txtColores = null;
            txtRaza = null;

            await Navigation.PopAsync();

        }

        public async Task InsertarMP()
        {
            var funcion = new DMascotasPerdidas();
            var parametros = new MMascotasPerdidas();


            //Se asignan los valores de los objetos
            parametros.LinkFoto = txtLinkFoto;
            parametros.Area = SeleccionArea;
            parametros.Especie = txtEspecie;
            parametros.Sexo = SeleccionSexo;
            parametros.Edad = txtEdad;
            parametros.Colores = txtColores;
            parametros.Raza = txtRaza;

            await funcion.InsertarMascotasPerdidas(parametros);

            await DisplayAlert("Listo", "Se ha registrado otra mascota", "Ok");

            await Navigation.PopAsync();
           
        }

        #endregion
        #region COMANDOS
        public ICommand AbrirNavegadorcommand => new Command(async () => await AbrirNavegador());
        public ICommand InsertarMPcommand => new Command(async () => await InsertarMP());
        public ICommand TomarFotocommand => new Command(TomarFoto);
        public ICommand Cancelarcommand => new Command(Cancelar);
        #endregion
    }
}
