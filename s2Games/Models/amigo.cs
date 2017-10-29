using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace s2Games.Models
{
    public class amigo
    {
        [Key]
        public int codigo { get; set; }
        [MaxLength(100)]
        public string nome { get; set; }
        public DateTime? dataExclusao { get; set; }
        public virtual ICollection<emprestimo> emprestimos { get; set; }
    }
}