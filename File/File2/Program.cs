using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace File2
{
    class Program
    {
        static void Main(string[] args)
        {

            string directoryPath = @"/test/second/";
            string fileInput = "input.txt";
            string fileOutput = "output.txt";
            string driveName = "";
            int firstNumber = 0, secondNumber = 0, sum = 0;
            bool isPars;
            DriveInfo[] drives = DriveInfo.GetDrives();

            for (int i = 0; i < drives.Length; i++)
            {
                Console.WriteLine($"{i}.{drives[i].Name}");
            }

            Console.WriteLine("Введите номер диска, на который будет записан файл");

            string driveNumberAsString = Console.ReadLine();

            int driveNumber = 0;
            if (!int.TryParse(driveNumberAsString, out driveNumber))
            {
                Console.WriteLine("Ошибка ввода, будет произведена запись на первый указанный диск.");
            }
            driveName = drives[driveNumber].Name;

            if (!Directory.Exists(driveName + directoryPath))
            {
                Directory.CreateDirectory(driveName + directoryPath);
            }
            try
            {
                if (!File.Exists(driveName + directoryPath + fileInput))
                {
                    File.Create(driveName + directoryPath + fileInput);
                }


                using (StreamWriter streamWriter = new StreamWriter(driveName + directoryPath + fileInput))
                {
                    Console.WriteLine("\nВведите 1 число:");
                    isPars = int.TryParse(Console.ReadLine(), out firstNumber);

                    Console.WriteLine("\nВведите 2 число:");
                    isPars = int.TryParse(Console.ReadLine(), out secondNumber);

                    streamWriter.WriteLine(firstNumber + " " + secondNumber);
                    sum = firstNumber + secondNumber;
                    using (StreamWriter streamWriterOutput = new StreamWriter(driveName + directoryPath + fileOutput))
                    {
                        streamWriterOutput.WriteLine(sum);
                    }
                }
                using (StreamReader streamReader = new StreamReader(driveName + directoryPath + fileOutput))
                {
                    Console.WriteLine("\nСумма:" + streamReader.ReadToEnd());
                }
            }

            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }

            Console.WriteLine("Просмотрите файлы input.txt и output.txt");
            Console.ReadKey();
        }
    }
}
