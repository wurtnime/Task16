using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor24
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor24(string inputFile, string outputFile, string tempFile)
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
                var oddSquares = FindOddSquares(numbers);
                SaveResult(oddSquares);
                DisplayResults(numbers, oddSquares);
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
            var sampleNumbers = new[] { 9, 4, 25, 16, 49, 36, 81, 64, 100, 121 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }

        private List<int> FindOddSquares(List<int> numbers)
        {
            return numbers.Where(n => IsPerfectSquare(n) && IsSquareOfOdd(n)).ToList();
        }

        private bool IsPerfectSquare(int number)
        {
            if (number < 0) return false;
            int root = (int)Math.Sqrt(number);
            return root * root == number;
        }

        private bool IsSquareOfOdd(int number)
        {
            int root = (int)Math.Sqrt(number);
            return root % 2 != 0;
        }

        private void SaveResult(List<int> oddSquares)
        {
            File.WriteAllLines(_outputFilePath, oddSquares.Select(n => n.ToString()));
        }

        private void DisplayResults(List<int> inputNumbers, List<int> oddSquares)
        {
            Console.WriteLine($"Всего чисел: {inputNumbers.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

            Console.WriteLine($"Найдено квадратов нечётных чисел: {oddSquares.Count}");
            Console.WriteLine($"Список квадратов нечётных чисел:\n{string.Join(", ", oddSquares)}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
