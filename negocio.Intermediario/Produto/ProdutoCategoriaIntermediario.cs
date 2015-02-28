using System;
using System.Collections.Generic;
using negocio.Dominio;
using negocio.Repositorio.Repositorio.Generico;

namespace negocio.Intermediario.Produto
{
    public class ProdutoCategoriaIntermediario : ICrud<ProdutoCategoriaDTO>
    {
        private readonly Repositorio<ProdutoCategoriaDTO> repositorio;

        public ProdutoCategoriaIntermediario()
        {
            repositorio = new Repositorio<ProdutoCategoriaDTO>();
        }

        public ProdutoCategoriaDTO ConsultaId(long id)
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

        public IEnumerable<ProdutoCategoriaDTO> ListarTodos()
        {
            try
            {
                return repositorio.GetAllList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Deletar(ProdutoCategoriaDTO objeto)
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

        public string Alterar(ProdutoCategoriaDTO objeto)
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

        public string Criar(ProdutoCategoriaDTO objeto)
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