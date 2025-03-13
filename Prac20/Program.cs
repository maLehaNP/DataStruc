 using System;
using System.IO;

namespace Prac20
{
    /* Практикум № 20
     * 
     *     Реализовать типизированный однонаправленный список с тремя точками доступ (head,
     * tail, temp) для хранения и обработки целых чисел. Для списка должны быть реализованы
     * базовые операции: инициализация списка, добавление элемента в «хвост» списка, извлечение
     * элемента из «головы» списка, просмотр элементов в списке, а также дополнительные
     * операции в соответствии поставленной задачей.
     *     При решении задачи целые числа считываются из файла input.txt. Данные в файле
     * хранятся в неструктурированном виде. Количество чисел в файле не менее 50.
     *     Результат выводится в файл output.txt в структурированном виде – вначале исходная
     * последовательность чисел через пробел, а затем с новой строки итоговая последовательность
     * чисел также через пробел.
     *     При решении задачи дополнительные структуры данных не используются. Все
     * действия выполняются над текущем списком.
     * 
     *     13. Вычислить среднее арифметическое значение всех элементов, хранящихся в списке. Перед
     * каждым элементом из списка, значение которого больше среднего арифметического,
     * вставить элемент со значением х.
     */
    class Program
    {

        static void Main(string[] args)
        {
            List list = new List(); //инициализируем список

            //считываем данные из файла в список
            using (StreamReader fileIn = new StreamReader(@"input.txt"))
            {
                string line = fileIn.ReadToEnd();
                char[] sep = { ' ', '\n', '\t', '\r' };
                string[] data = line.Split(sep);
                foreach (string item in data)
                {
                    if (!string.IsNullOrEmpty(item))
                    {
                        list.AddEnd(int.Parse(item));
                    }
                }
            }
            list.Show();
            using (StreamWriter fileOut = new StreamWriter(@"output.txt"))
            {
                fileOut.WriteLine(list.ToString());
            }

            Console.Write("Введите x: ");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine("Среднее арифметическое списка: " + list.Mean());
            list.doTask(x);

            list.Show(); //выводим измененные данные из списка на экран
            using (StreamWriter fileOut = new StreamWriter(@"output.txt", true))
            {
                fileOut.WriteLine(list.ToString());
            }
        }
    }
}
