using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace File1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] fibonacci = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, 610, 987, 1597, 2584, 4181, 6765, 10946 };
            string directoryPath = @"/test/docs";
            string fileName = "file.txt";
            string driveName = "";
            string buffer = "", text = "";
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
                if (!File.Exists(driveName + directoryPath + fileName))
                {
                    File.Create(driveName + directoryPath + fileName);
                }


                using (StreamWriter streamWriter = new StreamWriter(driveName + directoryPath + fileName))
                {
                    for (int i = 0; i < 11; i++)
                    {
                        text = fibonacci[i].ToString() + ", ";
                        streamWriter.Write(text);
                    }
                }

                Console.WriteLine("Вывод данных из файла:");
                using (StreamReader streamReader = new StreamReader(driveName + directoryPath + fileName))
                {

                    buffer = streamReader.ReadToEnd();
                    Console.WriteLine(buffer);
                }
                using (StreamWriter streamWriter = new StreamWriter(driveName + directoryPath + fileName))
                {
                    string continueBuffer = "";
                    for (int i = 11; i < 22; i++)
                    {
                        continueBuffer = fibonacci[i].ToString() + ", ";
                        buffer += continueBuffer;
                    }
                    streamWriter.WriteLine(buffer);
                }
                using (StreamReader streamReader = new StreamReader(driveName + directoryPath + fileName))
                {
                    Console.WriteLine(streamReader.ReadToEnd());
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine(exception.Message);
            }
            Console.ReadKey();
        }
    }
}
