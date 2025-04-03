using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp0325.Classes;
using static ConsoleApp0325.Classes.FileProccesor3;

namespace ConsoleApp0325
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Практическая работа №16");
            Console.WriteLine("Введите номер задания от 1 до 30");
            int input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 1:
                    var processor1 = new FileProccesor1(inputFilePath: "TextTemplate1.txt", outputFilePath: "g.txt", tempFilePath: "h.txt");
                    processor1.ProcessFile();
                    Console.ReadLine();
                    break;
                case 2:
                    var processor2 = new FileProccesor2(inputFilePath: @"C:\Users\Сетт\OneDrive\Desktop\f.txt", outputFilePath: "g.txt", tempFilePath: "h.txt");
                    processor2.ProcessFile();
                    Console.ReadLine();
                    break;
                case 3:        
                    var processor3 = new FileProccesor3(inputFile: "TextTemplate3.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path3 = Console.ReadLine();
                    processor3.ProcessFile(string.IsNullOrEmpty(path3) ? null : path3);
                    break;
                case 4:
                    var processor4 = new FileProccesor4(inputFile: "TextTemplate4.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path4 = Console.ReadLine();
                    processor4.ProcessFile(string.IsNullOrEmpty(path4) ? null : path4);
                    break;
                case 5:
                    var processor5 = new FileProccesor5(inputFile: "TextTemplate5.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path5 = Console.ReadLine();
                    processor5.ProcessFile(string.IsNullOrEmpty(path5) ? null : path5);
                    break;
                case 6:
                    var processor6 = new FileProccesor6(inputFile: "TextTemplate6.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path6 = Console.ReadLine();
                    processor6.ProcessFile(string.IsNullOrEmpty(path6) ? null : path6);
                    break;
                case 7:
                    var processor7 = new FileProccesor7(inputFile: "TextTemplate7.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path7 = Console.ReadLine();
                    processor7.ProcessFile(string.IsNullOrEmpty(path7) ? null : path7);
                    break;
                case 8:
                    var processor8 = new FileProccesor8(inputFile: "TextTemplate8.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path8 = Console.ReadLine();
                    processor8.ProcessFile(string.IsNullOrEmpty(path8) ? null : path8);
                    break;
                case 9:
                    var processor9 = new FileProccesor9(inputFile: "TextTemplate9.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path9 = Console.ReadLine();
                    processor9.ProcessFile(string.IsNullOrEmpty(path9) ? null : path9);
                    break;
                case 10:
                    var merger = new FileProccesor10(sourceFile: "TextTemplate10.txt", targetFile: "TextTemplate10.1.txt", tempFile: "temp.txt");
                    merger.ProcessFile();
                    break;
                case 11:
                    var processor11 = new FileProccesor11(inputFile: "TextTemplate11.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path11 = Console.ReadLine();
                    processor11.ProcessFile(string.IsNullOrEmpty(path11) ? null : path11);
                    break;
                case 12:
                    var processor12 = new FileProccesor12(inputFile: "TextTemplate12.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path12 = Console.ReadLine();
                    processor12.ProcessFile(string.IsNullOrEmpty(path12) ? null : path12);
                    break;
                case 13:
                    var processor13 = new FileProccesor13(inputFile: "TextTemplate13.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path13 = Console.ReadLine();
                    processor13.ProcessFile(string.IsNullOrEmpty(path13) ? null : path13);
                    break;
                case 14:
                    var processor14 = new FileProccesor14(inputFile: "TextTemplate14.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path14 = Console.ReadLine();
                    processor14.ProcessFile(string.IsNullOrEmpty(path14) ? null : path14);
                    break;
                case 15:
                    var processor15 = new FileProccesor15(inputFile: "TextTemplate15.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path15 = Console.ReadLine();
                    processor15.ProcessFile(string.IsNullOrEmpty(path15) ? null : path15);
                    break;
                case 16:
                    var processor16 = new FileProccesor16(inputFile: "TextTemplate16.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path16 = Console.ReadLine();
                    processor16.ProcessFile(string.IsNullOrEmpty(path16) ? null : path16);
                    break;
                case 17:
                    var processor17 = new FileProccesor17(inputFile: "TextTemplate17.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path17 = Console.ReadLine();
                    processor17.ProcessFile(string.IsNullOrEmpty(path17) ? null : path17);
                    break;
                case 18:
                    var processor18 = new FileProccesor18(inputFile: "TextTemplate18.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path18 = Console.ReadLine();
                    processor18.ProcessFile(string.IsNullOrEmpty(path18) ? null : path18);
                    break;
                case 19:
                    var processor19 = new FileProccesor19(inputFile: "TextTemplate19.txt", evenOutputFile: "g.txt", oddOutputFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path19 = Console.ReadLine();
                    processor19.ProcessFile(string.IsNullOrEmpty(path19) ? null : path19);
                    break;
                case 20:
                    var processor20 = new FileProccesor20(inputFile: "TextTemplate20.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path20 = Console.ReadLine();
                    processor20.ProcessFile(string.IsNullOrEmpty(path20) ? null : path20);
                    break;
                case 21:
                    var processor21 = new FileProccesor21(inputFile: "TextTemplate21.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path21 = Console.ReadLine();
                    processor21.ProcessFile(string.IsNullOrEmpty(path21) ? null : path21);
                    break;
                case 22:
                    var processor22 = new FileProccesor22(fileF: "TextTemplate22.1.txt", fileG: "TextTemplate22.2.txt", outputFile: "h.txt");
                    processor22.ProcessFiles();
                    break;
                case 23:
                    var processor23 = new FileProccesor23(inputFile: "TextTemplate23.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path23 = Console.ReadLine();
                    processor23.ProcessFile(string.IsNullOrEmpty(path23) ? null : path23);
                    break;
                case 24:
                    var processor24 = new FileProccesor24(inputFile: "TextTemplate24.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path24 = Console.ReadLine();
                    processor24.ProcessFile(string.IsNullOrEmpty(path24) ? null : path24);
                    break;
                case 25:
                    var processor25 = new FileProccesor25(inputFile: "TextTemplate25.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path25 = Console.ReadLine();
                    processor25.ProcessFile(string.IsNullOrEmpty(path25) ? null : path25);
                    break;
                case 26:
                    var processor26 = new FileProccesor26(inputFile: "TextTemplate26.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path26 = Console.ReadLine();
                    processor26.ProcessFile(string.IsNullOrEmpty(path26) ? null : path26);
                    break;
                case 27:
                    var processor27 = new FileProccesor27(inputFile: "TextTemplate27.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path27 = Console.ReadLine();
                    processor27.ProcessFile(string.IsNullOrEmpty(path27) ? null : path27);
                    break;
                case 28:
                    var processor28 = new FileProccesor28(inputFile: "TextTemplate28.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path28 = Console.ReadLine();
                    processor28.ProcessFile(string.IsNullOrEmpty(path28) ? null : path28);
                    break;
                case 29:
                    var processor29 = new FileProccesor29(inputFile: "TextTemplate29.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path29 = Console.ReadLine();
                    processor29.ProcessFile(string.IsNullOrEmpty(path29) ? null : path29);
                    break;
                case 30:
                    var processor30 = new FileProccesor30(inputFile: "TextTemplate30.txt", outputFile: "g.txt", tempFile: "h.txt");
                    Console.WriteLine("Введите путь к файлу или нажмите Enter для файла по умолчанию:");
                    string path30 = Console.ReadLine();
                    processor30.ProcessFile(string.IsNullOrEmpty(path30) ? null : path30);
                    break;
            }
        }
    }
}
