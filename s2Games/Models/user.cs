using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace s2Games.Models
{
    public class user
    {
        [Key]
        public int codigo { get; set; }
        [MaxLength(100)]
        public string nome { get; set; }
        [MaxLength(10), MinLength(5)]
        [Required(ErrorMessage = "Login é Obrigatório")]
        public string login { get; set; }
        [MaxLength(150)]
        [Required(ErrorMessage = "Senha é obrigatório")]
        public string senha { get; set; }
    }
}