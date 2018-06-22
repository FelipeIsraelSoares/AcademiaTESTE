using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Academia_Teste.Models
{
    public class PlanoExercicioContext : DbContext
    {
        public DbSet<PlanoExercicio> PlanoExercicio { get; set; }
    }
}