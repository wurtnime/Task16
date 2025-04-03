using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    internal class FileProccesor10
    {
        private string _sourceFilePath;
        private string _targetFilePath;
        private string _tempFilePath;

        public FileProccesor10(string sourceFile, string targetFile, string tempFile)
        {
            _sourceFilePath = sourceFile;
            _targetFilePath = targetFile;
            _tempFilePath = tempFile ?? "temp.txt";
        }

        public void ProcessFile()
        {
            try
            {
                CreateSampleFilesIfNotExist();
                MergeFiles();
                DisplayResults();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }

        private void CreateSampleFilesIfNotExist()
        {
            if (!File.Exists(_sourceFilePath))
            {
                File.WriteAllText(_sourceFilePath, "Содержимое исходного файла\nСтрока 1\nСтрока 2");
                Console.WriteLine($"Создан пример исходного файла: {_sourceFilePath}");
            }

            if (!File.Exists(_targetFilePath))
            {
                File.WriteAllText(_targetFilePath, "Исходное содержимое целевого файла\nСтрока A\nСтрока B");
                Console.WriteLine($"Создан пример целевого файла: {_targetFilePath}");
            }
        }

        private void MergeFiles()
        {
            string sourceContent = File.ReadAllText(_sourceFilePath);

            File.Copy(_targetFilePath, _tempFilePath, overwrite: true);


            File.WriteAllText(_targetFilePath, sourceContent);
        }

        private void DisplayResults()
        {
            Console.WriteLine($"Содержимое файла {Path.GetFileName(_sourceFilePath)}:\n{File.ReadAllText(_sourceFilePath)}");
            Console.WriteLine($"\nИсходное содержимое файла {Path.GetFileName(_targetFilePath)}:\n{File.ReadAllText(_tempFilePath)}");

            Console.WriteLine($"Файл {Path.GetFileName(_sourceFilePath)} успешно переписан в {Path.GetFileName(_targetFilePath)}");
            Console.WriteLine($"\nТекущее содержимое {Path.GetFileName(_targetFilePath)}:\n{File.ReadAllText(_targetFilePath)}");

            Console.WriteLine(File.ReadAllText(_tempFilePath));
        }
    }
}
