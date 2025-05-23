namespace Prac9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task2();
        }

        /// <summary>
        /// Выводит содержимое файла построчно.
        /// </summary>
        /// <param name="path"></param>
        static void FilePrint(string path)
        {
            using (StreamReader file = new StreamReader(path))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    Console.Out.WriteLine(line);
                }
            }
            Console.Out.WriteLine();
        }

        static void Task2()
        {
            /* 13. Дан файл, компонентами которого являются целые числа. Переписать в новый файл
             * сначала все отрицательные компоненты из первого, потом все положительные.
             */

            Random rand = new Random();

            int[] randAr = new int[50];
            int index = 0;
            for (int i = -25; i <= 24; i++)
            {
                randAr[index] = i;
                index++;
            }
            rand.Shuffle(randAr);

            using (StreamWriter fileIn = new StreamWriter("D:\\Prac9\\ints.txt", false))
            {
                for (int i = 0; i < 50; i++)
                {
                    fileIn.WriteLine(randAr[i]);
                }
            }
            FilePrint("D:\\Prac9\\ints");

            using (StreamReader fileIn = new StreamReader("D:\\Prac9\\ints.txt"))
            {
                using (StreamWriter fileOut = new StreamWriter("D:\\Prac9\\newInts.txt", false))
                {
                    string digit;
                    string[] positivs = new string[25];
                    int i = 0;
                    while ((digit = fileIn.ReadLine()) != null)
                    {
                        if (int.Parse(digit) < 0) fileOut.WriteLine(digit);
                        else {
                            positivs[i] = digit;
                            i++;
                        }
                    }
                    foreach (string pos in positivs)
                    {
                        fileOut.WriteLine(pos);
                    }
                }
            }
            FilePrint("D:\\Prac9\\newInts");
        }
    }
}
