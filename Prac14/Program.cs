using System.Collections;

namespace Prac14
{
    struct SPoint
    {
        public int x, y;
        public SPoint(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public double DistanceTo(SPoint obj)
        {
            return Math.Sqrt(Math.Pow(x - obj.x, 2) + Math.Pow(y - obj.y, 2));
        }

        public override string ToString()
        {
            return "(" + x + ", " + y + ")";
        }
    }

    struct SPassenger : IComparable<SPassenger>
    {
        public string fullName;
        public int amount;
        public int totalWeight;

        public SPassenger(string fullName, int amount, int totalWeight)
        {
            this.fullName = fullName;
            this.amount = amount;
            this.totalWeight = totalWeight;
        }

        public double AvgWeight()
        {
            return totalWeight / amount;
        }

        public override string ToString()
        {
            return "(" + fullName + ", " + amount + ", " + totalWeight + ")";
        }

        /*public int CompareTo(SPassenger other)
        {
            return amount.CompareTo(other.amount);
        }*/

        public int CompareTo(SPassenger other)
        {
            if (this.amount == other.amount) return 0;
            if (this.amount > other.amount) return 1;
            return -1;
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
        static public ArrayList InputSPassenger()
        {
            using (StreamReader fileIn = new StreamReader(@"input2.txt"))
            {
                ArrayList array = new ArrayList();
                string line;
                while ((line = fileIn.ReadLine()) != null)
                {
                    string[] obj = line.Split(';');
                    Print1D<string>(obj);
                    array.Add(new SPassenger(obj[0], int.Parse(obj[1]), int.Parse(obj[2])));
                }
                return array;
            }
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
                    Console.WriteLine(point.x + " " + point.y);
                    fileOut.WriteLine(point.x + " " + point.y);
                }
            }
        }

        /// <summary>
        /// Выводит одномерный массив элеметов типа T.
        /// </summary>
        static void Print1D<T>(T[] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.Write("{0} ", a[i]);
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
                Console.Write("{0} ", elem);
            }
            Console.WriteLine();
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
            ArrayList array = InputSPassenger();
            PrintArray<SPassenger>(array);
            array.Sort();
            using (StreamWriter fileOut = new StreamWriter(@"output2.txt"))
            {
                Console.Out.Write("Введите вес: ");
                int maxWeight = int.Parse(Console.ReadLine());
                foreach (SPassenger passenger in array)
                {
                    if (passenger.AvgWeight() > maxWeight)
                    {
                        Console.WriteLine(passenger.ToString() + passenger.AvgWeight());
                        fileOut.WriteLine(passenger.fullName + ";" + passenger.amount + ";" + passenger.totalWeight);
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            //Task1();
            Task2();
        }
    }
}
