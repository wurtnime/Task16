using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor26
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor26(string inputFile, string outputFile, string tempFile)
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
                double difference = CalculateCubesDifference(numbers);
                SaveResult(difference);
                DisplayResults(numbers, difference);
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
            var sampleNumbers = new[] { 2.5, 1.3, 4.0, 3.2, 5.1 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private double CalculateCubesDifference(List<double> numbers)
        {
            if (numbers.Count < 2)
                throw new InvalidOperationException("Файл должен содержать как минимум 2 числа");

            double sumOfCubes = numbers.Sum(n => Math.Pow(n, 3));
            double difference = numbers[0] * numbers[0] * numbers[0];

            for (int i = 1; i < numbers.Count; i++)
            {
                difference -= Math.Pow(numbers[i], 3);
            }

            return difference;
        }

        private void SaveResult(double result)
        {
            File.WriteAllText(_outputFilePath, result.ToString());
        }

        private void DisplayResults(List<double> inputNumbers, double difference)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Разность кубов (первый куб минус остальные): {difference}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
