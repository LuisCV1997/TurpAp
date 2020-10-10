using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class ClienteController : ApiController
    {
        [Route("api/Cliente/GetAll")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var result = BL.Cliente.GetAll();
            return Ok(result);
        }
        [Route("api/Cliente/GetById/{Id}")]
        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var result = BL.Cliente.GEtById2(id);
            return Ok(result);
        }
        [Route("api/Cliente/")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ML.Cliente cliente)
        {
            var result = BL.Cliente.Add(cliente);
            return Ok(result);
        }
        [Route("api/Cliente/Update")]
        [HttpPost]
        public IHttpActionResult Update([FromBody]ML.Cliente cliente)
        {
            var result = BL.Cliente.Update(cliente);
            return Ok(result);
        }
        [Route("api/Cliente/Delete/{id}")]
        [HttpGet]
        public IHttpActionResult Delete (int id)
            {
            var result = BL.Cliente.Delete(id);
            return Ok(result);
        }
    }
}
