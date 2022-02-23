using System;
using System.IO;

namespace LabWorks_II
{
    class Program
    {
        static void Main(string[] args)
        {
            directCreator();
            writeToFile(textReader(), "input", true);
            writeToFile(textEditor(readFromFile("input")), "output", false);
            printer("input", "output");
        }

        static void directCreator()
        {
            string dirName = "C:\\Users\\mitya\\Documents\\TextFilesLab";
            if (Directory.Exists(dirName))
            {
                Console.WriteLine("Такой каталог уже есть, будем работать с ним.");
            }
            else
            {
                Console.WriteLine("Такого каталога нет, создаём...");
                Directory.CreateDirectory(dirName);
            }  
        }

        static void writeToFile(string text, string fileName, bool appendText)
        {
            string path = $"C:\\Users\\mitya\\Documents\\TextFilesLab\\{fileName}.txt";
            StreamWriter writeText = new StreamWriter(path, appendText);
            writeText.WriteLine(text);
            writeText.Close();
        }

        static string textReader()
        {
            Console.Write("Введите сообщение: ");
            string message = "";
            ConsoleKeyInfo key;
            while ((key = Console.ReadKey()).Key != ConsoleKey.Escape)
            {
                if (key.Key == ConsoleKey.Enter)
                {
                    message += " \n";
                    Console.WriteLine();
                }
                else
                {
                    message += key.KeyChar;
                }
            }
            return message;
        }

        static string readFromFile(string fileName)
        {
            string path = $"C:\\Users\\mitya\\Documents\\TextFilesLab\\{fileName}.txt";

            StreamReader sr = new StreamReader(path);
            string message = sr.ReadToEnd();
            sr.Close();

            return message;
        }

        static string textEditor(string inputText)
        {
            string[] splitters = new string[] { ".\n", ".", "\n" };
            string[] sentences = emptyRemover(inputText).Split(splitters, StringSplitOptions.RemoveEmptyEntries);

            for (int sent = 0; sent < sentences.Length; sent++)
            {
                if (sentences[sent] != "" && sentences[sent] != " ")
                    sentences[sent] = maxFinder(sentences, sent);

                else if (sentences[sent] == "\n")
                    sentences[sent] = "";
            }

            return joiner(sentences);
        }

        static string modifier(string piece)
        {
            piece = piece.Replace(",", "");
            piece = piece.Replace(";", "");
            piece = piece.Replace(".", "");

            return piece;
        }

        static string maxFinder(string[] sentences, int counter)
        {
            string[] words = sentences[counter].Split(' ');
            int theLongest = modifier(words[0]).Length;
            string theLongestStr = modifier(words[0]);
            for (int wordCount = 0; wordCount < words.Length; wordCount++)
            {
                if (modifier(words[wordCount]).Length > theLongest)
                {
                    theLongest = modifier(words[wordCount]).Length;
                    theLongestStr = modifier(words[wordCount]);
                }
            }
            return $"{theLongest} {theLongestStr} {sentences[counter]}";
        }

        static string emptyRemover(string input)
        {
            while(input.Contains(".\n"))
            {
                input.Replace(".\n", ".");
            }

            return input;
        }

        static string joiner(string[] array)
        {
            string text = "";
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] != "" && array[i] != " ")
                {
                    text += $"{array[i]}\n";
                }
            }
            return text;
        }

        static void printer(string firstFileName, string secondFileName)
        {
            Console.WriteLine($"Содержание исходного файла: \n{readFromFile(firstFileName)}\n");
            Console.WriteLine($"Содержание отредактированного файла: \n{readFromFile(secondFileName)}\n");
        }
    }
}
