using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServer.Models
{
    public class Igr
    {
        public int Id { get; set; }
        public string Igr_Key { get; set; }
        public string State_name { get; set; }
        public string Igr_code { get; set; }
        public string Igr_abbre { get; set; }
        public string Logo { get; set; }
        public DateTime created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}