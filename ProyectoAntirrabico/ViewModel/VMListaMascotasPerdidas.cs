using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using ProyectoAntirrabico.Views;

namespace ProyectoAntirrabico.ViewModel
{
    public class VMListaMascotasPerdidas:BaseViewModel
    {

        #region VARIABLES
        string _Texto;
        #endregion
        #region CONSTRUCTOR
        public VMListaMascotasPerdidas(INavigation navigation)
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
        public async Task IrListaMascotasAdopcion()
        {
            await Navigation.PushAsync(new ListaMascotasAdopcion());
        }

        public async Task IrFormMascotasPerdidas()
        {
            await Navigation.PushAsync(new FormMascotasPerdidas());
        }

        public async Task IrLogin()
        {
            await Navigation.PushAsync(new Login());
        }

        public void ProcesoSimple()
        {

        }
        #endregion
        #region COMANDOS
        public ICommand IrListaMAcommand => new Command(async () => await IrListaMascotasAdopcion());
        public ICommand IrFormMPcommand => new Command(async () => await IrFormMascotasPerdidas());
        public ICommand IrLogincommand => new Command(async () => await IrLogin());
        public ICommand ProcesoSimpcommand => new Command(ProcesoSimple);
        #endregion

    }
}
