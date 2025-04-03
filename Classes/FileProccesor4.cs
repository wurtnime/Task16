using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor4
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor4(string inputFile, string outputFile, string tempFile = null)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile ?? "temp.txt";
        }
        public void ProcessFile(string customInputPath)
        {
            if (!string.IsNullOrEmpty(customInputPath))
            {
                _inputFilePath = customInputPath;
            }
            ProcessFile();
        }
        public void ProcessFile()
        {
            try
            {
                var numbers = ReadNumbers();
                var result = CalculateMinMaxSum(numbers);
                SaveResult(result);
                DisplayResults(numbers, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
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
            var sampleNumbers = new[] { 3.5, -2.1, 15.8, 0.7, -4.3, 10.2 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private double CalculateMinMaxSum(List<double> numbers)
        {
            double min = numbers.Min();
            double max = numbers.Max();
            return min + max;
        }

        private void SaveResult(double result)
        {
            File.WriteAllText(_outputFilePath, result.ToString("F4"));
        }

        private void DisplayResults(List<double> inputNumbers, double result)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Минимальное значение: {inputNumbers.Min():F4}");
            Console.WriteLine($"Максимальное значение: {inputNumbers.Max():F4}");
            Console.WriteLine($"Сумма min и max: {result:F4}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");

        }
    }
}
