using RestServer.Models;
using RestServer.Models.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RestServer.Controllers
{
    public class IgrController : ApiController
    {
        // GET: api/Igr
        public ArrayList Get()
        {
            IgrRepository pp = new IgrRepository();
            return pp.GetIgrs();
        }

        // GET: api/Igr/5
        public Igr Get(int id)
        {
            IgrRepository pp = new IgrRepository();
            Igr p = pp.getIgr(id);

            return p;
        }

        // POST: api/Igr
        public HttpResponseMessage Post([FromBody]Igr value)
        {
            IgrRepository pp = new IgrRepository();
            long id = pp.saveIgr(value);

            HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.Created,"craeted");
            return reponse;
        }

        // PUT: api/Igr/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Igr/5
        public void Delete(int id)
        {
        }
    }
}
