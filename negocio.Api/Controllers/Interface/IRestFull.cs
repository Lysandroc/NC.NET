using System.Net.Http;
using System.Web.Http;

namespace negocio.Api.Controllers.Interface
{
    public interface IRestFull<T> where T : class
    {
        [HttpGet]
        HttpResponseMessage Get(int id);

        [HttpGet]
        HttpResponseMessage GetAll();

        [HttpPost]
        HttpResponseMessage Post(T objeto);

        [HttpPut]
        HttpResponseMessage Put(T objeto);

        [HttpDelete]
        HttpResponseMessage Delete(int id);
    }
}