using System;
using System.IO;
using Xamarin.Forms;
using app_vagas.Banco;
using app_vagas.iOS.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace app_vagas.iOS.Banco
{
    public class Caminho : ICaminho
    {
        public Caminho()
        {
        }

        public string ObterCaminho(string nomeArquivoBD)
        {
            string caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBiblioteca = Path.Combine(caminhoPasta, "..", "Library");

            string caminhoBD = Path.Combine(caminhoBiblioteca, nomeArquivoBD);

            return caminhoBD;
        }
    }
}
