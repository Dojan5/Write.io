using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Write.io.Models
{
    public class Post
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public int Views { get; set; }
        public virtual Blog Blog { get; set; }
        public virtual ICollection<Comment> Comments {get; set; }
        public virtual ICollection<Tag> Tags {get; set; }
    }
}