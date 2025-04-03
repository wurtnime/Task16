using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor19
    {
        private string _inputFilePath;
        private readonly string _evenOutputFilePath;
        private readonly string _oddOutputFilePath;

        public FileProccesor19(string inputFile, string evenOutputFile, string oddOutputFile)
        {
            _inputFilePath = inputFile;
            _evenOutputFilePath = evenOutputFile;
            _oddOutputFilePath = oddOutputFile;
        }

        public void ProcessFile()
        {
            try
            {
                var numbers = ReadNumbers();
                var (evenNumbers, oddNumbers) = FilterEvenOddNumbers(numbers);
                SaveResults(evenNumbers, oddNumbers);
                DisplayResults(numbers, evenNumbers, oddNumbers);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        public void ProcessFile(string customInputPath)
        {
            if (!string.IsNullOrEmpty(customInputPath))
            {
                _inputFilePath = customInputPath;
            }
            ProcessFile();
        }

        private List<int> ReadNumbers()
        {
            if (!File.Exists(_inputFilePath))
            {
                CreateSampleFile();
                Console.WriteLine($"Создан пример файла: {_inputFilePath}");
            }

            return File.ReadAllLines(_inputFilePath)
                     .Where(line => !string.IsNullOrWhiteSpace(line))
                     .Select(line => int.Parse(line.Trim()))
                     .ToList();
        }

        private void CreateSampleFile()
        {
            var sampleNumbers = new[] { 2, 5, 8, 3, 10, 7, 4, 9, 6, 11 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private (List<int> evenNumbers, List<int> oddNumbers) FilterEvenOddNumbers(List<int> numbers)
        {
            var evenNumbers = numbers.Where(n => n % 2 == 0).ToList();
            var oddNumbers = numbers.Where(n => n % 2 != 0).ToList();
            return (evenNumbers, oddNumbers);
        }

        private void SaveResults(List<int> evenNumbers, List<int> oddNumbers)
        {
            File.WriteAllLines(_evenOutputFilePath, evenNumbers.Select(n => n.ToString()));
            File.WriteAllLines(_oddOutputFilePath, oddNumbers.Select(n => n.ToString()));
        }

        private void DisplayResults(List<int> inputNumbers, List<int> evenNumbers, List<int> oddNumbers)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Четных чисел: {evenNumbers.Count}");
            Console.WriteLine($"Список четных чисел:\n{string.Join(", ", evenNumbers)}");
            Console.WriteLine($"\nНечетных чисел: {oddNumbers.Count}");
            Console.WriteLine($"Список нечетных чисел:\n{string.Join(", ", oddNumbers)}");

            Console.WriteLine($"Четные числа сохранены в: {Path.GetFullPath(_evenOutputFilePath)}");
            Console.WriteLine($"Содержимое файла четных чисел:\n{File.ReadAllText(_evenOutputFilePath)}");
            Console.WriteLine($"\nНечетные числа сохранены в: {Path.GetFullPath(_oddOutputFilePath)}");
            Console.WriteLine($"Содержимое файла нечетных чисел:\n{File.ReadAllText(_oddOutputFilePath)}");
        }
    }
}
