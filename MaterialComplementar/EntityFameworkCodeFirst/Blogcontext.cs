using System.Collections.Generic;
using System.Data.Entity;

namespace EntityFameworkCodeFirst
{
    public class Blogcontext : DbContext
    {
        public Blogcontext()
            :base(nameOrConnectionString: "Blogcontext")
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }

    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
    }

}