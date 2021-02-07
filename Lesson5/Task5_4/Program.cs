using System;
using System.IO;
using System.Collections.Generic;

namespace Task5_4
{

    class Program
    {
        static void WriteFolderRecursive(string FolderPath, int indention, string OutFilePath) {
            string[] Folders = Directory.GetDirectories(FolderPath);
            string[] Files = Directory.GetFiles(FolderPath, "*", SearchOption.TopDirectoryOnly);

            if (indention > 1) {
                File.AppendAllText(OutFilePath, (new string('\t', indention - 1)));
            }
            File.AppendAllText(OutFilePath, GetFolderName(FolderPath) + Environment.NewLine);


            for (int i = 0; i < Files.Length; i++) {
                File.AppendAllText(OutFilePath, (new string('\t', indention) + Path.GetFileName(Files[i])) + Environment.NewLine);
            }
            if (Folders.Length > 0) {
                indention++;
                for (int i = 0; i < Folders.Length; i++) {
                    WriteFolderRecursive(Folders[i], indention, OutFilePath);
                }
            }

        }
        static string GetFolderName(string FolderPath) {
            DirectoryInfo CurFolderInfo = new DirectoryInfo(FolderPath);
            return(CurFolderInfo.Name);
        }
        //Для каждой папки храним ее отступ
        static void SaveIndention(ref string[,] IndentionArray, int IndentionArrayCounter, string Indention, string FolderName) {
            IndentionArray[IndentionArrayCounter, 0] = FolderName;
            IndentionArray[IndentionArrayCounter, 1] = Indention; 
        }
        static string GetIndention(ref string[,] IndentionArray, string FolderName) {
            for (int i = 0; i < IndentionArray.GetLength(0); i++) {
                if (FolderName == IndentionArray[i,0]) {
                    return (IndentionArray[i, 1]);   
                }
            }
            return ("");
        }
        static void WriteFolder(string FolderPath, string OutFilePath) {
            string[] Items = Directory.GetFileSystemEntries(FolderPath, "*", SearchOption.AllDirectories);
            Stack<string> Folders = new Stack<string>(Items.Length);

            string[,] IndentionArray = new string[Items.Length + 1, 2];
            int IndentionArrayCounter = 0;

            Folders.Push(FolderPath);
            SaveIndention(ref IndentionArray, IndentionArrayCounter++, "", GetFolderName(FolderPath));

            while (Folders.Count > 0) {
                
                string CurFolder = Folders.Pop();
                string[] SubFolders = Directory.GetDirectories(CurFolder);
                string[] Files = Directory.GetFiles(CurFolder);
                string CurIndention = GetIndention(ref IndentionArray, GetFolderName(CurFolder));

                File.AppendAllText(OutFilePath, CurIndention + GetFolderName(CurFolder) + Environment.NewLine);

                CurIndention += '\t';

                foreach (string CurFile in Files) {
                    FileInfo CurFileInfo = new FileInfo(CurFile);
                    string CurFileName = CurFileInfo.Name;
                    File.AppendAllText(OutFilePath, CurIndention + CurFileName + Environment.NewLine);
                }
                foreach (string Folder in SubFolders) {
                    Folders.Push(Folder);
                    SaveIndention(ref IndentionArray, IndentionArrayCounter++, CurIndention, GetFolderName(Folder));
                }
            }
        }
        static void Main(string[] args)
        {
            string TargetFilePath = "";
            string OutFilePath = @"c:\test\";
            string OutFileName = "Catalog.txt";
            Console.WriteLine("Введите путь для тестовой директории");
            TargetFilePath = Console.ReadLine();


            if (File.Exists(Path.Combine(OutFilePath + OutFileName))) {
                File.Delete(Path.Combine(OutFilePath + OutFileName));
            }
            if (!Directory.Exists(OutFilePath)) {
                Console.WriteLine("Путь для сохранения файла не существует");
                return;
            }
            if (Directory.Exists(TargetFilePath)) {
                //WriteFolderRecursive(TargetFilePath, 1, Path.Combine(OutFilePath + OutFileName)); //рекурсивно
                WriteFolder(TargetFilePath, Path.Combine(OutFilePath + OutFileName)); //без рекурсии
            }
        }
    }
}
