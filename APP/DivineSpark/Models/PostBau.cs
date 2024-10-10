using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class PostBau
    {
        public int Id { get; set; }

        [ForeignKey("PostPocao")]
        public int PocaoId { get; set; }
        public PostPocao Pocao { get; set; }

        [ForeignKey("PostArma")]
        public int ArmaId { get; set; }
        public PostArma Arma { get; set; }
    }
}
