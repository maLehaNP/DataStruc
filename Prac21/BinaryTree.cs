﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Prac21
{
    class BinaryTree  // Класс, реализующий АТД «дерево бинарного поиска»
    {
        // Вложенный класс, отвечающий за узлы и операции допустимы для дерева бинарного поиска
        private class Node
        {
            public object inf;  // информационное поле
            public Node left;  // ссылка на левое поддерево
            public Node rigth;  // ссылка на правое поддерево

            // конструктор вложенного класса, создает узел дерева
            public Node(object nodeInf)
            {
                inf = nodeInf;
                left = null;
                rigth = null;
            }

            // добавляет узел в дерево так, чтобы дерево оставалось деревом бинарного поиска
            public static void Add(ref Node r, object nodeInf)
            {
                if (r == null)
                {
                    r = new Node(nodeInf);
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(nodeInf) > 0)
                    {
                        Add(ref r.left, nodeInf);
                    }
                    else
                    {
                        Add(ref r.rigth, nodeInf);
                    }
                }
            }

            public static void Preorder(Node r)  // прямой обход дерева
            {
                if (r != null)
                {
                    Console.Write("{0} ", r.inf);
                    Preorder(r.left);
                    Preorder(r.rigth);
                }
            }

            public static void Inorder(Node r)  // симметричный обход дерева
            {
                if (r != null)
                {
                    Inorder(r.left);
                    Console.Write("{0} ", r.inf);
                    Inorder(r.rigth);
                }
            }

            public static void Postorder(Node r)  // обратный обход дерева
            {
                if (r != null)
                {
                    Postorder(r.left);
                    Postorder(r.rigth);
                    Console.Write("{0} ", r.inf);
                }
            }

            //поиск ключевого узла в дереве
            public static void Search(Node r, object key, out Node item)
            {
                if (r == null)
                {
                    item = null;
                }
                else
                {
                    if (((IComparable)(r.inf)).CompareTo(key) == 0)
                    {
                        item = r;
                    }
                    else
                    {
                        if (((IComparable)(r.inf)).CompareTo(key) > 0)
                        {
                            Search(r.left, key, out item);
                        }
                        else
                        {
                            Search(r.rigth, key, out item);
                        }
                    }
                }
            }

            // методы Del и Delete позволяют удалить узел в дереве так, чтобы дерево при этом оставалось деревом бинарного поиска
            private static void Del(Node t, ref Node tr)
            {
                if (tr.rigth != null)
                {
                    Del(t, ref tr.rigth);
                }
                else
                {
                    t.inf = tr.inf;
                    tr = tr.left;
                }
            }

            public static void Delete(ref Node t, object key)
            {
                if (t == null)
                {
                    throw new Exception("Данное значение в дереве отсутствует");
                }
                else
                {
                    if (((IComparable)(t.inf)).CompareTo(key) > 0)
                    {
                        Delete(ref t.left, key);
                    }
                    else
                    {
                        if (((IComparable)(t.inf)).CompareTo(key) < 0)
                        {
                            Delete(ref t.rigth, key);
                        }
                        else
                        {
                            if (t.left == null)
                            {
                                t = t.rigth;
                            }
                            else
                            {
                                if (t.rigth == null)
                                {
                                    t = t.left;
                                }
                                else
                                {
                                    Del(t, ref t.left);
                                }
                            }
                        }
                    }
                }
            }

            // Возвращает сумму значений узлов в дереве, имеющих только одно правое поддерево
            public static int OnlyRigthSum(Node r, int sum)
            {
                Console.WriteLine("{0} ", r.inf);
                if (r.left != null)
                {
                    int sum1 = sum;
                    sum += OnlyRigthSum(r.left, sum1);
                    if (r.rigth != null)
                    {
                        sum += OnlyRigthSum(r.rigth, sum1);
                    }
                }
                else if (r.rigth != null)
                {
                    Console.WriteLine("имеет только правое поддерево");
                    sum = sum + OnlyRigthSum(r.rigth, sum);
                    sum = sum + (int)r.inf;
                }
                Console.WriteLine("{0} sum={1}", r.inf, sum);
                return sum;

                /*if (r != null)
                {
                    Console.WriteLine("{0}", r.inf);
                    if (r.left == null && r.rigth != null)
                    {
                        Console.WriteLine("имеет только правое поддерево");
                        sum += OnlyRigthSum(r.rigth, sum);
                        sum += (int)r.inf;
                    }
                    else
                    {
                        sum = OnlyRigthSum(r.left, sum) + OnlyRigthSum(r.rigth, sum);
                    }
                    Console.WriteLine("{0} sum={1}", r.inf, sum);
                }
                return sum;*/
            }

            // Возвращает сумму узлов с четным значением, расположенных на k-ом уровне
            public static int LevelSum(Node r, int level, int curLevel, int sum)
            {
                if (r != null)
                {
                    Console.WriteLine("{0} level={1}", r.inf, curLevel);
                    if (curLevel == level)
                    {
                        if ((int)r.inf % 2 == 0)
                        {
                            Console.WriteLine("на уровне {1} четное", r.inf, curLevel);
                            sum = sum + (int)r.inf;
                        }
                        return sum;
                    }
                    else
                    {
                        sum = LevelSum(r.left, level, curLevel+1, sum) + LevelSum(r.rigth, level, curLevel+1, sum);
                    }
                }
                return sum;
            }

        }  // конец вложенного класса

        Node tree;  // ссылка на корень дерева

        // свойство позволяет получить доступ к значению информационного поля корня дерева
        public object Inf
        {
            set { tree.inf = value; }
            get { return tree.inf; }
        }

        public BinaryTree()  // открытый конструктор
        {
            tree = null;
        }

        private BinaryTree(Node r)  // закрытый конструктор
        {
            tree = r;
        }

        public void Add(object nodeInf)  // добавление узла в дерево
        {
            Node.Add(ref tree, nodeInf);
        }

        // организация различных способов обхода дерева
        public void Preorder()
        {
            Node.Preorder(tree);
        }
        public void Inorder()
        {
            Node.Inorder(tree);
        }
        public void Postorder()
        {
            Node.Postorder(tree);
        }

        // поиск ключевого узла в дереве
        public BinaryTree Search(object key)
        {
            Node r;
            Node.Search(tree, key, out r);
            BinaryTree t = new BinaryTree(r);
            return t;
        }

        // удаление ключевого узла в дереве
        public void Delete(object key)
        {
            Node.Delete(ref tree, key);
        }

        // Возвращает сумму значений узлов в дереве, имеющих только одно правое поддерево
        public object OnlyRigthSum()
        {
            return Node.OnlyRigthSum(tree, 0);
        }

        // Возвращает сумму узлов с четным значением, расположенных на k-ом уровне
        public object LevelSum(int level)
        {
            return Node.LevelSum(tree, level, 1, 0);
        }
    }
}
