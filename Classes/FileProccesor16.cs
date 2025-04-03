using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor16
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor16(string inputFile, string outputFile, string tempFile)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile ?? "temp.txt";
        }

        public void ProcessFile()
        {
            try
            {
                var dates = ReadDates();
                var springDates = FilterSpringDates(dates);
                SaveResult(springDates);
                DisplayResults(dates, springDates);
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
                "01.01.2023",
                "20.05.2023",
                "31.12.2023",
                "21.03.2023",
                "30.04.2023",
                "01.06.2023"
            };
            File.WriteAllLines(_inputFilePath, sampleDates);
        }

        private List<DateTime> FilterSpringDates(List<DateTime> dates)
        {
            return dates.Where(d => d.Month >= 3 && d.Month <= 5).ToList();
        }

        private void SaveResult(List<DateTime> springDates)
        {
            File.WriteAllLines(_outputFilePath, springDates.Select(d => d.ToString("dd.MM.yyyy")));
        }

        private void DisplayResults(List<DateTime> inputDates, List<DateTime> springDates)
        {
            Console.WriteLine($"Всего дат: {inputDates.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join(", ", inputDates.Select(d => d.ToString("dd.MM.yyyy")))}");

            Console.WriteLine($"Найдено весенних дат: {springDates.Count}");
            Console.WriteLine($"Список весенних дат:\n{string.Join(", ", springDates.Select(d => d.ToString("dd.MM.yyyy")))}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
