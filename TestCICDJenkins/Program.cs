using System.Diagnostics;

namespace TestCICDJenkins
{
    internal class Program
    {
               
        static void Main(string[] args)
        {
            List<Person> EmployeeList = new List<Person> { new Person("Tchuimba", "Alphonsine"),
                                                           new Person("Tchayep Sidieu", "Guy"),
                                                           new Person("Tchayep Sidieu", "Ange David"),
                                                           new Person("Nana Tchayep", "Achille"),
                                                           new Person("Tchanang Tchayep", "Carine"),
                                                           new Person("Gohres", "Tim Emanuel")
                                                         };            
            Person employee1 = new Person("Tchanang Tchayep", "Carine");
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();
            //Console.WriteLine(Person.AreYouEmployee1(employee1, EmployeeList));
            Person.AreYouEmployee1(employee1, EmployeeList);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for the function AreYouEmployee1: {stopwatch.Elapsed.TotalMilliseconds} ms ");
            stopwatch.Start();
            //Console.WriteLine(employee1.AreYouEmployee2(EmployeeList));
            employee1.AreYouEmployee2(EmployeeList);
            stopwatch.Stop();
            Console.WriteLine($"Elapsed time for the function AreYouEmployee2: {stopwatch.Elapsed.TotalMilliseconds} ms ");
        }

        
    }
}
