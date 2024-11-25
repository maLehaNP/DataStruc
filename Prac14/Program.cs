using System.Collections;

namespace Prac14
{
    struct SPoint
    {
        public int X { get; set; }
        public int Y { get; set; }
        public SPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public double DistanceTo(SPoint obj)
        {
            return Math.Sqrt(Math.Pow(X - obj.X, 2) + Math.Pow(Y - obj.Y, 2));
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }
    }

    struct SPassenger : IComparable<SPassenger>
    {
        public string FullName { get; set; }
        public int Amount { get; set; }
        public int TotalWeight { get; set; }

        public SPassenger(string fullName, int amount, int totalWeight)
        {
            this.FullName = fullName;
            this.Amount = amount;
            this.TotalWeight = totalWeight;
        }

        public double AvgWeight
        {
            get
            {
                return TotalWeight / Amount;
            }
        }

        public override string ToString()
        {
            return "(" + FullName + ", " + Amount + ", " + TotalWeight + ")";
        }

        public int CompareTo(SPassenger other)
        {
            return this.Amount.CompareTo(other.Amount);
        }
    }

    internal class Program
    {
        /// <summary>
        /// Создает массив из объектов в строках файла и возвращает ссылку на него.
        /// </summary>
        /// <returns></returns>
        static public ArrayList InputSPoint()
        {
            using (StreamReader fileIn = new StreamReader(@"input1.txt"))
            {
                ArrayList array = new ArrayList();
                string line;
                while ((line = fileIn.ReadLine()) != null)
                {
                    string[] obj = line.Split(' ');
                    array.Add(new SPoint(int.Parse(obj[0]), int.Parse(obj[1])));
                }
                return array; // В качестве результата метод возвращает ссылку на массив структур.
            }
        }

        /// <summary>
        /// Создает массив из объектов в строках файла и возвращает ссылку на него.
        /// </summary>
        /// <returns></returns>
        static public SPassenger[] InputSPassenger()
        {
            using (StreamReader fileIn = new StreamReader(@"input2.txt"))
            {
                int n = int.Parse(fileIn.ReadLine());
                SPassenger[] array = new SPassenger[n];
                for (int i = 0; i < n; i++)
                {
                    string[] obj = fileIn.ReadLine().Split(';');
                    array[i] = new SPassenger(obj[0], int.Parse(obj[1]), int.Parse(obj[2]));
                }
                return array;
            }
        }

        /// <summary>
        /// Выводит одномерный массив элеметов типа T.
        /// </summary>
        static void Print1D<T>(T[] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.WriteLine("{0} ", a[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит arrayList элеметов типа T.
        /// </summary>
        static void PrintArray<T>(ArrayList array)
        {
            foreach (T elem in array)
            {
                Console.WriteLine("{0} ", elem);
            }
            Console.WriteLine();
        }

        static void Task1()
        {
            // 13–14. Найти такую точку, сумма расстояний от которой до остальных точек множества максимальна.
            ArrayList array = InputSPoint();
            PrintArray<SPoint>(array);
            double maxDistSum = 0;
            ArrayList arrayMax = new ArrayList();
            foreach (SPoint point1 in array)
            {
                double distSum = 0;
                foreach (SPoint point2 in array)
                {
                    //Console.WriteLine("Расстояние от " + point1 + " до " + point2 + " = " + point1.DistanceTo(point2));
                    distSum += point1.DistanceTo(point2);
                }
                Console.WriteLine(point1 + " distSum = " + distSum + " maxDistSum = " + maxDistSum);
                if (distSum == maxDistSum) arrayMax.Add(point1);
                if (distSum > maxDistSum)
                {
                    maxDistSum = distSum;
                    arrayMax.Clear();
                    arrayMax.Add(point1);
                }
            }

            using (StreamWriter fileOut = new StreamWriter(@"output1.txt"))
            {
                foreach (SPoint point in arrayMax)
                {
                    Console.WriteLine(point.X + " " + point.Y);
                    fileOut.WriteLine(point.X + " " + point.Y);
                }
            }
        }

        static void Task2()
        {
            /* 
             * 3) На основе данных входного файла составить багажную ведомость камеры хранения,
             * включив следующие данные: ФИО пассажира, количество вещей, общий вес вещей.
             * Вывести в новый файл информацию о тех пассажирах, средний вес багажа которых
             * превышает заданный, отсортировав их по количеству вещей, сданных в камеру
             * хранения.
             */
            SPassenger[] array = InputSPassenger();
            Print1D<SPassenger>(array);
            Array.Sort(array);
            using (StreamWriter fileOut = new StreamWriter(@"output2.txt"))
            {
                Console.Out.Write("Введите вес: ");
                int maxWeight = int.Parse(Console.ReadLine());
                foreach (SPassenger passenger in array)
                {
                    if (passenger.AvgWeight > maxWeight)
                    {
                        Console.WriteLine(passenger.ToString() + " AvgWeight: " + passenger.AvgWeight);
                        fileOut.WriteLine(passenger.FullName + ";" + passenger.Amount + ";" + passenger.TotalWeight);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Task1();
            //Task2();
        }
    }
}
