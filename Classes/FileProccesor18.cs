using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor18
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor18(string inputFile, string outputFile, string tempFile)
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
                var minEvenIndexValue = FindMinEvenIndexValue(numbers);
                SaveResult(minEvenIndexValue);
                DisplayResults(numbers, minEvenIndexValue);
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
            var sampleNumbers = new[] { 3.5, 7.2, 1.6, 2.5, 10.1, 3.6, 1.5, 6.4, 10.0, 5.5 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private double FindMinEvenIndexValue(List<double> numbers)
        {
            var evenIndexValues = numbers.Where((n, index) => index % 2 != 0).ToList();

            if (!evenIndexValues.Any())
            {
                throw new InvalidOperationException("В файле нет компонент с четными номерами");
            }

            return evenIndexValues.Min();
        }

        private void SaveResult(double result)
        {
            File.WriteAllText(_outputFilePath, result.ToString());
        }

        private void DisplayResults(List<double> inputNumbers, double minValue)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Наименьшее значение среди компонент с четными номерами: {minValue}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
