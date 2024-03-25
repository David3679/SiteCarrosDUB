using Microsoft.EntityFrameworkCore;
using SiteCarrosDUB.Data;
using SiteCarrosDUB.Models;

namespace SiteCarrosDUB.Repositorios
{
    public class UsuariosRepositorio : IUsuariosRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuariosRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuariosModel ListarPorId(int id)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Id == id);       
        }
        public List<UsuariosModel> BuscarTodos()
        {
            return _bancoContext.Usuarios.ToList();
        }
        public UsuariosModel Adicionar(UsuariosModel usuarios)
        {
            _bancoContext.Usuarios.Add(usuarios);
            usuarios.SenhaHash();
            _bancoContext.SaveChanges();
            return usuarios;

        }
        public UsuariosModel Atualizar(UsuariosModel usuarios)
        {
            UsuariosModel usuariosDB = ListarPorId(usuarios.Id);
            if (usuariosDB == null) throw new System.Exception("Houve um erro ao editar o contato");

            usuariosDB.Nome = usuarios.Nome;
            usuariosDB.Login = usuarios.Login;
            usuariosDB.Email = usuarios.Email;
            usuariosDB.Perfil = usuarios.Perfil;
            usuariosDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Update(usuariosDB);
            _bancoContext.SaveChanges();

            return usuariosDB;
        }

        public bool Apagar(int id)
        {
            UsuariosModel usuariosDB = ListarPorId(id);

            if (usuariosDB == null) throw new System.Exception("Houve um erro ao deletar o usuário");

            _bancoContext.Usuarios.Remove(usuariosDB);
            _bancoContext.SaveChanges();

            return true;
        }

        public UsuariosModel ListarPorLogin(string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }

        public UsuariosModel ListarPorEmailELogin(string email, string login)
        {
            return _bancoContext.Usuarios.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Login.ToUpper() == login.ToUpper());
        }

        public UsuariosModel AlterarSenha(AlterarSenhaModel alterarSenhaModel)
        {
            UsuariosModel usuariosDB = ListarPorId(alterarSenhaModel.Id);

            if (usuariosDB == null) throw new Exception("Houve um erro ao alterar a senha");

            if(!usuariosDB.SenhaValida(alterarSenhaModel.SenhaAtual)) throw new Exception("A senha atual está incorreta, tente novamente");

            if (usuariosDB.SenhaValida(alterarSenhaModel.NovaSenha)) throw new Exception("A senha atual é a mesma da nova senha, insira uma senha diferente");

            usuariosDB.NovaSenhaAlterada(alterarSenhaModel.NovaSenha);
            usuariosDB.DataAtualizacao = DateTime.Now;

            _bancoContext.Usuarios.Update(usuariosDB);
            _bancoContext.SaveChanges();

            return usuariosDB;
        }
    }   
}
