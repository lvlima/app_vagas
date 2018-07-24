using System;
using System.IO;
using Xamarin.Forms;
using app_vagas.Banco;
using app_vagas.Droid.Banco;

[assembly:Dependency(typeof(Caminho))]
namespace app_vagas.Droid.Banco
{
    public class Caminho : ICaminho
    {
        public Caminho()
        {
        }

        public string ObterCaminho(string nomeArquivoBD)
        {
            string caminhoPasta = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            string caminhoBD = Path.Combine(caminhoPasta, nomeArquivoBD);

            return caminhoBD;
        }
    }
}
