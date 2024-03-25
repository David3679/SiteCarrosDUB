using Microsoft.EntityFrameworkCore;
using SiteCarrosDUB.Data;
using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.Repositorios
{
    public class AcessoriosRepositorio : IAcessoriosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public AcessoriosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public AcessoriosModel ListarPorId(int id)
        {
            return _bancoContext.Acessorios.FirstOrDefault(x => x.Id == id);       
        }
        public List<AcessoriosModel> BuscarTodos()
        {
            return _bancoContext.Acessorios.ToList();
        }
        public AcessoriosModel Adicionar(AcessoriosModel acessorios)
        {
            _bancoContext.Acessorios.Add(acessorios);
            _bancoContext.SaveChanges();
            return acessorios;

        }
        public AcessoriosModel Atualizar(AcessoriosModel acessorios)
        {
            AcessoriosModel acessoriosDB = ListarPorId(acessorios.Id);
            if (acessoriosDB == null) throw new System.Exception("Houve um erro ao editar o contato");

            acessoriosDB.NomeDaPeca = acessorios.NomeDaPeca;
            acessoriosDB.Marca = acessorios.Marca;
            acessoriosDB.Valor = acessorios.Valor;

            _bancoContext.Update(acessoriosDB);
            _bancoContext.SaveChanges();

            return acessoriosDB;
        }

        public bool Apagar(int id)
        {
            AcessoriosModel acessoriosDB = ListarPorId(id);

            if (acessoriosDB == null) throw new System.Exception("Houve um erro ao deletar o usuário");

            _bancoContext.Acessorios.Remove(acessoriosDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
