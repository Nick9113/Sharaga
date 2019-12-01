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
           
            private void sendMessage(string error) {
                Console.WriteLine("ERROR: " + error);
            }

            public void ShowStudent() {
                Console.WriteLine(fullName + ", группа: " + group );
            }

          

        }

        struct Group {
            private List<Student> students;
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

            public void ExpelStident(string fullName) {
                students.Remove(SearchStudent(fullName));
            }

            public void ShowGroup() {
                Console.WriteLine(groupName + ":");
                foreach (Student item in students) {
                    Console.WriteLine(item.GetName());
                }
            }

            private Student SearchStudent(string fullName) {
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
       
        
        static void Main(string[] args)
        {
            Console.WriteLine("Введите нужный Вам номер пункта меню:");
            string[] tokens = new string[4] {"Создать группу", "Назначить старосту", "Добавить студента", "Завершить работу"};

            for (int i = 0; i < tokens.Length; i++) {
                Console.WriteLine((i+1) + " - " +tokens[i]);
            }

            while (true) {
                string item = Console.ReadLine();
                switch (item) {
                    case "1":
                        // Создать группу
                        break;
                    case "2":
                        // Назначить стросту
                        break;

                    case "3":
                        // Добавить студента
                        break;

                    case "4":
                        // Завершить работу
                        break;
                    default:
                        // Вывести ошибку
                        break;
             
                
                }
            }




            Console.Read();
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
