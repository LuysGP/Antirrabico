using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoAntirrabico.Views;
using ProyectoAntirrabico.Model;
using ProyectoAntirrabico.Data;

namespace ProyectoAntirrabico.ViewModel
{
    public class VMListaMascotasAdopcion : BaseViewModel
    {

        #region VARIABLES
        string _Texto;

        int _index;

        //SE CREA UNA LISTA PARA PODER MOSTRAR LOS DATOS
        List<MMascotasAdopocion> _ListaMA;

        #endregion
        #region CONSTRUCTOR
        public VMListaMascotasAdopcion(INavigation navigation, StackLayout CDerecha, StackLayout CIzquierda)
        {
            Navigation = navigation;
            MostrarMascotasAdopcion(CDerecha,CIzquierda);
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
        }
        public List<MMascotasAdopocion> ListaMA
        {
            get { return _ListaMA; }
            set { SetValue(ref _ListaMA, value); }
        }
        #endregion
        #region PROCESOS
        public async Task IrLogin()
        {
            await Navigation.PushAsync(new Login());
        }

        public async Task IrFormMascotasAdopcion()
        {
            await Navigation.PushAsync(new FormMascotasAdopcion());
        }

        public void DibujarMascotaAdopcion(MMascotasAdopocion mascota, int index, StackLayout CDerecha, StackLayout CIzquierda)
        {
            //CALCULO QUE DEFINE DONDE ESTARA UBICADO CADA Mascota
            var _ubicacion = Convert.ToBoolean(index % 2);

            //INDICA QUE CADA MASCOTA SE VA A ORGANIZAR DE FORMA PROPORCIONAL EN CADA CARRIL
            var carril = _ubicacion ? CDerecha : CIzquierda;

            var FramePadre = new Frame
            {
                BackgroundColor = Color.White,
                HeightRequest = 320,
                CornerRadius = 10,
                Padding = 0,
                HasShadow = false,
                Margin = 10
            };

            var StackLayoutPadre = new StackLayout
            {

            };
            var FrameHijo = new Frame
            {
                Margin = new Thickness(10, 5, 10, 0),
                Padding = 0,
                HasShadow = false,
                CornerRadius = 10,
                HeightRequest = 125,
            };
            var FotoMascota = new Image
            {
                Source = mascota.LinkFoto,
                HeightRequest = 125,
                HorizontalOptions = LayoutOptions.Center
            };

            var LabelNombre = new Label
            {
                Text = mascota.Nombre,
                TextColor = Color.Black,
                FontAttributes = FontAttributes.Bold,
                FontSize = 22,
                HorizontalOptions = LayoutOptions.Center,
                CharacterSpacing = 1
            };

            var LabelEdad = new Label
            {
                Text = mascota.Edad,
                TextColor = Color.Gray,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
            };

            var LabelSexo = new Label
            {
                Text = mascota.Sexo,
                TextColor = Color.Gray,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, -5, 0, 0)
            };

            var LabelRaza = new Label
            {
                Text = mascota.Raza,
                TextColor = Color.Gray,
                FontSize = 18,
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, -5, 0, 0),
                CharacterSpacing = 2
            };

            var SLBotones = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(10, 10, 10, 10),
                HorizontalOptions = LayoutOptions.Center
            };
            var FrameBotonEdit = new Frame
            {
                BackgroundColor = Color.FromHex("#0984e3"),
                HeightRequest = 30,
                Padding = 5,
                CornerRadius = 5,
                Margin = new Thickness(0, 0, 10, 0)
            };
            var BotonEdit = new Image
            {
                Source = "https://i.ibb.co/2g2Yztc/edit.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            var FrameBotonDelete = new Frame
            {
                BackgroundColor = Color.FromHex("#d63031"),
                HeightRequest = 30,
                Padding = 5,
                CornerRadius = 5,
            };
            var BotonDelete = new Image
            {
                Source = "https://i.ibb.co/ph9JNn1/delete.png",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            //AGRUPACION DE LOS ELEMENTOS
            FrameHijo.Content = FotoMascota;
            StackLayoutPadre.Children.Add(FrameHijo);
            StackLayoutPadre.Children.Add(LabelNombre);
            StackLayoutPadre.Children.Add(LabelEdad);
            StackLayoutPadre.Children.Add(LabelSexo);
            StackLayoutPadre.Children.Add(LabelRaza);

            FrameBotonDelete.Content = BotonDelete;
            FrameBotonEdit.Content = BotonEdit;
            SLBotones.Children.Add(FrameBotonEdit);
            SLBotones.Children.Add(FrameBotonDelete);

            StackLayoutPadre.Children.Add(SLBotones);
            FramePadre.Content = StackLayoutPadre;

            carril.Children.Add(FramePadre);
        }

        public async Task MostrarMascotasAdopcion(StackLayout CDerecha, StackLayout CIzquierda)
        {
            var funcion = new DMascotasAdopcion();

            ListaMA = await funcion.MostrarMA();

            //RECORRE TODA LA LISTA PARA PODER DESPUES MOSTRARLA
            foreach(var mascotas in ListaMA)
            {
                DibujarMascotaAdopcion(mascotas, _index, CDerecha, CIzquierda);
                _index++;
            }
        }
        #endregion

        #region COMANDOS
        public ICommand IrLogincommand => new Command(async () => await IrLogin());
        public ICommand IrFormMAcommand => new Command(async () => await IrFormMascotasAdopcion());
        //public ICommand ProcesoSimpcommand => new Command(DibujarMascotaAdopcion);
        #endregion
    }
}
