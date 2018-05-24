using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Write.io.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string body { get; set; }
        public DateTime created { get; set; }

        public virtual ApplicationUser User {get; set; }
        public virtual Post Post {get; set; }
      
    }
}