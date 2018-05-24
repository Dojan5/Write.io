namespace Write.io.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
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
                    Nickname = "Tribune Brimstone",
                    AvatarURL = "https://i.imgur.com/kTQ0SZd.jpg"
                };
                var U2 = new ApplicationUser
                {
                    FirstName = "Taimi",
                    LastName = "The Genius",
                    Email = "taimi_and_scruffy@rata.nov",
                    UserName = "taimi_and_scruffy@rata.nov",
                    Nickname = "Taimi",
                    AvatarURL = "https://i.imgur.com/htRaUlg.jpg"
                };
                var U3 = new ApplicationUser
                {
                    FirstName = "Logan",
                    LastName = "Thackeray",
                    Email = "logan_thackeray@divinitysreach.net",
                    UserName = "logan_thackeray@divinitysreach.net",
                    Nickname = "Seraph Thackeray"
                };
                var U4 = new ApplicationUser
                {
                    FirstName = "Marjory",
                    LastName = "Delaqua",
                    Email = "marjory_delaqua@divinitysreach.net",
                    UserName = "marjory_delaqua@divinitysreach.net",
                    Nickname = "M. Delaqua",
                    AvatarURL = "https://i.imgur.com/kUrxCql.jpg"
                };
                var U5 = new ApplicationUser
                {
                    FirstName = "Canach",
                    LastName = "Secondborn",
                    Email = "canach@thegrove.net",
                    UserName = "canach@thegrove.net",
                    Nickname = "Canach",
                    AvatarURL = "https://i.imgur.com/sftoXEO.jpg"
                };

                manager.Create(U1, "P@ssword1");
                manager.Create(U2, "P@ssword1");
                manager.Create(U3, "P@ssword1");
                manager.Create(U4, "P@ssword1");
                manager.Create(U5, "P@ssword1");
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
                Title = "Into the mists",
                Body = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus rhoncus tortor sed orci placerat, a lacinia metus sodales. Proin ac tempus quam. Etiam nibh mi, malesuada a blandit vel, lobortis in nisl. Phasellus non mauris sem. Vestibulum nec justo et nisi molestie porta vitae ac nulla. Pellentesque felis justo, laoreet in rhoncus vitae, consequat a nisi. Sed arcu nisi, interdum nec finibus non, iaculis in ligula. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Nullam mattis purus magna, sed accumsan turpis finibus vel.",
                Created = DateTime.Now,
                BlogId = 1
            };
            var Post2 = new Post
            {
                Id = 2,
                Title = "Encounter with the betrayer",
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
            context.SaveChanges();

            var Com1 = new Comment
            {
                Id = 1,
                Post = context.Posts.SingleOrDefault(p => p.Title == "AMAZING discovery"),
                User = context.Users.SingleOrDefault(u => u.Email == "rytlock_brimstone@pact.com"),
                created = DateTime.Now,
                body = "Great work, cub. It still surprises me that someone so small can think so big."
            };
            var Com2 = new Comment
            {
                Id = 2,
                Post = context.Posts.SingleOrDefault(p => p.Title == "AMAZING discovery"),
                User = context.Users.SingleOrDefault(u => u.Email == "marjory_delaqua@divinitysreach.net"),
                created = DateTime.Now,
                body = "Brilliant job, Taimi. You never cease to amaze me."
            };
            var Com3 = new Comment
            {
                Id = 3,
                Post = context.Posts.SingleOrDefault(p => p.Title == "AMAZING discovery"),
                User = context.Users.SingleOrDefault(u => u.Email == "taimi_and_scruffy@rata.nov"),
                created = DateTime.Now,
                body = "Thanks, guys! You know I'd much rather be out there than closed up in this dusty old lab with the old codger looking over my shoulders all the time, but Scruffy 2.0 is still unreliable, so I'm afraid it will take some time."
            };
            var Com4 = new Comment
            {
                Id = 3,
                Post = context.Posts.SingleOrDefault(p => p.Title == "AMAZING discovery"),
                User = context.Users.SingleOrDefault(u => u.Email == "canach@thegrove.net"),
                created = DateTime.Now,
                body = "You're welcome to tag along, but please do try to make sure that your robot doesn't go on a murderous rampage next time."
            };
            var Com5 = new Comment
            {
                Id = 3,
                Post = context.Posts.SingleOrDefault(p => p.Title == "AMAZING discovery"),
                User = context.Users.SingleOrDefault(u => u.Email == "taimi_and_scruffy@rata.nov"),
                created = DateTime.Now,
                body = "Oh shut it, twig boy. The mishap was obviously because of inquest sabotage!"
            };
            context.Comments.AddOrUpdate(c => c.Id, Com1, Com2, Com3, Com4, Com5);
        }
    }
}
