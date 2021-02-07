using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Task5_5
{
    [XmlRoot("root")]
    public class RootClass {        
        public List<ToDoList> Items { get; set; }

    }
    public class ToDoList { 
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDoList() { }
        public ToDoList(string TaskName) {
            Title = TaskName;
        }
        public override string ToString()
        {
            string isDoneMark = IsDone ? "[X]" : "[ ]";
            return ($"{isDoneMark}{'\t'}{Title}");
        }
    }
    class Program
    {
        const string ExitMsg = "exit";
        static void AddNewTask(ref List<ToDoList> TaskList, string CurTitle) {

            while (String.IsNullOrEmpty(CurTitle)) {
                Console.WriteLine("Введите название задачи");
                CurTitle = Console.ReadLine();
            }

            ToDoList CurTask = new ToDoList(CurTitle);
            if (TaskList.Exists(x => x.Title.ToLower() == CurTitle.ToLower())) {
                PrintErrorMsg("Задача уже существует");
                return;
            }
            
            TaskList.Add(CurTask);
            Console.Clear();
        }
        static void SerializeToXML(ref List<ToDoList> TaskList, string OutPath) {

            RootClass Root = new RootClass { Items = TaskList };

            StringWriter sw = new StringWriter();
            XmlSerializer Serializer = new XmlSerializer(typeof(RootClass));
            Serializer.Serialize(sw, Root);
            string xml = sw.ToString();
            File.WriteAllText(OutPath, xml);
        }
        static void DeserializeFromXML(ref List<ToDoList> TaskList, string InPath) {
            string xml = File.ReadAllText(InPath);
            StringReader sr = new StringReader(xml);
            XmlSerializer Serializer = new XmlSerializer(typeof(RootClass));
            RootClass RC = (RootClass)Serializer.Deserialize(sr);
            TaskList = RC.Items;
        }
        static void ManageTaskList(ref List<ToDoList> TaskList) {
            string Input = "";
            
            while (Input.ToLower() != ExitMsg) {
                int TaskNo = 1;
                if (TaskList.Count > 0)
                {
                    foreach (ToDoList CurTask in TaskList)
                    {
                        Console.WriteLine($"{TaskNo++}{'\t'}{CurTask}");
                    }
                }
                PrintManageMenu();
                Input = Console.ReadLine();

                switch (Input){
                    case "0": AddNewTask(ref TaskList, String.Empty);break;
                    case ExitMsg: break;
                    default:
                        int CurTaskNo = 0;
                        if (int.TryParse(Input, out CurTaskNo))
                        {
                            if (CurTaskNo <= TaskList.Count && CurTaskNo > 0) 
                            {
                                TaskList[CurTaskNo - 1].IsDone = true;
                            }
                            else
                            {
                                PrintErrorMsg($"Задача {CurTaskNo} не существует!");
                            }
                        }
                        else
                        {
                            PrintErrorMsg("Ошибка! Введен не номер задачи");
                        }
                        break;
                }

                Console.Clear();
            }
            
        }
        static void PrintErrorMsg(string Message) {
            Console.WriteLine(Message);
            Console.WriteLine("press enter key to continue");
            Console.ReadLine();
        }
        static void PrintManageMenu() {            
            Console.WriteLine();
            Console.WriteLine("Введите номер задачи, чтобы отметить ее как завершенную");
            Console.WriteLine("Введите 0 для добавления новой задачи");
            Console.WriteLine($"Введите '{ExitMsg}' для выхода и сохранения результатов");
        }
        static void Main(string[] args)
        {
            string OutFilePath = @"c:\test\";
            string OutFileName = "ToDoList.xml";

            List<ToDoList> CurToDoList = new List<ToDoList>();
            DeserializeFromXML(ref CurToDoList, Path.Combine(OutFilePath, OutFileName));
            ManageTaskList(ref CurToDoList);
            Console.Clear();
            SerializeToXML(ref CurToDoList, Path.Combine(OutFilePath, OutFileName));

            
        }
    }
}
