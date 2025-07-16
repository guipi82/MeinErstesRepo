using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCICDjenkins2
{
    public class Person
    {
        public string LastName { get; set; }
        public string Firstname { get; set; }
        public int ID { get; set; }

        public Person(string lastname, string firstname)
        {
            LastName = lastname;
            Firstname = firstname;
        }
        public static bool AreYouEmployee1(Person person, List<Person> EmployeeList)
        {
            foreach (var item in EmployeeList)
            {
                if ((item.LastName == person.LastName) && (item.Firstname == person.Firstname))
                {
                    return true;
                }
            }

            return false;
        }
        public bool AreYouEmployee2(List<Person> EmployeeList)
        {
            return EmployeeList.Any(x => x.LastName == LastName && x.Firstname == Firstname);
        }
    }
}
