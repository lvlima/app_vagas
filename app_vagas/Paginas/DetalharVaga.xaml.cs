using System;
using System.Collections.Generic;
using app_vagas.Modelo;

using Xamarin.Forms;

namespace app_vagas.Paginas
{
    public partial class DetalharVaga : ContentPage
    {
        public DetalharVaga(Vaga vaga)
        {
            InitializeComponent();

            BindingContext = vaga;
        }
    }
}
