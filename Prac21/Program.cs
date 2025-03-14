using System;
using System.IO;

// Практикум №21
namespace Prac21
{
    class Program
    {
        static void Main(string[] args)
        {
            /* I. В файле input.txt хранится последовательность целых чисел. По входной
             * последовательности построить дерево бинарного поиска и найти для него:
             * 13. сумму значений узлов в дереве, имеющих только одно правое поддерево.
             */

            BinaryTree tree = new BinaryTree();

            int[] mas = { 10, 7, 25, 31, 18, 6, 3, 22, 8, 9 };
            foreach (int item in mas)
            {
                tree.Add(item);
            }
            tree.Preorder();
            Console.WriteLine();
            Console.WriteLine("Сумма = {0}", tree.OnlyRigthSum());

            // Считываем данные из файла в список
            /*using (StreamReader fileIn = new StreamReader(@"input.txt"))
            {
                string line = fileIn.ReadToEnd();
                char[] sep = { ' ', '\n', '\t', '\r' };
                string[] data = line.Split(sep);
                foreach (string item in data)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        tree.Add(int.Parse(item));
                    }
                }
            }*/


        }
    }
}
