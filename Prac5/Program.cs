namespace Prac5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task2();
            Task3();
            //Task4();
        }

        /// <summary>
        /// III. Рекурсивный метод, возвращающий значение
        /// 13) для перевода числа из десятичной системы счисления в p-ичную систему счисления (p>1, p≠10)
        /// </summary>
        static void Task3()
        {
            Console.Out.Write("Введите десятичное число (d): ");
            int d = int.Parse(Console.ReadLine());
            Console.Out.Write("Введите нужную СС (p): ");
            int p = int.Parse(Console.ReadLine());
            string s = "";
            Console.Out.WriteLine($"Число {d} в {p}-ичной СС = {DecConv_Rec(d, p)}");
            string DecConv_Rec(int d, int p)
            {
                Console.Out.WriteLine($"Вызов DecConv_Rec({d}, {p})");
                if (d == 1)
                {
                    return "1" + s;
                }
                else
                {
                    //Console.Out.WriteLine($"Остаток = {d % p}, целое = {d / p}");
                    s = d % p + s;
                    d /= p;
                    return DecConv_Rec(d, p);
                }
            }
        }

        /// <summary>
        /// IV. Рекурсивный метод, не возвращающий значений
        /// </summary>
        static void Task4()
        {
            Console.Out.Write("Введите нечетное число n: ");
            int n = int.Parse(Console.ReadLine());
            int num = 1;
            Pic_Rec(1, (n - 1) / 2);

            /*/// <summary>
            /// Выводит на экран строку из n заданных символов a.
            /// </summary>
            void Stroka(char a, int n)
            {
                for (int i = 1; i <= n; i++)
                {
                    Console.Write(a);
                }
            }*/

            void Pic_Rec(int n, int i)
            {
                if (i >= 0)
                {
                    Console.Out.Write(String.Concat(Enumerable.Repeat(" ", i)));
                    Console.Out.WriteLine(String.Concat(Enumerable.Repeat(num, n)));
                    num++;
                    Pic_Rec(n + 2, i - 1);
                    Console.Out.Write(String.Concat(Enumerable.Repeat(" ", i)));
                    Console.Out.WriteLine(String.Concat(Enumerable.Repeat(num - 1, n)));
                    num--;
                }
            }

            /*for (int i = 0; i <= n; i += 2)
            {
                num++;
                sps = String.Concat(Enumerable.Repeat(" ", (n - i) / 2));
                Console.Out.WriteLine(sps + String.Concat(Enumerable.Repeat(num, i + 1)));
            }
            for (int i = n - 3; i >= 0; i -= 2)
            {
                num--;
                sps = String.Concat(Enumerable.Repeat(" ", (n - i) / 2));
                Console.Out.WriteLine(sps + String.Concat(Enumerable.Repeat(num, i + 1)));
            }*/
        }

        /// <summary>
        /// II. Использование базовых алгоритмов
        /// </summary>
        static void Task2()
        {
            /* 
             * 13. Разработать метод, который для заданного натурального числа находит количество простых
             * множителей. С помощью данного метода:
             * a) для каждого целого числа на отрезке [a, b] вывести на экран количество его простых
             * множителей;
             * b) на отрезке [a, b] найти все числа, имеющие наибольшее количество простых множителей;
             * c) на отрезке [a, b] найти все числа, количество простых множителей которого равно числу С;
             * d) для заданного числа А вывести на экран ближайшее следующее за ним число, количество
             * простых множителей которого равна количеству простых множителей числа А.
             */
            Console.Out.Write("Введите левую границу отрезка (a): ");
            int a = int.Parse(Console.ReadLine());
            Console.Out.Write("Введите правую границу отрезка (b): ");
            int b = int.Parse(Console.ReadLine());

            // a)
            for (int i = a; i <= b; i++)
            {
                Console.WriteLine("Кол-во простых множ. числа {0} = {1}", i, PrimeCount(i));
            }

            // b)
            Console.WriteLine("\nВсе числа, имеющие наибольшее количество простых множителей:");
            var mn = new Dictionary<int, int>();
            int mnc = 0;
            int maxmn = 0;
            for (int i = a; i <= b; i++)
            {
                mnc = PrimeCount(i);
                mn.Add(i, mnc);
                if (mnc > maxmn)
                {
                    maxmn = mnc;
                }
            }
            foreach (var pair in mn)
            {
                if (pair.Value == maxmn)
                {
                    Console.WriteLine(pair.Key);
                }
            }

            // c)
            Console.Out.Write("\nВведите число C: ");
            int C = int.Parse(Console.ReadLine());
            foreach (var pair in mn)
            {
                if (pair.Value == C)
                {
                    Console.WriteLine(pair.Key);
                }
            }

            // d)
            Console.Out.Write("\nВведите число A: ");
            int A = int.Parse(Console.ReadLine());
            foreach (var pair in mn)
            {
                if (pair.Key > A && pair.Value == mn[A])
                {
                    Console.WriteLine(pair.Key);
                    break;
                }
            }
        }

        /// <summary>
        /// Возвращает количество простых множителей числа N.
        /// </summary>
        static int PrimeCount(int N)
        {
            var result = 0;
            for (var i = 1; i <= N; i++)
            {
                if (N % i == 0 && IsPrime(i))
                {
                    result++;
                }
            }
            return result;
        }

        /// <summary>
        /// Возвращает True, если число number является простым.
        /// </summary>
        static bool IsPrime(int n)
        {
            for (var i = 2; i < Math.Sqrt(n); i++)
            {
                if (n % i == 0 || n % (n / i) == 0)
                    return false;
            }
            return n != 1;
        }
    }
}
