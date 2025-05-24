using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prac22
{
    class CoordGraph
    {
        private class Node  // Вложенный класс для скрытия данных и алгоритмов
        {
            private int[,] array;  // Матрица смежности
            private int[,] coords;  // Координаты
            private double[,] distances;  // Матрица смежности

            public int this[int i, int j] // Индексатор для обращения к матрице смежности
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }
            public int Size // Свойство для получения размерности матрицы смежности
            {
                get
                {
                    return array.GetLength(0);
                }
            }

            private bool[] nov; // Вспомогательный массив: если i-ый элемент массива равен
                                // true, то i-ая вершина еще не просмотрена; если i-ый
                                // элемент равен false, то i-ая вершина просмотрена

            public void NovSet() // Метод помечает все вершины графа как непросмотреные
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }

            // Конструктор вложенного класса, инициализирует матрицу смежности и
            // вспомогательный массив
            public Node(int[,] a, int[,] c)
            {
                array = a;
                coords = c;
                double[,] d = new double[Size, Size];
                distances = d;
                UpdateDistances();
                nov = new bool[a.GetLength(0)];
            }

            // Реализация алгоритма обхода графа в глубину
            public void Dfs(int v)
            {
                Console.Write("{0} ", v); // Просматриваем текущую вершину
                nov[v] = false; // Помечаем ее как просмотренную
                // В матрице смежности просматриваем строку с номером v
                for (int u = 0; u < Size; u++)
                {
                    // Если вершины v и u смежные, к тому же вершина u не просмотрена,
                    if (array[v, u] != 0 && nov[u])
                    {
                        Dfs(u); // То рекурсивно просматриваем вершину
                    }
                }
            }

            // Реализация алгоритма обхода графа в ширину
            /*public void Bfs(int v)
            {
                Queue q = new Queue(); // Инициализируем очередь
                q.Add(v); // Помещаем вершину v в очередь
                nov[v] = false; // Помечаем вершину v как просмотренную
                while (!q.IsEmpty) // Пока очередь не пуста
                {
                    v = q.Take(); // Извлекаем вершину из очереди
                    Console.Write("{0} ", v); // Просматриваем ее
                    for (int u = 0; u < Size; u++) // Находим все вершины
                    {
                        if (array[v, u] != 0 && nov[u]) // Смежные с данной и еще не просмотренные
                        {
                            q.Add(u); // Помещаем их в очередь
                            nov[u] = false; // и помечаем как просмотренные
                        }
                    }
                }
            }*/

            // Реализация алгоритма Дейкстры
            public long[] Dijkstr(int v, out int[] p)
            {
                nov[v] = false; // Помечаем вершину v как просмотренную
                // Создаем матрицу с
                int[,] c = new int[Size, Size];
                for (int i = 0; i < Size; i++)
                {
                    for (int u = 0; u < Size; u++)
                    {
                        if (array[i, u] == 0 || i == u)
                        {
                            c[i, u] = int.MaxValue;
                        }
                        else
                        {
                            c[i, u] = array[i, u];
                        }
                    }
                }
                // Создаем матрицы d и p
                long[] d = new long[Size];
                p = new int[Size];
                for (int u = 0; u < Size; u++)
                {
                    if (u != v)
                    {
                        d[u] = c[v, u];
                        p[u] = v;
                    }
                }
                for (int i = 0; i < Size - 1; i++) // На каждом шаге цикла
                {
                    // Выбираем из множества V\S такую вершину w, что D[w] минимально
                    long min = int.MaxValue;
                    int w = 0;
                    for (int u = 0; u < Size; u++)
                    {
                        if (nov[u] && min > d[u])
                        {
                            min = d[u];
                            w = u;
                        }
                    }
                    nov[w] = false; // помещаем w в множество S
                                    // для каждой вершины из множества V\S определяем кратчайший путь от
                                    // источника до этой вершины
                    for (int u = 0; u < Size; u++)
                    {
                        long distance = d[w] + c[w, u];
                        if (nov[u] && d[u] > distance)
                        {
                            d[u] = distance;
                            p[u] = w;
                        }
                    }
                }
                return d; // в качестве результата возвращаем массив кратчайших путей для заданного источника
            }

            // восстановление пути от вершины a до вершины b для алгоритма Дейкстры
            public void WayDijkstr(int a, int b, int[] p, ref Stack items)
            {
                items.Push(b); // помещаем вершину b в стек
                if (a == p[b]) // если предыдущей для вершины b является вершина а, то
                {
                    items.Push(a); // помещаем а в стек и завершаем восстановление пути
                }
                else  // иначе метод рекурсивно вызывает сам себя для поиска пути от вершины а до вершины, предшествующей вершине b
                {
                    WayDijkstr(a, p[b], p, ref items);
                }
            }

            // реализация алгоритма Флойда
            public double[,] Floyd(out int[,] p)
            {
                int i, j, k;
                // создаем массивы р и а
                double[,] a = new double[Size, Size];
                p = new int[Size, Size];
                for (i = 0; i < Size; i++)
                {
                    for (j = 0; j < Size; j++)
                    {
                        if (i == j)
                        {
                            a[i, j] = 0;
                        }
                        else
                        {
                            if (distances[i, j] == 0)
                            {
                                a[i, j] = int.MaxValue;
                            }
                            else
                            {
                                a[i, j] = distances[i, j];
                            }
                        }
                        p[i, j] = -1;
                    }
                }

                // осуществляем поиск кратчайших путей
                for (k = 0; k < Size; k++)
                {
                    for (i = 0; i < Size; i++)
                    {
                        for (j = 0; j < Size; j++)
                        {
                            double distance = a[i, k] + a[k, j];
                            if (a[i, j] > distance)
                            {
                                a[i, j] = distance;
                                p[i, j] = k;
                            }
                        }
                    }
                }
                return a;  // в качестве результата возвращаем массив кратчайших путей между всеми парами вершин
            }

            // восстановление пути от вершины a до вершины в для алгоритма Флойда
            /*public void WayFloyd(int a, int b, int[,] p, ref Queue items)
            {
                int k = p[a, b];
                // если k <> -1, то путь состоит более чем из двух вершин а и b, и проходит через
                // вершину k, поэтому
                if (k != -1)
                {
                    // рекурсивно восстанавливаем путь между вершинами а и k
                    WayFloyd(a, k, p, ref items);
                    items.Add(k); // помещаем вершину к в очередь
                                  // рекурсивно восстанавливаем путь между вершинами k и b
                    WayFloyd(k, b, p, ref items);
                }
            }*/

            // Добавление новой вершины
            public void AddVertex(int[] out_a, int[] in_a)
            {
                int n = Size + 1;
                if (out_a.Length > n || in_a.Length > n)
                {
                    throw new Exception("Списки должны быть длиной " + n);
                }
                if (out_a[n - 1] != in_a[n - 1])
                {
                    throw new Exception("Последние элементы в обоих списках должны быть одинаковы");
                }
                int[,] a = new int[n, n];  // Новая матрица смежности
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - 1; j++)
                    {
                        a[i, j] = this[i, j];  // Заполняем прошлыми значениями
                    }
                }
                for (int j = 0; j < n; j++)
                {
                    Console.WriteLine(j);
                    a[n - 1, j] = out_a[j];  // Заполняем последнюю строку з
                }
                for (int i = 0; i < n; i++)
                {
                    a[i, n - 1] = in_a[i];
                }
                array = a;  // Присваиваем новую матрицу смежности
            }

            /*public void IsHaveWay(int v1, int v2, int maxLen)
            {
                Console.Write("{0} ", v); // Просматриваем текущую вершину
                nov[v] = false; // Помечаем ее как просмотренную
                // В матрице смежности просматриваем строку с номером v
                for (int u = 0; u < Size; u++)
                {
                    // Если вершины v и u смежные, к тому же вершина u не просмотрена,
                    if (array[v, u] != 0 && nov[u])
                    {
                        Dfs(u); // То рекурсивно просматриваем вершину
                    }
                }
            }*/

            public bool Optimization(int N)
            {
                int[,] p;

                double[,] a = Floyd(out p); // запускаем алгоритм Флойда

                if (GetMax(a) < N)
                {
                    Console.WriteLine("Ничего делать не нужно");
                    return true;
                }

                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (array[i, j] == 0)
                        {
                            array[i, j] = 1;

                            UpdateDistances();

                            a = Floyd(out p); // запускаем алгоритм Флойда
                            double max = GetMax(a);

                            if (max < N)
                            {
                                Console.WriteLine("Получилось. Нужно построить дорогу между городами {0} и {1}. Макс расстояние = {2}", i, j, max);
                                return true;
                            }
                            else
                            {
                                Console.WriteLine("Между городами {0} и {1} не получилось. Макс = {2}", i, j, max);
                                array[i, j] = 0;
                            }
                        }
                    }
                }

                Console.WriteLine("Ничего не получилось");
                return false;
            }

            public bool IsAllLowerThan(double[,] a, int m)
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (a[i, j] > m)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            public double GetMax(double[,] a)
            {
                double max = 0;
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (a[i, j] > max)
                        {
                            max = a[i, j];
                        }
                    }
                }
                return max;
            }

            public void UpdateDistances()
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        if (array[i, j] == 1)
                        {
                            distances[i, j] = Math.Sqrt(Math.Pow(coords[i, 0] - coords[j, 0], 2) + Math.Pow(coords[i, 1] - coords[j, 1], 2));
                        }
                    }
                }
            }

            // метод выводит матрицу расстояний на консольное окно
            public void ShowDistances()
            {
                for (int i = 0; i < Size; i++)
                {
                    for (int j = 0; j < Size; j++)
                    {
                        Console.Write("{0,4}", distances[i, j]);
                    }
                    Console.WriteLine();
                }
            }

        }  // конец вложенного клаcса

        private Node graph; // закрытое поле, реализующее АТД «граф»

        public CoordGraph(string name) // конструктор внешнего класса
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());

                int[,] c = new int[n, 2];
                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    c[i, 0] = int.Parse(mas[1]);
                    c[i, 1] = int.Parse(mas[2]);
                }

                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }

                graph = new Node(a, c);
            }
        }

        // метод выводит матрицу смежности на консольное окно
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Dfs(int v)
        {
            graph.NovSet(); // помечаем все вершины графа как непросмотренные
            graph.Dfs(v); // запускаем алгоритм обхода графа в глубину
            Console.WriteLine();
        }

        /*public void Bfs(int v)
        {
            graph.NovSet(); // помечаем все вершины графа как непросмотренные
            graph.Bfs(v); // запускаем алгоритм обхода графа в ширину
            Console.WriteLine();
        }*/

        public void Dijkstr(int v)
        {
            graph.NovSet(); // помечаем все вершины графа как непросмотренные
            int[] p;
            long[] d = graph.Dijkstr(v, out p); // запускаем алгоритм Дейкстры
                                                // анализируем полученные данные и выводим их на экран
            Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v);
            for (int i = 0; i < graph.Size; i++)
            {
                if (i != v)
                {
                    Console.Write("{0} равна {1}, ", i, d[i]);
                    Console.Write("путь ");
                    if (d[i] != int.MaxValue)
                    {
                        Stack items = new Stack();
                        graph.WayDijkstr(v, i, p, ref items);
                        while (items.Count != 0)
                        {
                            Console.Write("{0} ", items.Pop());
                        }
                    }
                }
                Console.WriteLine();
            }
        }

        /*public void Floyd()
        {
            int[,] p;
            long[,] a = graph.Floyd(out p); // запускаем алгоритм Флойда
            int i, j;
            // анализируем полученные данные и выводим их на экран
            for (i = 0; i < graph.Size; i++)
            {
                for (j = 0; j < graph.Size; j++)
                {
                    if (i != j)
                    {
                        if (a[i, j] == int.MaxValue)
                        {
                            Console.WriteLine("Пути из вершины {0} в вершину {1} не существует", i, j);
                        }
                        else
                        {
                            Console.Write("Кратчайший путь от вершины {0} до вершины {1} равен { 2}, ", i, j, a[i, j]);
                            Console.Write(" путь ");
                            Queue items = new Queue();
                            items.Add(i);
                            graph.WayFloyd(i, j, p, ref items);
                            items.Add(j);
                            while (!items.IsEmpty)
                            {
                                Console.Write("{0} ", items.Take());
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
        }*/

        public void AddVertex(int[] out_a, int[] in_a)
        {
            graph.AddVertex(out_a, in_a);
        }

        // Для заданной вершины v выводит на экран соседние вершины
        public void Neighbouring(int v)
        {
            Console.Write("Вершины соседние с {0} вершиной: ", v);
            //просматриваем строку с номером v в матрице смежности
            for (int i = 0; i < graph.Size; i++)
            {
                //если на пересечении строки v и столбца i стоит не ноль, то вершина i является
                //соседней для вершины v
                if (graph[v, i] != 0)
                {
                    Console.Write("{0} ", i);
                }
            }
            Console.WriteLine();
        }

        public bool IsHaveWay(int v1, int v2, int maxLen)
        {
            graph.NovSet(); // Помечаем все вершины графа как непросмотренные
            int[] p1;
            long[] d1 = graph.Dijkstr(v1, out p1); // Запускаем алгоритм Дейкстры для первой вершин
            graph.NovSet();
            int[] p2;
            long[] d2 = graph.Dijkstr(v2, out p2); // Запускаем алгоритм Дейкстры для второй вершин
            Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v1);
            Console.WriteLine("{0} равна {1}, ", v2, d1[v2]);
            Console.WriteLine("Длина кратчайшие пути от вершины {0} до вершины", v2);
            Console.WriteLine("{0} равна {1}, ", v1, d2[v1]);
            if (d1[v2] < maxLen || d2[v1] < maxLen)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Optimization(int N)
        {
            graph.Optimization(N);
        }

        public void ShowDistances()
        {
            graph.ShowDistances();
        }
    }
}
