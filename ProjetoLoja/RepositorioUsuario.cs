using System;

namespace ProjetoLoja;

public class RepositorioUsuario
{
    public Usuario[] TodosUsuarios = new Usuario[1];
    private int idUsuario = 1;
    //achei melhor criar uma variavel separada para o ID para não dar confusão quando um usuário for excluído, a sequencia se manter correta ja que se não ela depende do tamanho do vetor

    public RepositorioUsuario()
    {
        TodosUsuarios[0] = new Usuario("AdminMaster", "adminmaster@ucs.br", "Admin", 0, idUsuario++);
    }

    public int ValidarUsuario(string email, string senha)
    {
        for (int i = 0; i < TodosUsuarios.Length; i++)
        {
            if (email == TodosUsuarios[i].Email)
            {
                if (senha == TodosUsuarios[i].Senha)
                {
                    return TodosUsuarios[i].DireitosDeUsuario;
                }
                else
                {
                    return -1;
                }
            }
        }
        return -1;
    }

    public void CriarUsuario(string nome, string email, string senha, string rua, string numero, string complemento, string bairro, string CEP, string cidade, string estado)
    {
        Usuario[] novosUsuarios = new Usuario[TodosUsuarios.Length + 1];

        for (int i = 0; i < TodosUsuarios.Length; i++)
        {
            novosUsuarios[i] = TodosUsuarios[i];
        }

        novosUsuarios[novosUsuarios.Length - 1] = new Usuario(nome, email, senha, 1, idUsuario++, rua, numero, complemento, bairro, CEP, cidade, estado); //sempre adicionando novos usuários com direitos de usuário comum, 
                                                                                     // depois um outro admin pode editar o usuario pra torna-lo admin
        TodosUsuarios = novosUsuarios;
    }

    public void ListarUsuarios()
    {
        int i;
        Console.WriteLine("\nUsuarios cadastrados:");
        for (i = 0; i < TodosUsuarios.Length; i++)
        {
            if (TodosUsuarios[i].DireitosDeUsuario == 0)
            {
                Console.Write("*Administrador | "); //para os admins saberem quem são os outros admins
            }
            Console.WriteLine($"Usuário ID: {TodosUsuarios[i].ID} | Nome: {TodosUsuarios[i].Nome} | Email: {TodosUsuarios[i].Email}");
            TodosUsuarios[i].ListarEndereço();  // APENAS PARA TESTAR OS ENDEREÇOS. REMOVER NA VERSÃO FINAL
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }
}
