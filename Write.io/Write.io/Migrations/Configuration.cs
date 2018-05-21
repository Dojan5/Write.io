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
                    LastName = "Brimstome",
                    Email = "rytlock_brimstone@pact.com",
                    UserName = "rytlock_brimstone@pact.com"
                };
                var U2 = new ApplicationUser
                {
                    FirstName = "Taimi",
                    LastName = "Genius",
                    Email = "go_away@labs.com",
                    UserName = "go_away@labs.com"
                };

                manager.Create(U1, "P@ssword1");
                manager.Create(U2, "P@ssword1");
            }


           
            //Seeds a blog
            var Blog1 = new Blog
            {
                Id = 1,
                Title = "Adventures in the Mists",
                BlogHeaderURL = "https://i.imgur.com/B1VNyDb.jpg",
                Body = "Things I experienced during my travels in the mists.",
                Created = DateTime.Now,
                User = context.Users.SingleOrDefault(u => u.Email == "rytlock_brimstone@pact.com")                
            };
            context.Blogs.AddOrUpdate(b => b.Id, Blog1);
            //Seeds posts for the blog
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
            context.Posts.AddOrUpdate(p => p.Id, Post1, Post2);
        }
    }
}
