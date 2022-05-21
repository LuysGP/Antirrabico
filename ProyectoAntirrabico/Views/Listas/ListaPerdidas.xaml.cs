﻿using ProyectoAntirrabico.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoAntirrabico.Views.Listas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaPerdidas : ContentPage
    {
        public ListaPerdidas()
        {
            InitializeComponent();
            BindingContext = new VMListaPerdidas(Navigation,Izquierda,Derecha);
        }
    }
}