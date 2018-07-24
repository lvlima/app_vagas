using System;
using System.Collections.Generic;
using app_vagas.Modelo;
using app_vagas.Banco;

using Xamarin.Forms;

namespace app_vagas.Paginas
{
    public partial class CadastrarVaga : ContentPage
    {
        public CadastrarVaga()
        {
            InitializeComponent();
        }

        private void ActionSalvar(object sender, EventArgs args)
        {
            Vaga vaga = new Vaga();

            vaga.NomeVaga = edtVaga.Text;
            vaga.Empresa = edtEmpresa.Text;
            vaga.Quantidade = short.Parse(edtQuantidade.Text);
            vaga.Cidade = edtCidade.Text;
            vaga.Salario = double.Parse(edtSalario.Text);
            vaga.Descricao = edtDescricao.Text;
            vaga.TipoContratacao = (swtTipoContratacao.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = edtTelefone.Text;
            vaga.Email = edtEmail.Text;

            Database database = new Database();
            database.Inserir(vaga);

            App.Current.MainPage = new NavigationPage(new ConsultarVagas()); 
        }

    }
}
