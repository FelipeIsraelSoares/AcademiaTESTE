using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Academia_Teste.Models
{
    public class PlanoExeContext : DbContext
    {
        public DbSet<PlanoExe> Modalidade { get; set; }
    }
}