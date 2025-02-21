using Prac18_19;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Prac18
{
    /* Замечания.
     * 1) Полную структуру классов и их взаимосвязь продумать самостоятельно.
     * 2) Для абстрактного класса определить, какие методы должны быть абстрактными, а какие обычными.
     * 3) Исходные данные считываются из файла.
     *
     * Задание 3
     * 1) Создать абстрактный класс Издание с методами позволяющим вывести на экран
     * информацию об издании, а также определить, является ли данное издание искомым.
     * 2) Создать производные классы: Книга (название, фамилия автора, год издания,
     * издательство), Статья (название, фамилия автора, название журнала, его номер и год
     * издания), Электронный ресурс (название, фамилия автора, ссылка, аннотация) со своими
     * методами вывода информации на экран.
     * 3) Создать каталог (массив) из n изданий, вывести полную информацию из каталога, а также
     * организовать поиск изданий по фамилии автора.
     * 
     * 19: В абстрактном классе Издание реализовать метод CompareTo так, чтобы
     * можно было отсортировать каталог изданий по фамилии автора.
     */
    internal class Program
    {
        static void Print(List<Publication> objects)
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("Список объектов пуст.");
            }
            else
            {
                Console.WriteLine("Список объектов:");
                foreach (Publication item in objects)
                {
                    Console.Write(item);
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
        }

        static void SearchAuthor(List<Publication> objects, string surname)
        {
            if (objects.Count == 0)
            {
                Console.WriteLine("Список объектов пуст. Нечего искать.");
            }
            else
            {
                Console.WriteLine("Результаты поиска:");
                foreach (Publication item in objects)
                {
                    if (item.IsAuthor(surname))
                    {
                        Console.Write(item);
                        Console.WriteLine();
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            List<Publication> objects = new List<Publication>();
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream f = new FileStream(@"input.dat",
                FileMode.OpenOrCreate))
            {
                if (f.Length != 0)
                {
                    objects = (List<Publication>)formatter.Deserialize(f);
                }
            }

            Print(objects);
            objects.Sort();
            Print(objects);

            SearchAuthor(objects, "");

            using (FileStream f = new FileStream(@"input.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(f, objects);
            }
        }
    }
}
