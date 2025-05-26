using System;

namespace ProjetoLoja;

public class RepositorioUsuario
{
    public Usuario[] TodosUsuarios = new Usuario[1];
    private int idUsuario = 1;
    //achei melhor criar uma variavel separada para o ID para não dar confusão quando um usuário for excluído, a sequencia se manter correta ja que se não ela depende do tamanho do vetor

    public RepositorioUsuario()
    {
        TodosUsuarios[0] = new Usuario("AdminMaster", "Admin", 0, idUsuario++);
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
                        break;
                    }

                    else
                    {
                        retorno = 1;
                        break;
                    }
                }
                else
                {
                    retorno = 3;
                    break;
                }
            }
            else
            {
                retorno = 2;
                break;
            }
        }
        return retorno;
    }

    public void CriarUsuario(String nome, String senha)
    {
        Usuario[] novosUsuarios = new Usuario[TodosUsuarios.Length + 1];

        for (int i = 0; i < TodosUsuarios.Length; i++)
        {
            novosUsuarios[i] = TodosUsuarios[i];
        }

        novosUsuarios[novosUsuarios.Length - 1] = new Usuario(nome, senha, 1, idUsuario++); //sempre adicionando novos usuários com direitos de usuário comum, 
                                                                                     // depois um outro admin pode editar o usuario pra torna-lo admin
        TodosUsuarios = novosUsuarios;
    }

    public void ListarUsuarios()
    {
        int i;
        Console.WriteLine("Usuarios cadastrados:");
        for (i = 0; i < TodosUsuarios.Length; i++)
        {
            if (TodosUsuarios[i].DireitosDeUsuario == 0)
            {
                Console.Write("*Administrador | "); //para os admins saberem quem são os outros admins
            }
            Console.WriteLine("Usuário ID " + TodosUsuarios[i].ID + " | Nome: " + TodosUsuarios[i].Nome);
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }
}
