using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Entity
{
    class FeedBackDataContext : DbContext
    {
        public FeedBackDataContext() 
            : base("DbFeedBack") 
        { }

        public DbSet<Feedback> Feedbacks { get; set; }
    }
}
