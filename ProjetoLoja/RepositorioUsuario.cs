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
        int retorno=0;

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
        // Implementar a criacao do usuario   
    }
}
