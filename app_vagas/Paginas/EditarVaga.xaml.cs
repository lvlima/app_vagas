using System;
using System.Collections.Generic;
using app_vagas.Modelo;
using app_vagas.Banco;

using Xamarin.Forms;

namespace app_vagas.Paginas
{
    public partial class EditarVaga : ContentPage
    {
        private Vaga Vaga { get; set; }

        public EditarVaga(Vaga vaga)
        {
            InitializeComponent();

            Vaga = vaga;

            edtVaga.Text = vaga.NomeVaga;
            edtEmpresa.Text = vaga.Empresa;
            edtQuantidade.Text = vaga.Quantidade.ToString();
            edtCidade.Text = vaga.Cidade;
            edtSalario.Text = vaga.Salario.ToString();
            vaga.Descricao = edtDescricao.Text;
            swtTipoContratacao.IsToggled = (vaga.TipoContratacao == "CLT") ? false : true;
            edtTelefone.Text = vaga.Telefone;
            edtEmail.Text = vaga.Email;
        }

        private void ActionSalvar(object sender, EventArgs args)
        {
            Vaga.NomeVaga = edtVaga.Text;
            Vaga.Empresa = edtEmpresa.Text;
            Vaga.Quantidade = short.Parse(edtQuantidade.Text);
            Vaga.Cidade = edtCidade.Text;
            Vaga.Salario = double.Parse(edtSalario.Text);
            Vaga.Descricao = edtDescricao.Text;
            Vaga.TipoContratacao = (swtTipoContratacao.IsToggled) ? "PJ" : "CLT";
            Vaga.Telefone = edtTelefone.Text;
            Vaga.Email = edtEmail.Text;

            Database database = new Database();
            database.Atualizar(Vaga);

            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastradas());
        }
    }
}
