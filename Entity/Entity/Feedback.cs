using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    [TableAttribute("Feedback")]
    public class Feedback
    {
        public Feedback()
        { this.Id = 10; }
        public int Id { get; set; }
        public string Author { get; set; }
        public DateTime DateAdd { get; set; }
        
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
