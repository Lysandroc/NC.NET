using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using negocio.Api.Controllers.Interface;
using negocio.Dominio;
using negocio.Intermediario;
using negocio.Intermediario.Fornecedor;
using Ninject;

namespace negocio.Api.Controllers
{
    //http://localhost:51823/servico/Fornecedor/1

    [RoutePrefix("Servico")]
    public class FornecedorController : ApiController, IRestFull<FornecedorDTO> 
    {
        private FornecedorIntermediario _fornecedorIntermediario;

        [Inject]
        public ICrud<FornecedorDTO> intermediarioFornecedor { get; set; }

        [HttpGet, Route("Fornecedor/{id}")]
        public HttpResponseMessage Get(int id)
        {
            _fornecedorIntermediario = new FornecedorIntermediario();
            var fornecedor = _fornecedorIntermediario.ConsultaId(id);
            if (fornecedor == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, id);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, fornecedor);
            }
        }

        [Route("Fornecedor")]
        public HttpResponseMessage GetAll()
        {
            _fornecedorIntermediario = new FornecedorIntermediario();
            var fornecedores = _fornecedorIntermediario.ListarTodos();

            if (fornecedores == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, fornecedores);
            }
        }

        [Route("Fornecedor")]
        public HttpResponseMessage Put(FornecedorDTO objeto)
        {
            _fornecedorIntermediario = new FornecedorIntermediario();
            if (objeto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Objeto vazio!");
            }
            else
            {
                var erro = _fornecedorIntermediario.Alterar(objeto);
                if (!String.IsNullOrEmpty(erro))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
                else
                    return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        [Route("Fornecedor"),HttpPost]
        public HttpResponseMessage Post(FornecedorDTO objeto)
        {
            _fornecedorIntermediario = new FornecedorIntermediario();
            if (objeto == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Objeto vazio!");
            }
            else
            {
                var erro = _fornecedorIntermediario.Criar(objeto);
                if (!String.IsNullOrEmpty(erro))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
                else
                    return Request.CreateResponse(HttpStatusCode.Created);
            }
        }

        [Route("Fornecedor/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            _fornecedorIntermediario = new FornecedorIntermediario();
            if (id <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Objeto vazio!");
            }
            else
            {
                var objeto = _fornecedorIntermediario.ConsultaId(id);
                var erro = _fornecedorIntermediario.Deletar(objeto);
                if (!String.IsNullOrEmpty(erro))
                    return Request.CreateResponse(HttpStatusCode.BadRequest, erro);
                else
                    return Request.CreateResponse(HttpStatusCode.OK);
            }
        }
    }
}