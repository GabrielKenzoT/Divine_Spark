using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivineSpark.Models
{
    public class PostSala
    {
        public int Id { get; set; }
        
        [ForeignKey("PostMonstro")]
        public int Monstro_id { get; set; }
        public PostMonstro PostMonstro { get; set; }

        [ForeignKey("PostBau")]
        public int Bau_id { get; set; }
        public PostBau PostBau { get; set; }
    }
}
