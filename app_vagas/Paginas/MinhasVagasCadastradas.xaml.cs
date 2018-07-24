using System;
using System.Collections.Generic;
using System.Linq;
using app_vagas.Modelo;
using app_vagas.Banco;

using Xamarin.Forms;

namespace app_vagas.Paginas
{
    public partial class MinhasVagasCadastradas : ContentPage
    {
        List<Vaga> ListaVagas { get; set; }

        public MinhasVagasCadastradas()
        {
            InitializeComponent();

            ConsultarVagas();
        }

        private void ConsultarVagas()
        {
            Database database = new Database();

            ListaVagas = database.Listar();

            lsvVagas.ItemsSource = ListaVagas;

            lblCount.Text = ListaVagas.Count.ToString() + " vagas encontradas.";
        }

        private void ActionEditar (object sender, EventArgs args)
        {
            Label lblEditar = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)lblEditar.GestureRecognizers[0]).CommandParameter as Vaga;

            Navigation.PushAsync(new EditarVaga(vaga));
        }

        private void ActionExcluir(object sender, EventArgs args)
        {
            Label lblExcluir = (Label)sender;
            Vaga vaga = ((TapGestureRecognizer)lblExcluir.GestureRecognizers[0]).CommandParameter as Vaga;

            Database database = new Database();
            database.Excluir(vaga);

            ConsultarVagas();
        }

        private void ActionFiltrarVagas(object sender, TextChangedEventArgs args)
        {
            lsvVagas.ItemsSource = ListaVagas.Where(a => a.NomeVaga.Contains(args.NewTextValue)).ToList();
            lblCount.Text = ListaVagas.Count.ToString() + " vagas encontradas.";
        }
    }
}
