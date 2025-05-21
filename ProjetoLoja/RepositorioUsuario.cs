using System;

namespace ProjetoLoja;

public class RepositorioUsuario
{
    public Usuario[] TodosUsuarios = new Usuario[1];

    public RepositorioUsuario()
    {
        TodosUsuarios[0] = new Usuario("AdminMaster", "Admin", 0, 1);
    }
}
