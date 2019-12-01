using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WS.Models;

namespace FinalIntegracion.Models
{
    public class FinalIntegracionContext : DbContext
    {
        public FinalIntegracionContext (DbContextOptions<FinalIntegracionContext> options)
            : base(options)
        {
        }

        public DbSet<WS.Models.SalesType> SalesType { get; set; }
    }
}
