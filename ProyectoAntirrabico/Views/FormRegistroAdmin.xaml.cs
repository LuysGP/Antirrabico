using ProyectoAntirrabico.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAntirrabico.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FormRegistroAdmin : ContentPage
    {

        public FormRegistroAdmin()
        {
            InitializeComponent();
            BindingContext = new VMRegistroAdmin(Navigation);
        }
    }
}