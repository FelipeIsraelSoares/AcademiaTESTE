using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Academia_Teste.Models
{
    public class PlanoExe
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdProfessor { get; set; }
        [Required]
        public int IdModalidade { get; set; }
    }
}