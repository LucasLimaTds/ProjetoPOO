using System;

namespace ProjetoLoja;

public class RepositorioUsuario
{
    public Usuario[] TodosUsuarios = new Usuario[1];

    public RepositorioUsuario()
    {
        TodosUsuarios[0] = new Usuario("AdminMaster", "Admin", 0, 1);
    }

    public int ValidarUsuario(String nome, String senha)
    {
        int retorno = 0;

        for (int i = 0; i < TodosUsuarios.Length; i++)
        {
            if (nome == TodosUsuarios[i].Nome)
            {
                if (senha == TodosUsuarios[i].Senha)
                {
                    if (TodosUsuarios[i].DireitosDeUsuario == 0)
                    {
                        retorno = 0;
                    }

                    else
                    {
                        retorno = 1;
                    }
                }

                else
                {
                    retorno = 3;
                }
            }

            else
            {
                retorno = 2;
            }
        }
        return retorno;
    }

    public void CriarUsuario(String nome, String senha)
    {
        int novoId = TodosUsuarios.Length + 1;

        Usuario[] novosUsuarios = new Usuario[TodosUsuarios.Length + 1];

        for (int i = 0; i < TodosUsuarios.Length; i++)
        {
            novosUsuarios[i] = TodosUsuarios[i];
        }

        novosUsuarios[novosUsuarios.Length - 1] = new Usuario(nome, senha, 1, novoId); //sempre adicionando novos usuários com direitos de usuário comum, 
                                                                                       // depois um outro admin pode editar o usuario pra torna-lo admin
        TodosUsuarios = novosUsuarios;
    }

    public void ListarUsuarios()
    {
        int i;
        Console.WriteLine("Usuarios cadastrados:");
        for (i=0; i<TodosUsuarios.Length; i++)
        {
            Console.WriteLine(TodosUsuarios[i].Nome);
        }
    }
}
