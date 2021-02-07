using System;
using System.IO;

namespace Task5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            String FileFolder = @"C:\test\";
            String FileName = "startup.txt";

            if (Directory.Exists(FileFolder)) {
                File.AppendAllText(Path.Combine(FileFolder,FileName), DateTime.Now.ToString("hh.MM.ss")+ Environment.NewLine);
            }
        }
    }
}
