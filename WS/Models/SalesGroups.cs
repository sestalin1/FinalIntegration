using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WS.Models
{
    public class SalesGroups
    {
        
        public int id { get; set; }
        public string description { get; set; }
        public bool inactive { get; set; }

    }
}