using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace CurNamespace
{
    class Program
    {
        static void GetFileList(ref List<string> FileList, string TargetFolder)
        {

            string[] Folders = Directory.GetDirectories(TargetFolder);
            string[] Files = Directory.GetFiles(TargetFolder, "*", SearchOption.TopDirectoryOnly);

            foreach (string CurFile in Files)
            {
                FileList.Add(CurFile);
            }
            foreach (string CurFolder in Folders)
            {
                GetFileList(ref FileList, CurFolder);
            }

        }
        static void SaveProcessedFiles(ref List<string> ToLogFiles, string OutFilePath)
        {

            File.AppendAllLines(OutFilePath, ToLogFiles);

        }
        static void ProcessFileList(ref List<string> FileList, ref List<string> LogFileList, ref List<string> ToLogFileList)
        {
            foreach (string CurFile in FileList)
            {
                if (!LogFileList.Contains(CurFile))
                {
                    ProcessCurFile(CurFile);
                    ToLogFileList.Add(CurFile);
                }
            }
        }
        static void LoadLogFile(ref List<string> LogFileList, string InFilePath)
        {
            if (File.Exists(InFilePath))
            {
                StreamReader sr = new StreamReader(InFilePath);
                string CurFilePath;
                while ((CurFilePath = sr.ReadLine()) != null)
                {
                    if (File.Exists(CurFilePath))
                    {
                        LogFileList.Add(CurFilePath);
                    }
                }
                sr.Dispose();
            }
        }
        static void ProcessCurFile(string CurFilePath)
        {
            File.AppendAllText(CurFilePath, "Файл обработан \n");
        }
        static void Main(string[] args)
        {
            string OutFileFolder = @"C:\test";
            string OutFileName = "log.txt";
            string TargetFolder = @"F:\TestDir";

            List<string> FileList = new List<string>();
            List<string> LogFileList = new List<string>();
            List<string> ToLogFileList = new List<string>();


            Stopwatch sw = new Stopwatch();
            sw.Start();
            LoadLogFile(ref LogFileList, Path.Combine(OutFileFolder, OutFileName));
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            GetFileList(ref FileList, TargetFolder);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            ProcessFileList(ref FileList, ref LogFileList, ref ToLogFileList);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            SaveProcessedFiles(ref ToLogFileList, Path.Combine(OutFileFolder, OutFileName));
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();


            /*
            for (int i = 0; i < 10000; i++) {
                File.Create(Path.Combine(TargetFolder,Guid.NewGuid().ToString()+".txt"));
            
            }
            */
        }
    }
}
