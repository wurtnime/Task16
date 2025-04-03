using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor5
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor5(string inputFile, string outputFile, string tempFile = null)
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
                var minYear = FindMinYear(dates);
                SaveResult(minYear);
                DisplayResults(dates, minYear);
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

            var dates = new List<DateTime>();
            foreach (var line in File.ReadAllLines(_inputFilePath))
            {
                if (DateTime.TryParse(line, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    dates.Add(date);
                }
            }
            return dates;
        }

        private void CreateSampleFile()
        {
            var sampleDates = new[]
            {
                "15.03.2023",
                "02.07.1998",
                "25.12.2005",
                "31.01.1975",
                "18.09.2010",
                "07.04.1963"
            };
            File.WriteAllLines(_inputFilePath, sampleDates);
        }

        private int FindMinYear(List<DateTime> dates)
        {
            return dates.Min(date => date.Year);
        }

        private void SaveResult(int minYear)
        {
            File.WriteAllText(_outputFilePath, minYear.ToString());
        }

        private void DisplayResults(List<DateTime> dates, int minYear)
        {
            Console.WriteLine($"Всего дат: {dates.Count}");
            Console.WriteLine($"Содержимое файла:\n{string.Join("\n", dates.Select(d => d.ToString("dd.MM.yyyy")))}");
            Console.WriteLine($"Год с наименьшим номером: {minYear}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}

