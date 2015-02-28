using System;
using System.Collections.Generic;
using negocio.Dominio;
using negocio.Repositorio.Repositorio.Generico;

namespace negocio.Intermediario.Produto
{
    public class ProdutoIntermediario : ICrud<ProdutoDTO>
    {
        private readonly Repositorio<ProdutoDTO> repositorio;

        public ProdutoIntermediario()
        {
            try
            {
                repositorio = new Repositorio<ProdutoDTO>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ProdutoDTO ConsultaId(long id)
        {
            try
            {
                return repositorio.FindId(x => x.Id == id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<ProdutoDTO> ListarTodos()
        {
            try
            {
                return repositorio.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Deletar(ProdutoDTO objeto)
        {
            try
            {
                return repositorio.Delete(objeto);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(ProdutoDTO objeto)
        {
            try
            {
                return repositorio.Update(objeto);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Criar(ProdutoDTO objeto)
        {
            try
            {
                return repositorio.Create(objeto);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}