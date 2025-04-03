using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor2
    {
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;
        private readonly string _tempFilePath;

        public FileProccesor2(string inputFilePath, string outputFilePath, string tempFilePath)
        {
            _inputFilePath = inputFilePath;
            _outputFilePath = outputFilePath;
            _tempFilePath = tempFilePath;
        }
        public void ProcessFile()
        {
            try
            {
                var numbers = ReadNumbers();
                ValidateNumbers(numbers);
                var sortedNumbers = SortNumbers(numbers);
                SaveResult(sortedNumbers);
                DisplayResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private List<int> ReadNumbers()
        {
            if (!File.Exists(_inputFilePath))
            {
                CreateSampleFile();
                Console.WriteLine($"Создан пример файла: {_inputFilePath}");
            }
            var lines = File.ReadAllLines(_inputFilePath);
            return lines.Select(line => int.Parse(line)).ToList();
        }
        private void CreateSampleFile()
        {
            var sampleNumbers = new[] { 5, -12, 53, -92, 34 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }
        private void ValidateNumbers(List<int> numbers)
        {
            if (numbers.Contains(0))
            {
                throw new Exception("Файл содержит нулевые значения");
            }
            int pozitiveCount = numbers.Count(n => n > 0);
            int negativeCount = numbers.Count(n => n < 0);
            if (pozitiveCount != negativeCount)
            {
                throw new Exception($"Несоответствие количества чиcел: положительных {pozitiveCount}, отрицательных {negativeCount}");
            }
        }
        private List<int> SortNumbers(List<int> numbers)
        {
            return numbers.Where(n => n > 0).OrderBy(n => n).Concat(numbers.Where(n => n < 0)).ToList();
        }
        private void SaveResult(List<int> numbers)
        {
            File.WriteAllLines(_tempFilePath, numbers.Select(n => n.ToString()));
            if (File.Exists(_outputFilePath))
            {
                File.Delete(_outputFilePath);
            }
            File.Move(_tempFilePath, _outputFilePath);
        }
        private void DisplayResult()
        {
            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в файл: {_outputFilePath}");
            Console.WriteLine("\nСодержимое файла: ");
            Console.WriteLine(File.ReadAllText(_outputFilePath));
        }
    }
}

