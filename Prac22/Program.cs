using System;
using System.IO;

namespace Prac22
{
    class Program
    {
        /*public static BinaryTree ReadTree(string filename)
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

        public static AVLTree ReadAVLTree(string filename)
        {
            AVLTree tree = new AVLTree();
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
        }*/

        static void Main(string[] args)
        {
            /* I. В входном файле указывается количество вершин графа/орграфа и матрица смежности:
             * Для заданного орграфа:
             * 13. добавить новую вершину.
             */

            //BinaryTree tree2 = ReadTree("input2.txt");
        }
    }
}
