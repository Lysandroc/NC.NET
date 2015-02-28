using System;
using System.Collections.Generic;
using negocio.Dominio;
using negocio.Repositorio.Repositorio.Generico;

namespace negocio.Intermediario.Cliente
{
    public class ClienteIntermediario : ICrud<ClienteDTO>
    {
        private readonly Repositorio<ClienteDTO> repositorio;

        public ClienteIntermediario()
        {
            repositorio = new Repositorio<ClienteDTO>();
        }

        public ClienteDTO ConsultaId(long id)
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

        public IEnumerable<ClienteDTO> ListarTodos()
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

        public string Deletar(ClienteDTO objeto)
        {
            try
            {
                return repositorio.Delete(objeto);
                ;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string Alterar(ClienteDTO objeto)
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

        public string Criar(ClienteDTO objeto)
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