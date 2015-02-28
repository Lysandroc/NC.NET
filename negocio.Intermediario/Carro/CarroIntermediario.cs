using System;
using System.Collections.Generic;
using negocio.Dominio;
using negocio.Repositorio.Repositorio.Generico;

namespace negocio.Intermediario.Carro
{
    public class CarroIntermediario : ICrud<CarroDTO>
    {
        private readonly Repositorio<CarroDTO> repositorio;

        public CarroIntermediario()
        {
            repositorio = new Repositorio<CarroDTO>();
        }

        public CarroDTO ConsultaId(long id)
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

        public IEnumerable<CarroDTO> ListarTodos()
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

        public string Deletar(CarroDTO objeto)
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

        public string Alterar(CarroDTO objeto)
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

        public string Criar(CarroDTO objeto)
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