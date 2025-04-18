namespace Prac8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Task3();
        }

        static void Task3()
        {
            /* 
             * III. Дана строка, в которой содержится осмысленное текстовое сообщение. Слова
             * сообщения разделяются пробелами и знаками препинания.
             * 13. Найти самое короткое слово сообщения.
             */
            string str = "Златая цепь на дубе том: днём ночью кот учёный Всё ходит по цепи кругом; Идёт направо - песнь заводит, Налево - сказку говорит.";
            char[] div = { ' ', ':', ';', '-', ',', '.', '?', '!', '"', '(', ')' };
            String[] strSp = str.Split(div, StringSplitOptions.RemoveEmptyEntries);
            int strMinLen = strSp[0].Length;
            int strMinIndex = 0;
            for (int i = 1; i < strSp.Length; i++)
            {
                if (strSp[i].Length < strMinLen)
                {
                    strMinLen = strSp[i].Length;
                    strMinIndex = i;
                }
            }
            Console.WriteLine($"Самое короткое слово: {strSp[strMinIndex]}");
        }
    }
}
