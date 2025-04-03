using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor17
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor17(string inputFile, string outputFile, string tempFile)
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
                var filteredNumbers = FilterNumbers(numbers);
                SaveResult(filteredNumbers);
                DisplayResults(numbers, filteredNumbers);
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
            var sampleNumbers = new[] { 3, 7, 9, 21, 12, 14, 15, 28, 30, 42 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private List<int> FilterNumbers(List<int> numbers)
        {
            return numbers.Where(n => n % 3 == 0 && n % 7 != 0).ToList();
        }

        private void SaveResult(List<int> filteredNumbers)
        {
            File.WriteAllLines(_outputFilePath, filteredNumbers.Select(n => n.ToString()));
        }

        private void DisplayResults(List<int> inputNumbers, List<int> filteredNumbers)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Найдено чисел, делящихся на 3 и не делящихся на 7: {filteredNumbers.Count}");
            Console.WriteLine($"Список подходящих чисел:\n{string.Join(", ", filteredNumbers)}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
