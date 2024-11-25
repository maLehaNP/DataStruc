using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prac16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // МЕТОДЫ РАСШИРЕНИЙ
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

            var newInts = ints.Where(n => n < digit).OrderBy(n => n).Select(n => n * 3);

            using (StreamWriter fileOut = new StreamWriter(@"output.txt"))
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
            using (StreamReader fileIn = new StreamReader(@"input.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                int[] array = new int[n];
                for (int i = 0; i < n; i++)
                {
                    array.SetValue(int.Parse(fileIn.ReadLine()), i);
                }
                return array;
            }
        }

        public static void Task2()
        {
        }
    }
}
