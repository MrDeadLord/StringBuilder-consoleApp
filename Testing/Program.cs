using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Lesson_1
{
    class Lesson_5
    {
        static void TestA(StringBuilder sent)
        {
            var chekA = new Regex(@"\b([a-z]{1,4})\b", RegexOptions.IgnoreCase);

            Console.WriteLine("a) Вывести только те слова, которые содержат не более 4х букв:");

            foreach (Match matchA in chekA.Matches(sent.ToString()))
            {
                Console.WriteLine(matchA.Groups[1].Value);
            }
        }

        static void TestB(StringBuilder sent)
        {
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("b) Удалить из сообщения все слова, которые заканчиваются на за-данный(e) символ:");

            var chekB = new Regex(@"\w+[e]\b");

            StringBuilder sentDel = new StringBuilder(sent.ToString());       //Создаем новый StringBuilder, что бы потом не восстанавливать старый

            foreach (var match in chekB.Matches(sentDel.ToString()))
            {
                int pos = sentDel.ToString().IndexOf(match.ToString());       //Обязательно сделать matchB.ToString() для перевода object в string
                sentDel.Remove(pos, match.ToString().Length + 1);                //Удаляем( позиция первой буквы найденого слова, длина слова +1(пробел) )
            }

            Console.WriteLine(sentDel);
        }

        static void TestC(StringBuilder sent)
        {
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("c) Найти самое длинное слово сообщения:");

            var chekC = new Regex(@"\w+");

            int longWord = 0;
            string word = "";

            foreach (var a in chekC.Matches(sent.ToString()))
            {
                if (a.ToString().Length > longWord)
                {
                    longWord = a.ToString().Length;
                    word = a.ToString();
                }
            }

            Console.WriteLine(word);
        }

        static void TestD(StringBuilder sent)
        {
            Console.WriteLine();
            Console.WriteLine("--------------");
            Console.WriteLine("d) Найти все самые длинные слова сообщения:");

            var chek = new Regex(@"\w+");

            int wordLength = 0;
            string word = "";


            foreach (var a in chek.Matches(sent.ToString()))
            {
                if (a.ToString().Length > wordLength)
                {
                    wordLength = a.ToString().Length;
                    word = a.ToString();
                }
            }

            Console.WriteLine(word);
            int pos = sent.ToString().IndexOf(word);
            sent.Remove(pos, word.Length);

            word = "";

            foreach (var a in chek.Matches(sent.ToString()))
            {
                if (a.ToString().Length == wordLength)
                {
                    word = a.ToString();
                    Console.WriteLine(word);
                }
            }
        }

        static void Main()
        {
            StringBuilder sent = new StringBuilder("There was some strange guy which tryed to kill the rabbit.");

            Console.WriteLine("There is the sentence:");
            Console.WriteLine(sent);

            TestA(sent);
            TestB(sent);
            TestC(sent);
            TestD(sent);

            Console.ReadKey();
        }
    }
}
