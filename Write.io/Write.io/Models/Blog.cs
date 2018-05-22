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

        public bool Populate(string Nickname, string BlogTitle)
        {
            if (db.Blogs.Any(b => b.Title == BlogTitle) && db.Users.Any(u => u.Nickname == Nickname))
            {
                this.Blog = db.Blogs.Where(b => b.User.Nickname == Nickname && b.Title == BlogTitle).Select(b => b).FirstOrDefault();
                this.Posts = db.Posts.Where(p => p.BlogId == this.Blog.Id).Select(p => p).ToList();
                this.User = this.Blog.User;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class BlogPostViewModel
    {
        public ApplicationUser User { get; set; }
        public Blog Blog { get; set; }
        public Post Post { get; set; }
    }
}