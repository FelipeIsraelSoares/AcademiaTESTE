using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Academia_Teste.Models
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext():base("Usuarios")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}