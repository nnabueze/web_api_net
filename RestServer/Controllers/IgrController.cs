using Newtonsoft.Json;
using RestServer.Models;
using RestServer.Models.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;

namespace RestServer.Controllers
{
    public class IgrController : ApiController
    {
        // GET: api/Igr
        [HttpGet]
        public ArrayList GetIgr()
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
        [HttpPost]
        public Object PostIgr(HttpRequestMessage request)
        {
                   var doc = new XmlDocument();
                    doc.Load(request.Content.ReadAsStreamAsync().Result);

                    var obj = JsonConvert.SerializeXmlNode(doc);           
                    return JsonConvert.DeserializeObject(obj);
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
