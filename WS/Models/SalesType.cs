using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WS.Models
{
    public class SalesType
    {
        public int id { get; set; }
        public string sales_type { get; set; }
        public int tax_included { get; set; }
        public double factor { get; set; }
        public int inactive { get; set; }
        
    }
}