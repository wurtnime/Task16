using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor21
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor21(string inputFile, string outputFile, string tempFile)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile;
        }

        public void ProcessFile()
        {
            try
            {
                var dates = ReadDates();
                var latestDate = FindLatestDate(dates);
                SaveResult(latestDate);
                DisplayResults(dates, latestDate);
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

        private List<DateTime> ReadDates()
        {
            if (!File.Exists(_inputFilePath))
            {
                CreateSampleFile();
                Console.WriteLine($"Создан пример файла: {_inputFilePath}");
            }

            return File.ReadAllLines(_inputFilePath)
                     .Where(line => !string.IsNullOrWhiteSpace(line))
                     .Select(line => DateTime.Parse(line.Trim()))
                     .ToList();
        }

        private void CreateSampleFile()
        {
            var sampleDates = new[]
            {
                "15.03.2023",
                "01.01.2024",
                "20.05.2022",
                "31.12.2025",
                "21.03.2023",
                "30.04.2024",
                "01.06.2021"
            };
            File.WriteAllLines(_inputFilePath, sampleDates);
        }

        private DateTime FindLatestDate(List<DateTime> dates)
        {
            if (!dates.Any())
                throw new InvalidOperationException("Файл не содержит дат");

            return dates.Max();
        }

        private void SaveResult(DateTime latestDate)
        {
            File.WriteAllText(_outputFilePath, latestDate.ToString("dd.MM.yyyy"));
        }

        private void DisplayResults(List<DateTime> inputDates, DateTime latestDate)
        {
            Console.WriteLine($"Всего дат: {inputDates.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join("\n", inputDates.Select(d => d.ToString("dd.MM.yyyy")))}");

            Console.WriteLine($"Самая поздняя дата: {latestDate:dd.MM.yyyy}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
