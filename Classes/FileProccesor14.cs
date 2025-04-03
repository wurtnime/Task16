using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor14
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor14(string inputFile, string outputFile, string tempFile)
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
                var maxAbs = FindMaxAbsoluteOddPosition(numbers);
                SaveResult(maxAbs);
                DisplayResults(numbers, maxAbs);
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
            var sampleNumbers = new[] { 3.5, -2.1, 15.8, -0.7, -4.3, 10.2, 7.6, -8.9 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private double FindMaxAbsoluteOddPosition(List<double> numbers)
        {
            var oddPositionNumbers = numbers
                .Select((num, index) => new { Number = num, Index = index + 1 })
                .Where(x => x.Index % 2 != 0)
                .Select(x => Math.Abs(x.Number))
                .ToList();

            if (!oddPositionNumbers.Any())
                throw new Exception("Нет элементов с нечетными номерами");

            return oddPositionNumbers.Max();
        }

        private void SaveResult(double maxAbs)
        {
            File.WriteAllText(_outputFilePath, maxAbs.ToString("F4"));
        }

        private void DisplayResults(List<double> numbers, double maxAbs)
        {
            Console.WriteLine($"Всего чисел: {numbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", numbers)}");

            var oddPositions = numbers
                .Select((num, index) => new { Number = num, Index = index + 1 })
                .Where(x => x.Index % 2 != 0);

            foreach (var item in oddPositions)
            {
                Console.WriteLine($"Позиция {item.Index}: {item.Number} (модуль: {Math.Abs(item.Number):F4})");
            }

            Console.WriteLine($"Наибольший модуль: {maxAbs:F4}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
