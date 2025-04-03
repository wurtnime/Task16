using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor15
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor15(string inputFile, string outputFile, string tempFile)
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
                if (numbers.Count == 0)
                    throw new Exception("Файл не содержит чисел");

                double lastComponent = numbers.Last();
                SaveResult(lastComponent);
                DisplayResults(numbers, lastComponent);
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
            var sampleNumbers = new[] { 3.5, -2.1, 15.8, 0.7, -4.3, 10.2 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private void SaveResult(double lastComponent)
        {
            File.WriteAllText(_outputFilePath, lastComponent.ToString("F4"));
        }

        private void DisplayResults(List<double> numbers, double lastComponent)
        {
            Console.WriteLine($"Всего чисел: {numbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", numbers)}");

            Console.WriteLine($"Последняя компонента: {lastComponent:F4}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
