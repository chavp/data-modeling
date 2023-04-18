using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Game.Engine.Tests
{
    [TestClass]
    public class TestSQLiteEF
    {
        // https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=visual-studio

        [TestMethod]
        public void TestMethod1()
        {
            using var db = new BloggingContext();
            var blog = new Blog
            {
                Url = "test1"
            };
            db.Blogs.Add(blog);

            blog.Posts.Add(new Post
            {
                Title = "555",
                Content = "test",
            });

            blog.Posts.Add(new Post
            {
                Title = "555",
                Content = "test",
            });

            db.SaveChanges();
        }

        [TestMethod]
        public void TestMethodRead()
        {
            using var db = new BloggingContext();
            var blog = db.Blogs.Include(x => x.Posts).Single(x => x.Url == "test1");

            db.Blogs.Remove(blog);
            db.SaveChanges();
        }
    }

    public class BloggingContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public string DbPath { get; }

        public BloggingContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "blogging.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.HasDefaultSchema("blogging");
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }

    public class Blog : DomainModel
    {
        public string Url { get; set; }
        public List<Post>? Posts { get; } = new();
    }

    public class Post : DomainModel
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Guid BlogId { get; set; }
        public Blog Blog { get; set; }
    }

    public abstract class DomainModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }

    public class Party
    {
        public string Name { get; set; }
    }
}