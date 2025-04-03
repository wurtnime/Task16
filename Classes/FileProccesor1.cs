using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp0325.Classes
{
    public class FileProccesor1
    {
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;
        private readonly string _tempFilePath;

        public FileProccesor1(string inputFilePath, string outputFilePath, string tempFilePath)
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
                DisplayResult(numbers);
                ProductOfNumbersInFile(numbers);
            }
            catch(Exception ex) 
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
        private List<double> ReadNumbers()
        {
            if(!File.Exists(_inputFilePath))
            {
                CreateSampleFile();
                Console.WriteLine($"Создан пример файла: {_inputFilePath}");
            }
            var lines = File.ReadAllLines(_inputFilePath);
            return lines.Select(line => double.Parse(line)).ToList();
        }
        private void CreateSampleFile() 
        {
            var sampleNumbers = new[] { 5.2, -12.7, 53,15, -92,1, 34.7 };
            File.WriteAllLines(_inputFilePath, sampleNumbers.Select(n => n.ToString()));
        }
        private double ProductOfNumbersInFile(List<double> numbers)
        {
            double result = 1.0;
            foreach(var number in numbers)
            {
                result *= number;
            }
            return result;
        }
        private void DisplayResult(List<double> numbers)
        {
            Console.WriteLine($"Результат сохранен в файл: {_outputFilePath}");
            Console.WriteLine("\nСодержимое файла: ");
            double product = ProductOfNumbersInFile(numbers);
            Console.WriteLine($"Произведение компонентов: {product}");
            Console.WriteLine(File.ReadAllText(_outputFilePath));          
        }
    }
}
