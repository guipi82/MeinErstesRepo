using NUnit.Framework;
using TestCICDjenkins2;

namespace TestEmployees
{
    public class Tests
    {
        List<Person> EmployeeList = new List<Person> { };

        [SetUp]
        public void Setup()
        {
            EmployeeList = new List<Person> { new Person("Tchuimba", "Alphonsine"),
                                                           new Person("Tchayep Sidieu", "Guy"),
                                                           new Person("Tchayep Sidieu", "Ange David"),
                                                           new Person("Nana Tchayep", "Achille"),
                                                           new Person("Tchanang Tchayep", "Carine"),
                                                           new Person("Gohres", "Tim Emanuel")
                                                         };
        }

        [Test]
        public void EmployeeIsNotInList_False()
        {
            Person employee1 = new Person("Smith", "Peter");

            bool Isemployee = Person.AreYouEmployee1(employee1, EmployeeList);

            Assert.That(Isemployee, Is.EqualTo(false));
        }

        [Test]
        public void EmployeeIsInList_True()
        {
            Person employee1 = new Person("Nana Tchayep", "Achille");

            bool Isemployee = employee1.AreYouEmployee2(EmployeeList);

            Assert.That(Isemployee, Is.EqualTo(true));
        }
    }
}