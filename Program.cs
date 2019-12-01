using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        struct Student {
            private String fullName;
            private String group;
            private int age;
            private int solar;
            private Dictionary<string, int> rates;
            public bool isManager;


            public Student(string fullName, string group) {
                this.fullName = fullName;
                this.group = group;
                this.age = 18;
                solar = 1000;
                rates = new Dictionary<string, int>();
                isManager = false;
            }

            public string GetName() {
                return fullName;
            }

            public void AddRates(string subject, int rating) {
                if (rating > 5 || rating < 1)
                    sendMessage("Оценка должны быть в диапазоне от 1 до 5");
                else
                    rates.Add(subject, rating);
            }

            public int GetRates(string subject) {
                return rates[subject];
            }

            public Dictionary<string, int> GetRatesList() {
                return rates;
            }

            public void SetAge(int age) {
                this.age = age; 
            }

            public int GetAge() {
                return age;
            }

            public void SetSolar(int solar) {
                this.solar = solar;
            }

            public int GetSolar() {
                return solar;
            }

            public void MakeManager() {
                isManager = true;
            }

            public void DowngradeManager() {
                isManager = false;
            }
           
            private void sendMessage(string error) {
                Console.WriteLine("ERROR: " + error);
            }

            public void ShowStudent() {
                Console.WriteLine(fullName + ", группа: " + group );
            }

          

        }

        struct Group {
            private List<Student> students ;
            private string groupName;

            public Group(string name) {
                students = new List<Student>();
                this.groupName = name;
            }

            public Student GetManager() {
                Student manager = new Student();
                foreach (Student student in students) {
                    if (student.isManager) {
                        manager = student;
                        break;
                    }
                }

                return manager;
            }

          

            public void AddStudent(string fullName) {
                students.Add(new Student(fullName, groupName));
            }

            public void ExpelStudent(string fullName) {
                students.Remove(SearchStudent(fullName));
            }

            public void ShowGroup() {
                Console.WriteLine(groupName + ":");
                foreach (Student item in students) {
                    Console.WriteLine(item.GetName());
                }
            }

            public string GetGroupName() {
                return groupName;
            }

            public Student SearchStudent(string fullName) {
                Student findedStudent = new Student();
                foreach (Student student in students) { 
                    if (student.GetName() == fullName) {
                        findedStudent = student;
                        break;
                    }
                }

                return findedStudent;
            }




        }

        struct Menu {

            private List<string> menuList;

            public Menu(string menuItem) {
                menuList = new List<string>();
                AddMenuItem(menuItem);
            }

            public void AddMenuItem(string menuItem) {
                menuList.Add(menuItem);
            }


        
        }

        static List<Group> groups = new List<Group>();

        static void Main(string[] args)
        {

            bool isWorking = true;

            while (isWorking) {
                OpenMenu();

                string item = Console.ReadLine();
                switch (item) {
                    case "1":
                        ShowGroups();
                        break;
                    case "2":
                        AddGroup();
                        break;
                    case "3":
                        OpenGroupMenu(OpenGroup());

                        break;

                    case "4":
                        Console.WriteLine("Работа с журналом завершена.");
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("ERROR: Введите номер меню!");
                        break;
             
                
                }
            }




            Console.Read();
        }
       

        
        static void OpenMenu() {
            
            
            Console.WriteLine("Введите нужный Вам номер пункта меню:");

            string[] tokens = new string[] {"Показать список групп" ,"Создать группу", "Открыть группу", "Завершить работу" };

            for (int i = 0; i < tokens.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + tokens[i]);
            }
        }

        static Group OpenGroup() {
            Console.WriteLine("Введите называние группы");
            string name = Console.ReadLine();
            Group findedGroup = new Group();
            bool isFind = false;
            foreach (Group group in groups) {
                if (group.GetGroupName() == name)
                {
                    findedGroup = group;
                    isFind = true;
                }
            }
            if (!isFind) {
                Console.WriteLine("ERROR: Данная группа не найдена");
                OpenGroup();
            }

            return findedGroup;
        }

        static void OpenGroupMenu(Group group) {
          

            
            bool isWorking = true;

            while (isWorking) {
                ShowGroupMenu();
                string item = Console.ReadLine();
                switch (item)
                {
                    case "1":
                        AddStudent(group);
                        break;
                    case "2":
                        ExpelStudent(group);
                        break;
                    case "3":
                        ShowManager(group);
                        break;
                    case "4":
                        MakeManager(ref group);
                        break;
                    case "5":
                        Console.Write("Список группы ");
                        group.ShowGroup();
                        Console.WriteLine();

                        break;
                    case "6":
                        Console.WriteLine("Возврат к главному меню");
                        isWorking = false;
                        break;
                    default:
                        Console.WriteLine("ERROR: Введите номер меню!");
                        break;


                }


            }

        }

        static void ShowGroupMenu() {
            Console.WriteLine("Введите нужный Вам номер пункта меню:");

            string[] tokens = new string[] { "Добавить студента", "Отчислить сутдента", "Показать саросту", "Назначить старосту", "Посмотреть список группы", "Вернуться к главному меню" };

            for (int i = 0; i < tokens.Length; i++)
            {
                Console.WriteLine((i + 1) + " - " + tokens[i]);
            }
        }

        static void ShowGroups() {
            Console.WriteLine("Список групп:");
            foreach (Group group in groups) {
                Console.WriteLine(group.GetGroupName());
            }
            Console.WriteLine();
        }

        static void AddStudent(Group group) {
            Console.WriteLine("Введите имя нового студента полностью");
            string name = Console.ReadLine();
            group.AddStudent(name);

            Console.WriteLine("Студент " + name + " был успешно зачислен в группу " + group.GetGroupName());

        }
        static void ExpelStudent(Group group) {
            Console.WriteLine("Введите полное имя студента, который будет отчислен");
            string name = Console.ReadLine();
            group.ExpelStudent(name);
            Console.WriteLine("Студент " + name + " был успешно ОТЧИСЛЕН из группы " + group.GetGroupName());
        }
        static void MakeManager(ref Group group) {
            Console.WriteLine("Введите имя нового старосты");
            group.GetManager().DowngradeManager();
            string name = Console.ReadLine();
            group.SearchStudent(name).MakeManager();
        }

        static void ShowManager(Group group) {
            Console.WriteLine("Староста группы " + group.GetGroupName() + " - " + group.GetManager().GetName());
        }

        static void AddGroup() {
            Console.WriteLine("Введите название группы:");
            string groupName = Console.ReadLine();
            groups.Add(new Group(groupName));

        }

        static int[] ReadArray(char din) {

            string s = Console.ReadLine();
            if (s.ElementAt(s.Length - 1) == ' ')
            {
                s = s.Remove(s.Length - 1, 1);
            }
            string[] tokens = s.Split();

            int[] array = new int[tokens.Length];
            for (int i = 0; i < array.Length; i++){
                array[i] = int.Parse(tokens[i]);
            }
            return array;
        }

    }
}
