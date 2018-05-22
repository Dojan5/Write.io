namespace Write.io.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Write.io.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Write.io.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Write.io.Models.ApplicationDbContext context)
        {
            //Seeds a user to the database
            if (!context.Users.Any(u => u.Email == "rytlock_brimstone@pact.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);

                var U1 = new ApplicationUser
                {
                    FirstName = "Rytlock",
                    LastName = "Brimstone",
                    Email = "rytlock_brimstone@pact.com",
                    UserName = "rytlock_brimstone@pact.com",
                    Nickname = "Tribune"
                };
                var U2 = new ApplicationUser
                {
                    FirstName = "Taimi",
                    LastName = "Genius",
                    Email = "taimi_and_scruffy@rata.nov",
                    UserName = "taimi_and_scruffy@rata.nov",
                    Nickname = "Taimi"
                };
                var U3 = new ApplicationUser
                {
                    FirstName = "Logan",
                    LastName = "Thackeray",
                    Email = "logan_thackeray@divinitysreach.net",
                    UserName = "logan_thackeray@divinitysreach.net",
                    Nickname = "Seraph Thackeray"
                };

                manager.Create(U1, "P@ssword1");
                manager.Create(U2, "P@ssword1");
                manager.Create(U3, "P@ssword1");
            }


           
            //Seeds a blog
            var Blog1 = new Blog
            {
                Id = 1,
                Title = "Tribune's Notes",
                BlogHeaderURL = "https://i.imgur.com/B1VNyDb.jpg",
                Body = "A place where I log events that have happened throughout my years as a tribune. There may also be the occasional rant in here. Stay away, Thackeray.",
                Created = DateTime.Now,
                User = context.Users.SingleOrDefault(u => u.Email == "rytlock_brimstone@pact.com")                
            };
            var Blog2 = new Blog
            {
                Id = 2,
                Title = "Tales from the Lab",
                BlogHeaderURL = "https://i.imgur.com/CqiOnT7.jpg",
                Body = "In my research into the dragons I stumble upon all kinds of fascinating discoveries. In this blog I will regale you with stories I've amassed when working in the lab here in Rata Novus.",
                Created = DateTime.Now,
                User = context.Users.SingleOrDefault(u => u.Email == "taimi_and_scruffy@rata.nov")
            };
            context.Blogs.AddOrUpdate(b => b.Id, Blog1, Blog2);
            //Seeds posts for the blogs
            var Post1 = new Post
            {
                Id = 1,
                Title = "Falling!",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus rhoncus tortor sed orci placerat, a lacinia metus sodales. Proin ac tempus quam. Etiam nibh mi, malesuada a blandit vel, lobortis in nisl. Phasellus non mauris sem. Vestibulum nec justo et nisi molestie porta vitae ac nulla. Pellentesque felis justo, laoreet in rhoncus vitae, consequat a nisi. Sed arcu nisi, interdum nec finibus non, iaculis in ligula. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nullam mattis purus magna, sed accumsan turpis finibus vel.",
                Created = DateTime.Now,
                BlogId = 1,
            };
            var Post2 = new Post
            {
                Id = 2,
                Title = "Betrayed!",
                Body = "Vestibulum nec tellus et augue luctus aliquam. Nulla facilisi. Etiam semper metus sed tortor aliquet placerat. Cras est arcu, egestas vitae justo cursus, tincidunt porta nunc. Mauris placerat lobortis nulla ut venenatis. Aenean iaculis neque commodo, efficitur libero non, bibendum arcu. Cras tellus enim, molestie ut condimentum vitae, vehicula ac tellus. Integer eu quam quam. Quisque sed arcu odio. Etiam sed lorem et enim tincidunt tempor. Vivamus faucibus interdum elit sollicitudin tempor.",
                Created = DateTime.Now,
                BlogId = 1
            };
            var Post3 = new Post
            {
                Id = 3,
                Title = "AMAZING discovery",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus rhoncus tortor sed orci placerat, a lacinia metus sodales. Proin ac tempus quam. Etiam nibh mi, malesuada a blandit vel, lobortis in nisl. Phasellus non mauris sem. Vestibulum nec justo et nisi molestie porta vitae ac nulla. Pellentesque felis justo, laoreet in rhoncus vitae, consequat a nisi. Sed arcu nisi, interdum nec finibus non, iaculis in ligula. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nullam mattis purus magna, sed accumsan turpis finibus vel.",
                Created = DateTime.Now,
                BlogId = 2
            };
            var Post4 = new Post
            {
                Id = 4,
                Title = "Thorough report on Spencer",
                Body = "Vestibulum nec tellus et augue luctus aliquam. Nulla facilisi. Etiam semper metus sed tortor aliquet placerat. Cras est arcu, egestas vitae justo cursus, tincidunt porta nunc. Mauris placerat lobortis nulla ut venenatis. Aenean iaculis neque commodo, efficitur libero non, bibendum arcu. Cras tellus enim, molestie ut condimentum vitae, vehicula ac tellus. Integer eu quam quam. Quisque sed arcu odio. Etiam sed lorem et enim tincidunt tempor. Vivamus faucibus interdum elit sollicitudin tempor.",
                Created = DateTime.Now,
                BlogId = 2
            };
            context.Posts.AddOrUpdate(p => p.Id, Post1, Post2, Post3, Post4);
        }
    }
}
