using System;

namespace EntityFameworkCodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Blogcontext())
            {
                var blog = new Blog { Name = "blog nome" };
                context.Blogs.Add(blog);
                context.SaveChanges();

                foreach (var item in context.Blogs)
                {
                    Console.WriteLine(item.Name);
                }
            }

            Console.ReadLine();
        }
    }
}