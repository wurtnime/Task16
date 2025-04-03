using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor8
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor8(string inputFile, string outputFile, string tempFile = null)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile ?? "temp.txt";
        }

        public void ProcessFile()
        {
            try
            {
                var numbers = ReadNumbers();
                var evenCount = CountEvenNumbers(numbers);
                SaveResult(evenCount);
                DisplayResults(numbers, evenCount);
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
            var sampleNumbers = new[] { 4, 7, 16, 25, 10, 36, 15, 64, 100, 51 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private int CountEvenNumbers(List<int> numbers)
        {
            return numbers.Count(n => n % 2 == 0);
        }

        private void SaveResult(int evenCount)
        {
            File.WriteAllText(_outputFilePath, evenCount.ToString());
        }

        private void DisplayResults(List<int> numbers, int evenCount)
        {
            Console.WriteLine($"Всего чисел: {numbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", numbers)}");

            Console.WriteLine($"Количество чётных чисел: {evenCount}");
            Console.WriteLine($"Чётные числа: {string.Join(", ", numbers.Where(n => n % 2 == 0))}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
