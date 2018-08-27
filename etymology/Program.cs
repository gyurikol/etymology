using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

// Morphemes
using etymology.Models;

namespace etymology
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            /*using (var db = new Models.dbContext.MorphemeContext())
            {
                db.Morphemes.Add(new Morpheme("a", Enumerable.Empty<string>(), Morpheme.MorphemeOrigin.Latin));
                db.SaveChanges();

                // Display all Blogs from the database
                var query = from b in db.Morphemes
                            orderby b.Name
                            select b;

                Console.WriteLine("All blogs in the database:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

            }*/
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
