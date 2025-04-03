using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor28
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private readonly string _tempFilePath;

        public FileProccesor28(string inputFile, string outputFile, string tempFile)
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

            if (numbers.Count % 4 != 0)
                throw new ArgumentException("Количество чисел в файле не делится на 4");
        }

        private List<int> RearrangeNumbers(List<int> numbers)
        {
            var positives = numbers.Where(n => n > 0).ToList();
            var negatives = numbers.Where(n => n < 0).ToList();

            var result = new List<int>();
            int pairCount = numbers.Count / 4 * 2;

            for (int i = 0; i < pairCount; i++)
            {
                if (i * 2 < positives.Count)
                {
                    result.Add(positives[i * 2]);
                    if (i * 2 + 1 < positives.Count)
                        result.Add(positives[i * 2 + 1]);
                }

                if (i * 2 < negatives.Count)
                {
                    result.Add(negatives[i * 2]);
                    if (i * 2 + 1 < negatives.Count)
                        result.Add(negatives[i * 2 + 1]);
                }
            }

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

            Console.WriteLine($"Числа в порядке 2+,2-:\n{string.Join(", ", outputNumbers)}");
            Console.WriteLine($"Проверка: {CheckAlternation(outputNumbers)}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }

        private string CheckAlternation(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i += 2)
            {
                if (i + 1 >= numbers.Count) break;

                if (i % 4 == 0 && (numbers[i] <= 0 || numbers[i + 1] <= 0))
                    return "Ошибка: ожидались два положительных числа";

                if (i % 4 == 2 && (numbers[i] >= 0 || numbers[i + 1] >= 0))
                    return "Ошибка: ожидались два отрицательных числа";
            }
            return "Чередование 2+/2- соблюдено - успех!";
        }
    }
}
