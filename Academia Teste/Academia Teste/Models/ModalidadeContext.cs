using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Academia_Teste.Models
{
    public class ModalidadeContext : DbContext
    {
        public DbSet<Modalidade> Modalidade { get; set; }
    }
}