using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Homework_regex_4_tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            if (args.Length > 0)
            {
                string inputFilename = args[0]; // создали строку для чтения
                string outputFilename = "solution.txt"; // создали строку для записи файла

                try
                {
                    using (StreamReader reader = new StreamReader(inputFilename))
                    {
                        using (StreamWriter writer = new StreamWriter(outputFilename, true))
                        {
                            string line;
                            while ((line = reader.ReadLine()) != null)
                            {
                                try
                                {
                                    Match match = Regex.Match(line, @"(\d+)\s*([-+*/])\s*(\d+)\s*=");
                                    if (match.Success)
                                    {
                                        int leftOperand = int.Parse(match.Groups[1].Value);
                                        char oper = match.Groups[2].Value[0];
                                        int rightOperand = int.Parse(match.Groups[3].Value);
                                        int result;
                                        switch (oper)
                                        {
                                            case '+': result = leftOperand + rightOperand; break;
                                            case '-': result = leftOperand - rightOperand; break;
                                            case '*': result = leftOperand * rightOperand; break;
                                            case '/': result = leftOperand / rightOperand; break;
                                            default: throw new InvalidOperationException($"Неизвестный оператор");
                                        }
                                        writer.WriteLine($"{line.Trim()} {result}");
                                    }
                                    else
                                    {
                                        writer.WriteLine($"{line.Trim()} Ошибка: неверный формат");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    writer.WriteLine($"{line.Trim()} Ошибка: {ex.Message}");
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Аргументы командной строки не переданы");
            }

            Console.WriteLine("Задание 2");

            if (args.Length > 0)
            {
                for (int i = 0; i < args.Length; i++)
                {
                    string inputFile = args[i];
                    string outputFile = $"solution{i}.txt";
                    try
                    {
                        using (StreamReader reader = new StreamReader(inputFile))
                        {
                            using (StreamWriter writer = new StreamWriter(outputFile, true))
                            {
                                string line;
                                while ((line = reader.ReadLine()) != null)
                                {
                                    try
                                    {
                                        Match match = Regex.Match(line, @"(\d+)\s*([-+*/])\s*(\d+)\s*=");
                                        if (match.Success)
                                        {
                                            int leftOperand = int.Parse(match.Groups[1].Value);
                                            char oper = match.Groups[2].Value[0];
                                            int rightOperand = int.Parse(match.Groups[3].Value);
                                            int result;
                                            switch (oper)
                                            {
                                                case '+': result = leftOperand + rightOperand; break;
                                                case '-': result = leftOperand - rightOperand; break;
                                                case '*': result = leftOperand * rightOperand; break;
                                                case '/': result = leftOperand / rightOperand; break;
                                                default: throw new InvalidOperationException($"Неизвестный оператор");
                                            }
                                            writer.WriteLine($"{line.Trim()} {result}");
                                        }
                                        else
                                        {
                                            writer.WriteLine($"{line.Trim()} Ошибка: неверный формат");
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        writer.WriteLine($"{line.Trim()} Ошибка: {ex.Message}");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"Ошибка: {ex.Message}");
                    }

                }
            }
            else
            {
                Console.WriteLine("Нет аргументов");
            }

            Console.WriteLine("Задание 3");

            if (args.Length > 0)
            {
                string directory = args[0]; // аргумент командной строки - директория
                if (Directory.Exists(directory)) // проверка
                {
                    Console.WriteLine("Подкаталоги:");
                    string[] dirs = Directory.GetDirectories(directory); // получаем подкаталоги
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s); //вывод
                    }
                    Console.WriteLine();
                    Console.WriteLine("Файлы:"); // получаем спискок файлов
                    string[] files = Directory.GetFiles(directory);
                    foreach (string s in files)
                    {
                        Console.WriteLine(s);//вывод
                    }
                }
            }
            else
            {
                Console.WriteLine(Directory.GetCurrentDirectory());
            }


         
        }

    }
}

