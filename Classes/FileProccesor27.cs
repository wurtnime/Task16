using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor27
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor27(string inputFile, string outputFile, string tempFile)
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
                var doubleOdds = FindDoubleOddNumbers(numbers);
                SaveResult(doubleOdds);
                DisplayResults(numbers, doubleOdds);
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
            var sampleNumbers = new[] { 6, 14, 10, 18, 22, 26, 34, 38, 50, 7 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private List<int> FindDoubleOddNumbers(List<int> numbers)
        {
            return numbers.Where(n => IsDoubleOdd(n)).ToList();
        }

        private bool IsDoubleOdd(int number)
        {
            return number % 2 == 0 && (number / 2) % 2 != 0;
        }

        private void SaveResult(List<int> doubleOdds)
        {
            File.WriteAllLines(_outputFilePath, doubleOdds.Select(n => n.ToString()));
        }

        private void DisplayResults(List<int> inputNumbers, List<int> doubleOdds)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Найдено удвоенных нечётных чисел: {doubleOdds.Count}");
            Console.WriteLine($"Список удвоенных нечётных чисел:\n{string.Join(", ", doubleOdds)}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
