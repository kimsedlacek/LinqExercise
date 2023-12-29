using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine($"Sum: {numbers.Sum()}");

            //TODO: Print the Average of numbers
            Console.WriteLine($"Average: {numbers.Average()}");

            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Numbers Below are in Ascending Order:");
            var ascendingNumbers = numbers.OrderBy(x => x);
            foreach (var number in ascendingNumbers)
            {
                Console.WriteLine(number);
            }
            //TODO: Order numbers in descending order and print to the console
            Console.WriteLine("Numbers Below are in Descending Order:");
            var descendingNumbers = numbers.OrderByDescending(x => x);
            foreach (var number in descendingNumbers)
            {
                Console.WriteLine(number);
            }
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Numbers Greater than 6:");
            var numsGreaterThan6 = numbers.Where(x => x > 6);
            foreach (var num in numsGreaterThan6)
            {
            Console.WriteLine(num);
            }
            
            //TODO: Order numbers in any order (ascending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("Four Ascending Numbers:");
            var ascendingNums = numbers.OrderBy(x => x);
            int keepFour = 0;
            foreach(var num in ascendingNums)
            {
                if (keepFour < 4)
                {
                    Console.WriteLine(num);
                    keepFour++;
                }
                else
                {
                    break;
                }
            }
            //TODO: Change the value at index 4 to your age, then print the numbers in descending order
            Console.WriteLine("Descending Order:");
            numbers[4] = 56;
            var newDescending = numbers.OrderByDescending(x => x);
            foreach (var num in newDescending)
            {
                Console.WriteLine(num);
            }
           


            // List of employees ****Do not remove this****
            var employees = CreateEmployees();



            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with
            //a C OR an S and order this in ascending order by FirstName.
            Console.WriteLine("Employees with First Name C or S, in Ascending Order:");
            var firstNameCS = employees.Where(x => x.FirstName.StartsWith('C') || x.FirstName.StartsWith('S')).
                OrderBy(x => x.FirstName);
            foreach(var name in firstNameCS)
            {
                Console.WriteLine(name.FullName);
            }

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this
            //by Age first and then by FirstName in the same result.
            Console.WriteLine("Employees over 26 in Age Order:");
            var empOver26 = employees.Where(x => x.Age > 26).OrderBy(x => x.Age).ThenBy(x => x.FirstName);
            foreach (var emp in empOver26)
            {
                Console.WriteLine($"{emp.FullName},{emp.Age}");
            }
            //TODO: Print the Sum of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND
            //Age is greater than 35.
            Console.WriteLine("Sum of YOE when Age > 35 & YOE <= 10:");
            var emp1035 = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35);
            Console.WriteLine(emp1035.Sum(x => x.YearsOfExperience));

            //TODO: Now print the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Average of YOE when Age > 35 & YOE <= 10:");
            Console.WriteLine(emp1035.Average(x => x.YearsOfExperience));
            //TODO: Add an employee to the end of the list without using employees.Add()
            employees = employees.Append(new Employee("Kim", "Sedlacek", 56, 0)).ToList();

            var newEmpList = employees;
            foreach (var emp in newEmpList)
            {
                Console.WriteLine($"{emp.FullName}, {emp.Age}, {emp.YearsOfExperience}");
            }

            Console.WriteLine();

            Console.ReadLine();
        }

        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
