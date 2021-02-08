using System;
using System.Diagnostics;

namespace Task6_1
{
    class Program
    {
        static void KillProcessByName(string ProcName) {
            Process[] CurProcs = Process.GetProcessesByName(ProcName);
            if (CurProcs.Length > 0)
            {
                foreach (Process Proc in CurProcs)
                {
                    Proc.Kill();
                    Proc.WaitForExit();
                    //Proc.Dispose();
                }
                Console.WriteLine($"Процесс {ProcName} успешно завершен");
            }
            else {
                Console.WriteLine($"Процесс {ProcName} не найден");
            }
        }
        static void KillProcessByID(int ProcId) {
            Process CurProc = Process.GetProcessById(ProcId);
            string ProcName = CurProc.ProcessName;

            CurProc.Kill();
            CurProc.WaitForExit();
            //CurProc.Dispose();

            Console.WriteLine($"Процесс {ProcName} успешно завершен");
        }
        static void PrintProcessList() {
            Console.WriteLine(String.Format("{0,-30} {1,10}", "Process Name", "Process ID"));
            Process[] processes = Process.GetProcesses();
            foreach (Process CurProc in processes) {
                Console.WriteLine(String.Format("{0,-30} {1,10}", CurProc.ProcessName, CurProc.Id));
            }
}
        static void Main(string[] args)
        {
            PrintProcessList();

            string Input="";
            while (true) {
                Console.WriteLine("Введите имя или ID для завершения процесса или 0 для выхода");
                Input = Console.ReadLine();

                if (Input == "0") { return; };

                int ProcId;
                if (int.TryParse(Input, out ProcId))
                {

                    try { KillProcessByID(ProcId); }
                    catch (Exception ex) { Console.WriteLine($"Не удалось остановить процесс с ID {ProcId}. Ошибка {ex.Message}"); }

                }
                else {
                    try { KillProcessByName(Input); }
                    catch (Exception ex) { Console.WriteLine($"Не удалось остановить процесс {Input}. Ошибка {ex.Message}"); }
                }
                Console.WriteLine("Press Enter key to continue");
                Console.ReadLine();
                Console.Clear();
                PrintProcessList();
            }
        }
    }
}
