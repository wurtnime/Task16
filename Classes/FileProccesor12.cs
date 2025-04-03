using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor12
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor12(string inputFile, string outputFile, string tempFile = null)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile ?? "temp.txt";
        }

        public void ProcessFile()
        {
            try
            {
                var content = ReadFileContent();
                CheckFirstTwoChars(content);
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

        private string ReadFileContent()
        {
            if (!File.Exists(_inputFilePath))
            {
                CreateSampleFile();
                Console.WriteLine($"Создан пример файла: {_inputFilePath}");
            }

            return File.ReadAllText(_inputFilePath);
        }

        private void CreateSampleFile()
        {
            File.WriteAllText(_inputFilePath, "24Пример текстового файла\nСтрока 1\nСтрока 2");
        }

        private void CheckFirstTwoChars(string content)
        {
            if (content.Length < 2)
                throw new Exception("Файл содержит менее двух символов");

            char firstChar = content[0];
            char secondChar = content[1];

            bool areDigits = char.IsDigit(firstChar) && char.IsDigit(secondChar);
            bool isEven = false;

            if (areDigits)
            {
                int number = int.Parse($"{firstChar}{secondChar}");
                isEven = number % 2 == 0;
            }

            string result = $"Первый символ: '{firstChar}'\n" +
                          $"Второй символ: '{secondChar}'\n" +
                          $"Оба символа цифры: {areDigits}\n";

            if (areDigits)
            {
                result += $"Образованное число: {int.Parse($"{firstChar}{secondChar}")}\n" +
                         $"Число чётное: {isEven}";
            }

            File.WriteAllText(_outputFilePath, result);
            DisplayResults(content, result);
        }

        private void DisplayResults(string content, string result)
        {
            Console.WriteLine($"Содержимое файла:\n{content}");

            Console.WriteLine(result);

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
