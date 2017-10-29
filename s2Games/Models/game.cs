using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace s2Games.Models
{
    public class game
    {
        [Key]
        [JsonProperty(PropertyName = "codigo")]
        public int codigo { get; set; }
        [MaxLength(100)]
        [JsonProperty(PropertyName = "nome")]
        public string nome { get; set; }
        [JsonProperty(PropertyName = "avaliacao")]
        public int avaliacao { get; set; }
        

        public DateTime? dataExclusao { get; set; }

        public virtual ICollection<emprestimo> emprestimos { get; set; }

        public static implicit operator game(string v)
        {
            throw new NotImplementedException();
        }
    }
}