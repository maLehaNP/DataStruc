using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

// Практикум №21
namespace Prac21
{
    class Program
    {
        public static BinaryTree ReadTree(string filename)
        {
            BinaryTree tree = new BinaryTree();
            // Считываем данные из файла в список
            using (StreamReader fileIn = new StreamReader(@filename))
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
            }
            return tree;
        }

        static void Main(string[] args)
        {
            /* I. В файле input.txt хранится последовательность целых чисел. По входной
             * последовательности построить дерево бинарного поиска и найти для него:
             * 13. сумму значений узлов в дереве, имеющих только одно правое поддерево.
             */

            BinaryTree tree1 = ReadTree("input1.txt");
            BinaryTree tree2 = ReadTree("input2.txt");
            BinaryTree tree3 = ReadTree("input3.txt");
            BinaryTree tree4 = ReadTree("input4.txt");

            tree1.Preorder();
            Console.WriteLine();
            Console.WriteLine("Сумма = {0}", tree1.OnlyRigthSum());
            Console.WriteLine();

            tree4.Preorder();
            Console.WriteLine();
            Console.WriteLine("Сумма = {0}", tree4.OnlyRigthSum());
            Console.WriteLine();

        }
    }
}
