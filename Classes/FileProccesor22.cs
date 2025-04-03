using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor22
    {
        private string _fileFPath;
        private string _fileGPath;
        private readonly string _outputFilePath;

        public FileProccesor22(string fileF, string fileG, string outputFile)
        {
            _fileFPath = fileF;
            _fileGPath = fileG;
            _outputFilePath = outputFile;
        }

        public void ProcessFiles()
        {
            try
            {
                var contentF = ReadFileContent(_fileFPath);
                var contentG = ReadFileContent(_fileGPath);
                var mergedContent = MergeContents(contentF, contentG);
                SaveResult(mergedContent);
                DisplayResults(contentF, contentG, mergedContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private string ReadFileContent(string filePath)
        {
            if (!File.Exists(filePath))
            {
                CreateSampleFile(filePath);
                Console.WriteLine($"Создан пример файла: {filePath}");
            }

            return File.ReadAllText(filePath);
        }

        private void CreateSampleFile(string filePath)
        {
            string content = filePath == _fileFPath ? "abcdeff" : "ghijjklm";
            File.WriteAllText(filePath, content);
        }

        private string MergeContents(string contentF, string contentG)
        {
            var reducedF = ReduceConsecutiveChars(contentF);
            var reducedG = ReduceConsecutiveChars(contentG);

            return reducedF + reducedG;
        }

        private string ReduceConsecutiveChars(string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            char previousChar = input[0];
            var result = new System.Text.StringBuilder();
            result.Append(previousChar);

            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != previousChar)
                {
                    result.Append(input[i]);
                    previousChar = input[i];
                }
            }

            return result.ToString();
        }

        private void SaveResult(string mergedContent)
        {
            File.WriteAllText(_outputFilePath, mergedContent);
        }

        private void DisplayResults(string contentF, string contentG, string mergedContent)
        {
            Console.WriteLine($"Содержимое файла f:\n{contentF}");
            Console.WriteLine($"\nСодержимое файла g:\n{contentG}");

            Console.WriteLine($"Объединенное содержимое с сокращением повторов:\n{mergedContent}");

            Console.WriteLine($"Результат сохранен в: {Path.GetFullPath(_outputFilePath)}");
            Console.WriteLine($"Содержимое выходного файла:\n{File.ReadAllText(_outputFilePath)}");
        }
    }
}
