using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace negocio.Repositorio.Repositorio.Generico
{
    public interface IRepositorio<T> where T : class
    {
        /// <summary>
        ///     Atualiza uma entidade no repositório de dados
        /// </summary>
        /// <param name="entity">Entidade a ser atualizada</param>
        string Update(T entity);

        /// <summary>
        ///     Deleta uma entidade do repositório de dados
        /// </summary>
        /// <param name="entity">Entidade a ser deletada</param>
        string Delete(T entity);

        /// <summary>
        ///     Adiciona uma nova entidade ao repositório de dados
        /// </summary>
        /// <param name="entity">Entidade a ser adicionada</param>
        string Create(T entity);


        /// <summary>
        ///     Obtém um IQueryable de todas as entidades do repositório
        /// </summary>
        /// <returns>Um objeto IQueryable tipado para a entidade</returns>
        IQueryable<T> GetAll();

        /// <summary>
        ///     Obtém uma lista de entidades a partir de uma expressão lambda
        /// </summary>
        /// <param name="where">Expressão lambda reprensentando a cláusula where</param>
        /// <returns>um Enumerable tipado para a entidade</returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> where);

        /// <summary>
        ///     Obtém uma lista de entidades a partir de uma expressão lambda
        /// </summary>
        /// <param name="where">Expressão lambda reprensentando a cláusula where</param>
        /// <returns>um Enumerable tipado para a entidade</returns>
        T FindId(Expression<Func<T, bool>> where);

        List<T> FindList(Expression<Func<T, bool>> where);
        List<T> GetAllList();
    }
}