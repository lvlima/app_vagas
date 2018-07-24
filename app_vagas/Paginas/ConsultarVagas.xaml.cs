using System;
using System.Collections.Generic;
using System.Linq;
using app_vagas.Modelo;
using app_vagas.Banco;

using Xamarin.Forms;

namespace app_vagas.Paginas
{
    public partial class ConsultarVagas : ContentPage
    {
        List<Vaga> ListaVagas { get; set; }

        public ConsultarVagas()
        {
            InitializeComponent();
            Database database = new Database();

            ListaVagas = database.Listar();

            lsvVagas.ItemsSource = ListaVagas;

            lblCount.Text = ListaVagas.Count.ToString() + " vagas encontradas.";
        }

        private void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastrarVaga());
        }

        private void GoMinhasVagas(object sender, EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        private void ActionMaisDetalhes(object sender, EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)lblDetalhe.GestureRecognizers[0]).CommandParameter as Vaga;

            Navigation.PushAsync(new DetalharVaga(vaga));
        }

        private void ActionFiltrarVagas(object sender, TextChangedEventArgs args)
        {
            lsvVagas.ItemsSource = ListaVagas.Where(a => a.NomeVaga.Contains(args.NewTextValue)).ToList();
            lblCount.Text = ListaVagas.Count.ToString() + " vagas encontradas.";
        }
    }
}
