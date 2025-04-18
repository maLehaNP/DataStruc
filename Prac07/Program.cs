﻿namespace Prac7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task4();
            Task6();
        }

        /// <summary>
        /// Выводит одномерный массив.
        /// </summary>
        static void Print(int[] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Console.Write("{0} ", a[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Выводит двумерный массив.
        /// </summary>
        static void Print(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write("{0} ", a[i, j]);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Выводит ступенчатый двумерный массив.
        /// </summary>
        static void Print(int[][] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                Print(a[i]);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Заполяет массив nxn.
        /// </summary>
        /*static void Input(out int[,] a)
        {
            Console.Write("n = ");
            int n = int.Parse(Console.ReadLine());
            a = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write("a[{0},{1}]= ", i, j);
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }*/

        static void Task4()
        {
            /* IV. Дан массив размером n×n, элементы которого целые числа.
             * 13. Для каждой строки найти номер первого отрицательного элемента и записать данные в
             * новый массив.
             */
            int[,] a = new int[,] { { 0, 1, 2, 3, -4 }, { 6, 4, 2, 7, 9 }, { 5, 6, 4, -3, 8 }, { 1, 4, -7, 7, 3 }, { -1, 4, 6, 8, 4 } };
            //int[,] a;
            //Input(out a);
            int[] b = new int[a.GetLength(0)];
            int k = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i, j] < 0)
                    {
                        b[k] = j + 1;
                        k++;
                        break;
                    }
                }
            }
            Print(a);
            foreach (int elem in b)
            {
                Console.Write("{0} ", elem);
            }
        }

        /// <summary>
        /// Ищет минимальный элемент ступенчатого двумерного массива, возращает его и изменяет переданные индексы.
        /// </summary>
        static int Min(int[][] a, int n, int m, out int min_i, out int min_j)
        {
            int min = a[0][0];
            min_i = 0;
            min_j = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (a[i][j] < min)
                    {
                        min = a[i][j];
                        min_i = i;
                        min_j = j;
                    }
                }
            }
            return min;
        }

        /// <summary>
        /// Удаляет строку с номером k в ступенчатом двумерном массиве.
        /// </summary>
        static void DeleteStroke(int[][] a, ref int n, int m, int k)
        {
            for (int i = k; i < n - 1; i++) //сдвиг строк вверх начиная с k-той строки
                a[i] = a[i + 1];
            n--; //уменьшаем текущее количество строк в массиве
        }

        /// <summary>
        /// Удаляет столбец с номером k в ступенчатом двумерном массиве.
        /// </summary>
        static void DeleteColumn(int[][] a, int n, ref int m, int k)
        {
            for (int i = 0; i < n; i++)
                for (int j = k; j < m - 1; j++)
                    a[i][j] = a[i][j + 1];
            m--;
        }

        static void Task6()
        {
            /* VI. 13. Удалить строку и столбец, на пересечении которых стоит минимальный элемент
             * (минимальный элемент встречается в массиве только одни раз).
             */
            int[][] a = new int[4][];
            a[0] = new int[] { -2, 2, 3, 4 };
            a[1] = new int[] { 4, 5, 6, 8 };
            a[2] = new int[] { 7, 8, 1, 7 };
            a[3] = new int[] { 9, 10, 11, 12 };
            Print(a);
            int n = a.Length;
            int m = a[0].Length;     
            int min_i;
            int min_j;
            int min = Min(a, n, m, out min_i, out min_j);
            Console.WriteLine("{0} [{1}, {2}]\n", min, min_i, min_j);
            DeleteStroke(a, ref n, n, min_i);
            Print(a);
            DeleteColumn(a, n, ref m, min_j);
            Print(a);
        }
    }
}
