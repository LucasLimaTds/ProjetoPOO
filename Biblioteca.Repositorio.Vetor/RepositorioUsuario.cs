using System;

namespace ProjetoLoja;

public class RepositorioUsuario
{
    private Usuario[] TodosUsuarios = new Usuario[1];
    private int idUsuario = 1;

    public RepositorioUsuario()
    {
        TodosUsuarios[0] = new Usuario("AdminMaster", "adminmaster@ucs.br", "Admin", 0, idUsuario++);
        // admin não possui endereço instanciado. Pode ocorrrer excessão na escrita do endereço
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

    public bool VerificaEmailExistente(string email)
    {
        for (int i = 0; i < TodosUsuarios.Length; i++)
        {
            if (email == TodosUsuarios[i].Email)
            {
                return false;
            }
        }
        return true;
    }

    public void CriarUsuario(Usuario NovoUsuario)
    {
        Usuario[] novosUsuarios = new Usuario[TodosUsuarios.Length + 1];

        for (int i = 0; i < TodosUsuarios.Length; i++)
        {
            novosUsuarios[i] = TodosUsuarios[i];
        }

        NovoUsuario.ID = idUsuario++;

        novosUsuarios[novosUsuarios.Length - 1] = NovoUsuario;  
                                                                                                                                                                    
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
                Console.Write("*Administrador | ");
            }
            Console.WriteLine($"Usuário ID: {TodosUsuarios[i].ID} | Nome: {TodosUsuarios[i].Nome} | Email: {TodosUsuarios[i].Email} | Telefone: {TodosUsuarios[i].Telefone}");
            TodosUsuarios[i].EnderecoDoUsuario.ListarEndereço();
            // TodosUsuarios[i].EnderecoDoUsuario.ToString();
        }

        Console.WriteLine("-------------------------------------------------------------------");
    }
}
