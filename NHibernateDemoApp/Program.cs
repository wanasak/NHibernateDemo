using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernateDemoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateDemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var cfg = new Configuration();
            cfg.DataBaseIntegration(x =>
                {
                    // Set connection string
                    x.ConnectionString = "Data Source=.;Initial Catalog=NHibernateDemoApp;Integrated Security=True";
                    x.Driver<SqlClientDriver>();
                    x.Dialect<MsSql2012Dialect>();                });
            // Mapping filed
            cfg.AddAssembly(Assembly.GetExecutingAssembly());
            var sefact = cfg.BuildSessionFactory();
            using (var session = sefact.OpenSession())
            {
                using (var tx = session.BeginTransaction())
                {
                    #region Create 
                    var student1 = new Student
                    {
                        ID = 1,
                        FirstMidName = "Allan",
                        LastName = "Bommer"
                    };
                    var student2 = new Student
                    {
                        ID = 2,
                        FirstMidName = "Jerry",
                        LastName = "Lewis"
                    };
                    session.Save(student1);
                    session.Save(student2);
                    #endregion
                    #region Read
                    //// Get all
                    //var students = session.CreateCriteria<Student>().List<Student>();
                    //foreach (var student in students)
                    //{
                    //    Console.WriteLine("{0} \t{1} \t{2}",
                    //        student.ID,
                    //        student.FirstMidName,
                    //        student.LastName);
                    //}
                    //// Get single
                    //var std = session.Get<Student>(1);
                    //Console.WriteLine("Get by id.");
                    //Console.WriteLine("{0} \t{1} \t{2}",
                    //    std.ID,
                    //    std.FirstMidName,
                    //    std.LastName);
                    #endregion
                    #region Update
                    //std.LastName = "XXX";
                    //session.Update(std);
                    //Console.WriteLine("After update student.");
                    //Console.WriteLine("{0} \t{1} \t{2}",
                    //    std.ID,
                    //    std.FirstMidName,
                    //    std.LastName);
                    #endregion
                    #region Delete
                    //var studentToDelete = session.Get<Student>(1);
                    //session.Delete(studentToDelete);
                    //Console.WriteLine("After delete student.");
                    //foreach (var student in students)
                    //{
                    //    Console.WriteLine("{0} \t{1} \t{2}",
                    //        student.ID,
                    //        student.FirstMidName,
                    //        student.LastName);
                    //}
                    #endregion
                    tx.Commit();
                }
                Console.ReadLine();
            }
        }
    }
}
