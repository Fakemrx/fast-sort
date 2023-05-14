using System;

namespace kyrs
{
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                int choice;

                do
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Add array elements manually");
                    Console.WriteLine("2. Generate array elements randomly");
                    Console.WriteLine("0. Exit");
                    Console.Write("Select: ");

                    if (int.TryParse(Console.ReadLine(), out choice))
                    {
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Select 1");

                                Console.WriteLine("Enter the size to array");
                                Search(Convert.ToUInt32(Console.ReadLine()));
                                break;

                            case 2:
                                Console.WriteLine("Select 2");

                                Search();
                                break;

                            case 0:
                                Console.WriteLine("Exit");
                                break;

                            default:

                                Console.WriteLine("Retry");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Retry");

                    }

                    Console.WriteLine();
                } while (choice != 0);



            }
            catch
            {
                Console.WriteLine("error");
            }
        }

        public static void Search(uint sizeArray)
        {
            int elementSearch;
            int[] array = new int[10];



            Console.WriteLine("Enter the element to search");
            elementSearch = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Array elements:");
            for (var i = 0; i < sizeArray; i++)
            {
                array[i] = Convert.ToInt32(Console.ReadLine());
            }

            var arrayIndexFound = array.LinearSearch(elementSearch);
            foreach (var i in arrayIndexFound)
            {
                Console.WriteLine("Index of search element:" + i);
            }

        }

        public static void Search()
        {
            uint sizeArray;
            int elementSearch;

            Console.WriteLine("Enter the size of the array:");
            sizeArray = Convert.ToUInt32(Console.ReadLine());

            Console.WriteLine("Enter the element to search:");
            elementSearch = Convert.ToInt32(Console.ReadLine());

            int[] array = GenerateRandomArray(Convert.ToInt32(sizeArray)); // Заполняем массив случайными числами 

            Console.WriteLine("Array elements:");
            for (var i = 0; i < sizeArray; i++)
            {
                Console.WriteLine(array[i]);
            }

            var arrayIndexFound = array.LinearSearch(elementSearch);
            foreach (var i in arrayIndexFound)
            {
                Console.WriteLine("Index of search element: " + i);
            }
        }

        public static int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];

            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(-10, 10); // Генерируем случайное число от 0 до 9 
            }

            return array;
        }
    }





    public static class Ext
    {
        public static IEnumerable<int> LinearSearch(this int[] array, int target)
        {
            bool isFound = false;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    yield return i;
                    isFound = true;
                }
            }

            if (!isFound)
            {
                Console.WriteLine("Index of search element not found");
            }
        }
    }

}