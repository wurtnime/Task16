using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor9
    {
        private string _inputFilePath;
        private readonly string _outputFilePath;
        private string _tempFilePath;

        public FileProccesor9(string inputFile, string outputFile, string tempFile)
        {
            _inputFilePath = inputFile;
            _outputFilePath = outputFile;
            _tempFilePath = tempFile ?? "temp.txt";
        }

        public void ProcessFile()
        {
            try
            {
                CreateSampleFileIfNotExists();
                CopyFile();
                DisplayResults();
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

        private void CreateSampleFileIfNotExists()
        {
            if (!File.Exists(_inputFilePath))
            {
                File.WriteAllText(_inputFilePath, "Пример текстового файла\nСтрока 1\nСтрока 2\nСтрока 3");
                Console.WriteLine($"Создан пример файла: {_inputFilePath}");
            }
        }

        private void CopyFile()
        {
            File.Copy(_inputFilePath, _outputFilePath, overwrite: true);
        }

        private void DisplayResults()
        {

            Console.WriteLine($"Содержимое исходного файла:\n{File.ReadAllText(_inputFilePath)}");

            Console.WriteLine($"Файл успешно скопирован в: {Path.GetFullPath(_outputFilePath)}");

            Console.WriteLine($"Временный файл: {Path.GetFullPath(_tempFilePath)}");
            Console.WriteLine("\nСодержание копии:");
            Console.WriteLine(File.ReadAllText(_outputFilePath));
        }
    }
}
