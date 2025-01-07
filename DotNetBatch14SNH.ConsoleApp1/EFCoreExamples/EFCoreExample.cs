using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBatch14SNH.ConsoleApp1.EFCoreExamples
{
    public class EFCoreExample
    {
        private readonly AppDbContext _db = new AppDbContext();

        public void Read()
        {
            var lst = _db.Blogs.ToList();
            foreach (var item in lst) { 

                Console.WriteLine(item.id);
                Console.WriteLine(item.title);
                Console.WriteLine(item.author);
                Console.WriteLine(item.content);

            }

        }

        public void Edit(string id)
        {
            var item = _db.Blogs.FirstOrDefault(x => x.id == id);
            if(item is null)
            {
                Console.WriteLine("no data found");
                return;
            }

            Console.WriteLine(item.id);
            Console.WriteLine(item.title);
            Console.WriteLine(item.author);
            Console.WriteLine(item.content);
            
        }

        public void Create(string title,string author,string content)
        {
            var blog = new TblBlog {id= Guid.NewGuid().ToString(), title = title, author = author, content = content };
            _db.Blogs.Add(blog);

            var result = _db.SaveChanges();
            string message = result  > 0 ? "Create successfully" : "Create Failed";
            Console.WriteLine(message);

        }

        public void Update(string id,string title,string author,string content)
        {
            //what is asnotracking use for?
            var lst = _db.Blogs.AsNoTracking().FirstOrDefault(x=> x.id == id);

            if(lst is null)
            {
                Console.WriteLine("No Data for Update");
                return;
            }
            lst.title = title;
            lst.author = author;
            lst.content = content;

            //****************** entry method use ya tal
            _db.Entry(lst).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = _db.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);

        }

        public void Delete(string id)
        {
            var lst = _db.Blogs.AsNoTracking().FirstOrDefault(x=> x.id == id);
            if(lst is null)
            {

                Console.WriteLine("No data found to Delete");
                return;
            }
            _db.Entry(lst).State = EntityState.Deleted;
            var result = _db.SaveChanges();
            string message = result > 0 ? "Delete Successful" : "Delete Failed";
            Console.WriteLine(message);
        }
    }
}
