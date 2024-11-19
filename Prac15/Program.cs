using System.Collections;
using System.Threading;

namespace Prac15
{
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
            var array = Read().ToArray();
            Console.Write("Введите число: ");
            int digit = int.Parse(Console.In.ReadLine());
            var newArray =
                from n in array
                where n < digit
                orderby n
                select n * 3;
        }

        /// <summary>
        /// Создает массив из объектов в строках файла и возвращает ссылку на него.
        /// </summary>
        static public ArrayList Read()
        {
            using (StreamReader fileIn = new StreamReader(@"input1.txt"))
            {
                ArrayList array = new ArrayList();
                string line;
                while ((line = fileIn.ReadLine()) != null) array.Add(int.Parse(line));
                return array;
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
                    array[i] = int.Parse(fileIn.ReadLine()));
                }
                return array;
            }
        }

        static public void Write(ArrayList array)
        {
            using (StreamWriter fileOut = new StreamWriter(@"output1.txt"))
            {
                foreach (int elem in array)
                {
                    Console.WriteLine(elem);
                    fileOut.WriteLine(elem);
                }
            }
        }
    }
}
