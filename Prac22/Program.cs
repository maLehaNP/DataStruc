using System;
using System.IO;

namespace Prac22
{
    class Program
    {
        static void Main(string[] args)
        {
            /* I. В входном файле указывается количество вершин графа/орграфа и матрица смежности:
             * Для заданного орграфа:
             * 13. добавить новую вершину.
             */
            Graph g1 = new Graph(@"input1.txt");

            g1.Show();
            g1.AddVertex(new int[] { 0, 50, 0, 0, 75, 0 }, new int[] { 10, 0, 0, 0, 0, 0 });
            g1.Show();
        }
    }
}
