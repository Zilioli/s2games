using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace s2Games.Models
{
    public class emprestimo
    {
        [Key, Column(Order=0)]
        public int codigoAmigo { get; set; }
        [Key, Column(Order = 1)]
        public int codigoGame{get;set;}

        public amigo amigo { get; set; }
        public virtual game game { get; set; }

        public DateTime dataEmprestimo { get; set; }
        public DateTime? dataDevolucao { get; set; }
    }
}