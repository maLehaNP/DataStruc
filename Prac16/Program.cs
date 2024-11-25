using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prac16
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

        public override string ToString()
        {
            return Name + ";" + Price + ";" + LowerAgeLimit + ";" + UpperAgeLimit;
        }
    }

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
            /* 14. Вывести на экран в порядке убывания все элементы, большие заданного числа, уменьшив
             * их в три раза.
             */
            int[] ints = ReadInts();

            Console.Write("Введите число: ");
            int digit = int.Parse(Console.In.ReadLine());

            var newInts = ints.Where(n => n > digit).OrderDescending().Select(n => n / 3);

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
                    array.SetValue(int.Parse(fileIn.ReadLine()), i);
                }
                return array;
            }
        }

        public static void Task2()
        {
            /* Задание 14. На основе данных входного файла составить инвентарную ведомость
             * игрушек, включив следующие данные: название игрушки, ее стоимость (в руб.), возрастные
             * границы детей, для которых предназначена игрушка. Вывести в новый файл информацию о
             * тех игрушках, которые предназначены для детей от N до M лет, сгруппировав их по
             * названию.
             */
            Toy[] toys = ReadToys();
            Console.Write("Введите N: ");
            int N = int.Parse(Console.In.ReadLine());
            Console.Write("Введите M: ");
            int M = int.Parse(Console.In.ReadLine());

            var newToys = toys.Where(toy => toy.LowerAgeLimit == N && toy.UpperAgeLimit == M).GroupBy(toy => toy.Name);

            using (StreamWriter fileOut = new StreamWriter(@"output2.txt"))
            {
                foreach (var group in newToys)
                {
                    Console.Write("Группа {0}: ", group.Key);
                    fileOut.Write("Группа " + group.Key + ": ");
                    foreach (var toy in group)
                    {   
                        Console.Write("{0} ", toy.ToString());
                        fileOut.Write(toy.ToString() + " ");
                    }
                    Console.WriteLine();
                    fileOut.WriteLine();
                }
                Console.WriteLine();
                fileOut.WriteLine();
            }
        }

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
