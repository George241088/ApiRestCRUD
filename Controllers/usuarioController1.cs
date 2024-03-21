using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi2.DATA;
using WebApi2.Models;

namespace WebApi2.Controllers
{
    public class usuarioController : ApiController
    {
        ////// GET api/<controller>
        ////public IEnumerable<string> Get()
        ////{
        ////    return new string[] { "value1", "value2" };
        ////}

        ////// GET api/<controller>/5
        ////public string Get(int id)
        ////{
        ////    return "value";
        ////}

        ////// POST api/<controller>
        ////public void Post([FromBody] string value)
        ////{
        ////}

        ////// PUT api/<controller>/5
        ////public void Put(int id, [FromBody] string value)
        ////{
        ////}

        ////// DELETE api/<controller>/5
        ////public void Delete(int id)
        ////{
        ////}
        ///

        //GET api/
        public List<usuario> Get()
        {
            return usuarioData.Listar();
        }

        public usuario Get(int id)
        {
            return usuarioData.obtener(id);
        }

        public bool Post([FromBody] usuario oUsuario)
        {
            return usuarioData.Registrar(oUsuario);
        }

        public bool Put([FromBody] usuario oUsuario)
        {
            return usuarioData.Modificar(oUsuario);
        }

        public bool Delete (int id)
        {
            return usuarioData.eliminar(id);
        }
    }
}