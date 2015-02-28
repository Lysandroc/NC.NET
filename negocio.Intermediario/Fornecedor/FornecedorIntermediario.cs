using System;
using System.Collections.Generic;
using negocio.Dominio;
using negocio.Repositorio.Repositorio.Generico;

namespace negocio.Intermediario.Fornecedor
{
    public class FornecedorIntermediario : ICrud<FornecedorDTO>
    {
        private readonly Repositorio<FornecedorDTO> repositorio;

        public FornecedorIntermediario()
        {
            repositorio = new Repositorio<FornecedorDTO>();
        }

        public FornecedorDTO ConsultaId(long id)
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

        public IEnumerable<FornecedorDTO> ListarTodos()
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

        public string Criar(FornecedorDTO objeto)
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

        public string Deletar(FornecedorDTO objeto)
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

        public string Alterar(FornecedorDTO objeto)
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
    }
}