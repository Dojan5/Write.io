using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Write.io.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BlogHeaderURL { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public string Template { get; set; } = "default";
        public virtual ApplicationUser User {get; set; }
        public virtual ICollection<Post> Posts {get; set; }
    }
    public class BlogViewModel
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ApplicationUser User { get; set; }
        public Blog Blog { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();

        public void Populate(int BlogID)
        {
            this.Blog = db.Blogs.Where(b => b.Id == BlogID).Select(b => b).FirstOrDefault();
            this.User = this.Blog.User;
            this.Posts = db.Posts.Where(p => p.BlogId == BlogID).Select(b => b).ToList();
        }
    }
    public class BlogPostViewModel
    {
        public ApplicationUser User { get; set; }
        public Blog Blog { get; set; }
        public Post Post { get; set; }
    }
}