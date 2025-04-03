using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor6
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor6(string inputFile, string outputFile, string tempFile)
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
                var result = CalculateResults(numbers);
                SaveResult(result);
                DisplayResults(numbers, result);
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


        private List<double> ReadNumbers()
        {
            if (!File.Exists(_inputFilePath))
            {
                CreateSampleFile();
                Console.WriteLine($"Создан пример файла: {_inputFilePath}");
            }

            return File.ReadAllLines(_inputFilePath)
                     .Where(line => !string.IsNullOrWhiteSpace(line))
                     .Select(line => double.Parse(line.Trim()))
                     .ToList();
        }

        private void CreateSampleFile()
        {
            var sampleNumbers = new[] { 1.5, -2.3, 3.7, -4.2, 5.1 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private (double sumAbs, double productSquared) CalculateResults(List<double> numbers)
        {
            double sum = numbers.Sum();
            double product = numbers.Aggregate(1.0, (acc, val) => acc * val);

            return (Math.Abs(sum), product * product);
        }

        private void SaveResult((double sumAbs, double productSquared) result)
        {
            var output = new[]
            {
                $"Модуль суммы: {result.sumAbs}",
                $"Квадрат произведения: {result.productSquared}"
            };
            File.WriteAllLines(_outputFilePath, output);
        }

        private void DisplayResults(List<double> inputNumbers, (double sumAbs, double productSquared) result)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Модуль суммы компонент: {result.sumAbs}");
            Console.WriteLine($"Квадрат произведения компонент: {result.productSquared}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
