using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoAntirrabico.Views;

namespace ProyectoAntirrabico.ViewModel
{
    public class VMListaMascotasAdopcion:BaseViewModel
    {

        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public VMListaMascotasAdopcion(INavigation navigation)
        {
            Navigation = navigation;
        }
        #endregion
        #region OBJETOS
        public string Texto
        {
            get { return _Texto; }
            set { SetValue(ref _Texto, value); }
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

        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand IrLogincommand => new Command(async () => await IrLogin());
        public ICommand IrFormMAcommand => new Command(async () => await IrFormMascotasAdopcion());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion
    }
}
