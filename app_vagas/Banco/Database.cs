using System;
using System.Collections.Generic;
using SQLite;
using app_vagas.Modelo;
using Xamarin.Forms;
using System.Linq;

namespace app_vagas.Banco
{
    public class Database
    {
        private SQLiteConnection _conexao;

        public Database()
        {
            var dep = DependencyService.Get<ICaminho>();
            string caminhoBD = dep.ObterCaminho("dbvagas.sqlite");

            _conexao = new SQLiteConnection(caminhoBD);

            _conexao.CreateTable<Vaga>();
        }

        public List<Vaga> Listar()
        {
            return _conexao.Table<Vaga>().ToList();
        }

        public List<Vaga> ListarPorNome(string termo)
        {
            return _conexao.Table<Vaga>().Where(a => a.NomeVaga.Contains(termo)).ToList();
        }

        public Vaga ListarPorId(int id)
        {
            return _conexao.Table<Vaga>().Where(a => a.Id == id).FirstOrDefault();
        }

        public void Inserir(Vaga vaga)
        {
            _conexao.Insert(vaga);
        }

        public void Atualizar(Vaga vaga)
        {
            _conexao.Update(vaga);
        }

        public void Excluir(Vaga vaga)
        {
            _conexao.Delete(vaga);
        }

    }
}
