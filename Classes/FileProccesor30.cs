using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor30
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private readonly string _tempFilePath;

        public FileProccesor30(string inputFile, string outputFile, string tempFile)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile;
        }

        public void ProcessFile()
        {
            try
            {
                var numbers = ReadNumbers();
                ValidateNumbers(numbers);
                var rearranged = RearrangeNumbers(numbers);
                SaveResult(rearranged);
                DisplayResults(numbers, rearranged);
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
            var sampleNumbers = new[] { 3, -2, 4, -5, 1, -6, 2, -1 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private void ValidateNumbers(List<int> numbers)
        {
            if (numbers.Any(n => n == 0))
                throw new ArgumentException("Файл содержит нули, что недопустимо по условию");

            int positiveCount = numbers.Count(n => n > 0);
            int negativeCount = numbers.Count(n => n < 0);

            if (positiveCount != negativeCount)
                throw new ArgumentException("Количество положительных и отрицательных чисел не совпадает");
        }

        private List<int> RearrangeNumbers(List<int> numbers)
        {
            var odds = numbers.Where(n => n % 2 != 0).ToList();
            var evens = numbers.Where(n => n % 2 == 0).ToList();

            var result = new List<int>();
            result.AddRange(odds);
            result.AddRange(evens);

            File.WriteAllLines(_tempFilePath, result.Select(n => n.ToString()));

            return result;
        }

        private void SaveResult(List<int> rearrangedNumbers)
        {
            File.WriteAllLines(_outputFilePath, rearrangedNumbers.Select(n => n.ToString()));
        }

        private void DisplayResults(List<int> inputNumbers, List<int> outputNumbers)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Положительных: {inputNumbers.Count(n => n > 0)}");
            Console.WriteLine($"Отрицательных: {inputNumbers.Count(n => n < 0)}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Нечетные и четные числа:\n{string.Join(", ", outputNumbers)}");
            Console.WriteLine($"Проверка: {CheckOrder(outputNumbers)}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }

        private string CheckOrder(List<int> numbers)
        {
            bool foundEven = false;
            foreach (var num in numbers)
            {
                if (num % 2 == 0)
                {
                    foundEven = true;
                }
                else if (foundEven)
                {
                    return "Ошибка: Четное число перед нечетным!";
                }
            }
            return "Порядок соблюден: сначала нечетные, потом четные!";
        }
    }
}

