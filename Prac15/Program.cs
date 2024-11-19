using System.Collections;

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
            ArrayList array = Input();
            Console.Write("Введите число: ");
            int digit = int.Parse(Console.In.ReadLine());
        }

        /// <summary>
        /// Создает массив из объектов в строках файла и возвращает ссылку на него.
        /// </summary>
        static public ArrayList Input()
        {
            using (StreamReader fileIn = new StreamReader(@"input1.txt"))
            {
                ArrayList array = new ArrayList();
                string line;
                while ((line = fileIn.ReadLine()) != null) array.Add(line);
                return array;
            }
        }
    }
}
