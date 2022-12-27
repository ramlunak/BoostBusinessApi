using ConsoleApp1;
using System;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("dsfsd");

            //var dep = new Departemento<int>();
            //dep.GetType();
            //var dep2 = new Departemento<bool>();
            //dep2.GetType();

            var repo = new UserRepositiry();
            var user = repo.Post(new User { Name = "royber" });
            Console.WriteLine(user);
            Console.ReadLine();
        }

        class Departemento<T>
        {
            public T? Value { get; set; }

            public void GetType()
            {
                string type = typeof(T).ToString();
                Console.WriteLine(type);
            }
        }

    }
}
