﻿using System;
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
             * Complete every task using Method syntax.
             *
             * HINT: Use the List of Methods defined in the Lecture Material Google Doc ***********
             *
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */


            //-----------------------------------------------------------------------------


            //Print the Sum and Average of numbers

            var sumOfNumbers = numbers.Sum();
            var avgOfNumbers = numbers.Average();


            //-----------------------------------------------------------------------------


            //Order numbers in ascending order and decsending order. Print each to console.

            var ascendingOrder = numbers.OrderBy(num => num);

            foreach (var item in ascendingOrder)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"--------------------------------");

            var descendingOrder = numbers.OrderByDescending(num => num);

            foreach (var item in descendingOrder)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"--------------------------------");


            //-----------------------------------------------------------------------------


            //Print to the console only the numbers greater than 6

            var greaterThanSix = numbers.Where(num => num > 6);

            foreach (var item in greaterThanSix)
            {
                Console.WriteLine(item);
            }

            //DON'T
            //var greaterThanSix = numbers.Where(num => num > 6); 
            //Console.WriteLine(numbers.Where(num => num > 6));


            Console.WriteLine($"--------------------------------");


            //-----------------------------------------------------------------------------



            //Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**

            foreach (var item in ascendingOrder.Take(4))
            {
                Console.WriteLine(item);
            }


            Console.WriteLine($"--------------------------------");


            //-----------------------------------------------------------------------------


            //Change the value at index 4 to your age, then print the numbers in decsending order
            numbers[4] = 26;

            foreach (var item in numbers.OrderByDescending(num => num)) 
            {
                Console.WriteLine(item);
            }


            Console.WriteLine($"--------------------------------");

            //-----------------------------------------------------------------------------


            // List of employees ***Do not remove this***
            var employees = CreateEmployees();

            //Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S.
            //Order this in acesnding order by FirstName.

            var cOrS = employees.Where(person => person.FirstName.StartsWith('C') || person.FirstName.StartsWith('S'));
            cOrS.OrderBy(person => person.FirstName);

            foreach (var item in cOrS)
            {
                Console.WriteLine(item.FullName);
            }

            Console.WriteLine($"--------------------------------");




            //-----------------------------------------------------------------------------

            //Print all the employees' FullName and Age who are over the age 26 to the console.
            //Order this by Age first and then by FirstName in the same result.

            var ageGreaterThanTwentySix = employees.Where(age => age.Age > 26)
                .OrderBy(age => age.Age).ThenBy(fname => fname.FirstName);

            foreach (var item in ageGreaterThanTwentySix)
            {
                Console.WriteLine($"{item.FullName}, {item.Age}");
            }

            Console.WriteLine($"--------------------------------");




            //-----------------------------------------------------------------------------


            //Print the Sum and then the Average of the employees' YearsOfExperience
            //if their YOE is less than or equal to 10 AND Age is greater than 35

            var filteredEmployees = employees.Where(yoe => yoe.YearsOfExperience <= 10 && yoe.Age > 35);
            var summedEmployees = filteredEmployees.Sum(num => num.YearsOfExperience);
            var avgedEmployees = filteredEmployees.Average(num => num.YearsOfExperience);

            Console.WriteLine($"{summedEmployees}, {avgedEmployees}");


            Console.WriteLine($"--------------------------------");




            //-----------------------------------------------------------------------------


            //Add an employee to the end of the list without using employees.Add()

            employees = employees.Append(new Employee("Jerry", "Gergich", 500, 1)).ToList();

            foreach (var item in employees)
            {
                Console.WriteLine($" {item.FirstName}, {item.LastName}, {item.Age}");
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
