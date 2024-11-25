using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prac15
{
    struct Toy : IComparable<Toy>
    {
        public string Name { get; }
        public int Price { get; }
        public int LowerAgeLimit { get; }
        public int UpperAgeLimit { get; }

        public Toy(string name, int price, int lowerAgeLimit, int upperAgeLimit)
        {
            this.Name = name;
            this.Price = price;
            this.LowerAgeLimit = lowerAgeLimit;
            this.UpperAgeLimit = upperAgeLimit;
        }

        public int CompareTo(Toy other)
        {
            return Price.CompareTo(other.Price);
        }

        public override  string ToString()
        {
            return Name + ";" + Price + ";" + LowerAgeLimit + ";" + UpperAgeLimit;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // LINQ: язык интегрированных запросов в С#
            Task1();
            //Task2();
        }

        public static void Task1()
        {
            /* 13. Вывести на экран в порядке возрастания все элементы, меньшие заданного числа,
             * увеличив их в три раза.
             */
            int[] ints = ReadInts();
            Console.Write("Введите число: ");
            int digit = int.Parse(Console.In.ReadLine());

            var newInts =
                from n in ints
                where n < digit
                orderby n
                select n * 3;

            using (StreamWriter fileOut = new StreamWriter(@"output1.txt"))
            {
                foreach (int elem in newInts)
                {
                    Console.WriteLine(elem);
                    fileOut.WriteLine(elem);
                }
            }
        }

        /// <summary>
        /// Создает массив из объектов в строках файла и возвращает ссылку на него.
        /// </summary>
        static public int[] ReadInts()
        {
            using (StreamReader fileIn = new StreamReader(@"input1.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array[i] = int.Parse(fileIn.ReadLine());
                }
                return array;
            }
        }


        public static void Task2()
        {
            /* Задание 13. На основе данных входного файла составить инвентарную ведомость
             * игрушек, включив следующие данные: название игрушки, ее стоимость (в руб.), возрастные
             * границы детей, для которых предназначена игрушка. Вывести в новый файл информацию о
             * тех игрушках, которые предназначены для детей старше N лет, отсортировав их по
             * стоимости.
             */
            Toy[] toys = ReadToys();
            Console.Write("Введите N: ");
            int N = int.Parse(Console.In.ReadLine());

            var newToys =
                from n in toys
                where n.LowerAgeLimit > N
                orderby n.Price
                select n;

            using (StreamWriter fileOut = new StreamWriter(@"output2.txt"))
            {
                foreach (Toy toy in newToys)
                {
                    Console.WriteLine(toy.ToString());
                    fileOut.WriteLine(toy.ToString());
                }
            }
        }

        /// <summary>
        /// Создает массив из объектов в строках файла и возвращает ссылку на него.
        /// </summary>
        static public Toy[] ReadToys()
        {
            using (StreamReader fileIn = new StreamReader(@"input2.txt"))
            {
                int num = int.Parse(fileIn.ReadLine());
                Toy[] array = new Toy[num];
                for (int i = 0; i < num; i++)
                {
                    string[] obj = fileIn.ReadLine().Split(';');
                    array[i] = new Toy(obj[0], int.Parse(obj[1]), int.Parse(obj[2]), int.Parse(obj[3]));
                }
                return array;
            }
        }
    }
}
