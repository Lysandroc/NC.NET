using System.Collections.Generic;

namespace negocio.Intermediario
{
    public interface ICrud<T> where T : class
    {
        //Operações padrões para todas as classes que utilizando CRUD básico
        T ConsultaId(long id);
        IEnumerable<T> ListarTodos();
        string Deletar(T objeto);
        string Alterar(T objeto);
        string Criar(T objeto);
    }
}