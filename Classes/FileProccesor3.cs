using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{   
        public class FileProccesor3
        {
            private string _inputFilePath;
            private readonly string _outputFilePath;
            private string _tempFilePath;

            public FileProccesor3(string inputFile, string outputFile, string tempFile = null)
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
                    var squares = FilterExactSquares(numbers);
                    SaveResult(squares);
                    DisplayResults(numbers, squares);
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
                var sampleNumbers = new[] { 4, 7, 16, 25, 10, 36, 15, 64, 100, 50 };
                File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
            }

            private List<int> FilterExactSquares(List<int> numbers)
            {
                return numbers.Where(n => IsPerfectSquare(n)).ToList();
            }

            private bool IsPerfectSquare(int number)
            {
                if (number < 0) return false;
                int root = (int)Math.Sqrt(number);
                return root * root == number;
            }

            private void SaveResult(List<int> squares)
            {
                File.WriteAllLines(_outputFilePath, squares.Select(n => n.ToString()));
            }

            private void DisplayResults(List<int> inputNumbers, List<int> squareNumbers)
            {
                Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputNumbers)}");

                Console.WriteLine($"Найдено точных квадратов: {squareNumbers.Count}");
                Console.WriteLine($"Список квадратов:\n{string.Join(", ", squareNumbers)}");

                Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
                Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
                Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
            }
        }
}
