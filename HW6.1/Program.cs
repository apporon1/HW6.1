using System;
using System.IO;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        string filePath = string.Empty;

        while (true)
        {
            Console.WriteLine("Введите путь к файлу: ");
            filePath = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    try
                    {
                        numbers.Add(int.Parse(line));
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine($"Неверный формат данных: '{line}' будет пропущен.");
                    }
                }
                break;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден. Пожалуйста, проверьте путь и попробуйте снова.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка ввода/вывода: {ex.Message}");
            }
        }

        Console.WriteLine("Данные из файла:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}