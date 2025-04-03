using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor20
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor20(string inputFile, string outputFile, string tempFile)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile;
        }

        public void ProcessFile()
        {
            try
            {
                var content = ReadFileContent();
                var reversedContent = ReverseContent(content);
                SaveResult(reversedContent);
                DisplayResults(content, reversedContent);
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
            var sampleContent = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            File.WriteAllText(_inputFilePath, sampleContent);
        }

        private string ReverseContent(string content)
        {
            char[] charArray = content.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void SaveResult(string reversedContent)
        {
            File.WriteAllText(_outputFilePath, reversedContent);
        }

        private void DisplayResults(string originalContent, string reversedContent)
        {
            Console.WriteLine($"Содержимое файла:\n{originalContent}");

            Console.WriteLine($"Обратный порядок символов:\n{reversedContent}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
