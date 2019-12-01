using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS.Models
{
    public class DimensionTag
    {
        public int id { get; set; }
        public int type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int inactive { get; set; }
    }
}