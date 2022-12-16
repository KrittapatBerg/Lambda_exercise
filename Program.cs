using System;
using System.Collections.Generic;
using System.Drawing;

namespace Lambda_exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Initialization
            int[] numbers = new int[20];            //array of int 20 positions
            string[] cities = new string[20];       //array of string 20 positions 

            //Random Initialization
            var rnd = new Random();                 //create random 
            var names = "Stockholm, Copenhagen, Oslo, Helsinki, Berlin, Madrid, Lissabon".Split(',');
            //string names contains city names and code seperate them with .Split(); method with a comma (',');
            for (int i = 0; i < numbers.Length; i++)    //for loop
            {
                numbers[i] = rnd.Next(100, 1000 + 1);   //random array numbers between 100 and 1000, + 1 is to make sure it doesn't start at 99
                cities[i] = names[rnd.Next(0, names.Length)].Trim();    //random array cities with string names Trim(); method removes white space between words
            }

            WriteLists(numbers, cities);   //a method with (randomize) argument that print out 20 random numbers and cities
            #endregion

            #region Exercise 2
            Console.WriteLine("\nDelegates I");
            Console.WriteLine($"\n{nameof(numbers)} output by delegate");
            Array.ForEach(numbers, myInt => Console.WriteLine(myInt));   //delegate


            Console.WriteLine($"\n{nameof(cities)} output by delegate");
            Array.ForEach(cities, myString => Console.WriteLine(myString));     //delegate

            Console.WriteLine($"\n{nameof(numbers)} output by generic delegate");
            Array.ForEach(numbers, WriteItem<int>);
            Console.WriteLine($"\n{nameof(cities)} output by generic delegate");
            Array.ForEach(cities, WriteItem<string>);

            Console.WriteLine("\nDelegates II");
            var evenlist = Array.FindAll(numbers, IsEven);
            Array.ForEach(evenlist, item => Console.WriteLine(item % 2 == 0));      //delegate

            Console.WriteLine();
            var temp = Array.FindAll(cities, IsLongName);
            Array.ForEach(temp, item => Console.WriteLine(item.Length > 6));        //delegate

            Console.WriteLine("\nDelegates III");
            Console.WriteLine(Array.Find(numbers, (int item) => item > 500));       //delegate
            Console.WriteLine(Array.FindLast(cities, (string item) => item.Length > 6));        //delegate

            int sum = 0;            //exercise delegate nr.3
            Array.ForEach(numbers, item => sum = sum + item);
            Console.WriteLine(sum);

            int largestNumber = int.MinValue;
            Array.ForEach(numbers, item => { if (item > largestNumber) largestNumber = item; });
            Console.WriteLine(largestNumber);
            #endregion
        }

        #region Initialization
        static void WriteLists(int[] _numbers, string[] _cities)
        {

            Console.WriteLine($"{nameof(_numbers)}:");
            foreach (var item in _numbers)
                Console.WriteLine(item);


            Console.WriteLine($"\n{nameof(_cities)}:");
            foreach (var item in _cities)
                Console.WriteLine(item);

        }
        #endregion

        #region Delegates declarations
        static void WriteInts(int myInt)
        {
            Console.WriteLine(myInt);
        }
        static void WriteString(string myString)
        {
            Console.WriteLine(myString);
        }
        static void WriteItem<T>(T item)
        {
            Console.WriteLine(item);
        }
        public static bool IsEven(int item) => item % 2 == 0;
        public static bool IsLongName(string item) => item.Length > 6;

        static bool IsLargeNumber(int item) => item > 500;
        static bool IsLongestName(string item) => item.Length > 8;
        #endregion

    }
}

//Exercises Delegates => Lamda Expressions
//1.  Go through the code above and try to understand the usage of delegates
//2.  Redo Exercises from in region Exercise 2 using Lambda Expressions in all Array.ForEach(), Array.FindAll(),
//    Array.Find(), Array.FindLast()
//3.  Use Array.ForEach() and Lambda (with a captured variable count) to calculate the sum of all the
//    elements in the array numbers
//4.  Use Array.ForEach() and Lambda (with a captured variable) to find the largest element in the array numbers
