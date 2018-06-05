using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

        public static String CreateOrUpdate(Post BlogPost, string Tags, int? PostID = null)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            //Pulls a post from the database
            var Post = db.Posts.SingleOrDefault(p => p.Id == PostID);
            //Creates an array of strings by splitting the tags string. Instantiates a list of a tag object for adding to the post
            var TagArray = Tags.Split(',');
            List<Tag> PostTags = new List<Tag>();
            foreach (var item in TagArray)
            {
                item.TrimStart(' ');
                Tag Tag = new Tag()
                {
                    Name = item
                };
                PostTags.Add(Tag);
            }
            //If the post exists, it will update the post with the new data, else it will create a new post.
            if (Post != null)
            {
                Post.Title = BlogPost.Title;
                Post.Body = BlogPost.Body;
                Post.Tags = PostTags;
                db.Entry(Post).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Post has been updated.";
            }
            else
            {
                BlogPost.Tags = PostTags;
                BlogPost.Created = DateTime.Now;
                db.Posts.Add(BlogPost);
                db.SaveChanges();
                return "Post has been created.";
            }
        }
    }

    public class PostViewModel
    {
        public Post Post { get; set; } = new Post();
        public Comment Comment { get; set; } = new Comment();
    }

    public class CreatePostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
        public string Tags { get; set; }
    }
}