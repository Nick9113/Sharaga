using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static Random rnd = new Random();

        const int maxSize = 100;
       
        struct Point {
            public int x;
            public int y;
            
            public Point(int x, int y) {
                this.x = x;
                this.y = y;
            }

            public void ShowPoint() {
                Console.Write("(" + this.x + "; " + this.y +")");
            }

        };

        struct Window {
            public Point LT, RT, RB, LB;
            public bool visibility;

            public Window(Point LT, Point RT, Point RB, Point LB) {
                this.LT = LT;
                this.RT = RT;
                this.RB = RB;
                this.LB = LB;
                this.visibility = true;
            }


            public void ShowWindow() {
                Console.Write("LT = ");
                this.LT.ShowPoint();
                Console.Write(" RT = ");
                this.RT.ShowPoint();
                Console.Write(" RB = ");
                this.RB.ShowPoint();
                Console.Write(" LB = ");
                this.LB.ShowPoint();
                Console.WriteLine();
            }
        };

        static void Main(string[] args)
        {
            int n = 9;

            Window[] windows = new Window[n];

            for (int i = 0; i < n; i++)
            {
                windows[i] = ReadWindow();
                //Console.Write(i + ". ");
                //windows[i].ShowWindow();
            }
            for (int i = 0; i < n; i++) {
                for (int j = i+1; j < n; j++) {
                    windows[i].visibility = isVisibile(windows[i], windows[j]);
                }
            }

            int counter = n;
            for (int i = 0; i < n; i++) {
                if (windows[i].visibility)
                    counter--;
            }
            Console.WriteLine(counter + " - столько окон вы видите " );

            Console.Read();

        }
        static Window ReadWindow() {
            Point LT = ReadPoint();
            Point RT = ReadPoint();
            Point RB = ReadPoint();
            Point LB = ReadPoint();
            return new Window(LT, RT, RB, LB);

        }
        static Window GenerateWindow() {
            Point LT, RT, RB, LB;

            LB = GeneratePoint();
            RT = GeneratePoint(LB.x, LB.y);
            LT = new Point(LB.x, RT.y);
            RB = new Point(RT.x, LB.y);

            return new Window(LT, RT, RB, LB);


        }

        static Point ReadPoint() {
            string s = Console.ReadLine();
            string[] tokens = s.Split();

            int x = int.Parse(tokens[0]);
            int y = int.Parse(tokens[1]);

            return new Point(x,y);
        }
        static Point GeneratePoint(int minX = 0, int minY = 0) {
            return new Point(rnd.Next(minX + 1, maxSize), rnd.Next(minY + 1, maxSize));
        }

        static bool isVisibile(Window w1, Window w2) {
            if ( w1.LT.x > w2.RT.x || w1.RT.x < w2.LT.x || w1.LT.y < w2.LB.y || w1.LB.y > w2.LT.y) 
                return true;
            else 
                return false;
        }




        static void Speak() {
            int n, m, value;
            Console.Write("Одномерный массив какой размерности Вы хотите создать? \n n = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Какой диапазон значений? \n value = ");
            value = Convert.ToInt32(Console.ReadLine());

            int[] array1d = CreateArray(n, value);
            ShowArray(array1d);

            Console.Write("Сколько строк будет в Вашем двумерном масиве? \n n = ");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Сколько столбцов будет в Вашем двумерном масиве? \n m = ");
            m = Convert.ToInt32(Console.ReadLine());
            Console.Write("Какой диапазон значений? \n value = ");
            value = Convert.ToInt32(Console.ReadLine());

            int[,] array2d = CreateArray(n, m, value);
            ShowArray(array2d, n, m);

            Console.Write(" Хотите ввести свои значения для ОДНОМЕРНОГО массива? \n [0-нет, 1-да] = ");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                Console.WriteLine("Введите через пробел значения в вашем массиве");
                int[] myArray = ReadArray(' ');
                ShowArray(myArray);
            }
            Console.Write(" Хотите ввести свои значения для ДВУМЕРНОГО массива? \n [0-нет, 1-да] = ");
            if (Convert.ToInt32(Console.ReadLine()) == 1)
            {
                Console.Write("Сколько строк будет в Вашем двумерном масиве? \n n = ");
                n = Convert.ToInt32(Console.ReadLine());
                Console.Write("Сколько столбцов будет в Вашем двумерном масиве? \n m = ");
                m = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите через пробел значения через пробел. А в конце каждой строки нажмите enter!");
                int[,] myArray2d = ReadArray(n, m, ' ');
                ShowArray(myArray2d, n, m);
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

        static int[,] ReadArray(int n, int m, char din) {
            int[,] array = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string s = Console.ReadLine();
                if (s.ElementAt(s.Length - 1) == ' ')
                    s = s.Remove(s.Length - 1, 1);
                string[] tokens = s.Split();

                for (int j = 0; j < tokens.Length; j++)
                {
                    array[i, j] = Convert.ToInt32(tokens[j]);
                }

            }

            return array;
        }

        static int[] CreateArray(int n, int value) {
            int[] array = new int[n];
            for (int i = 0; i < n; i++){
                array[i] = rnd.Next(value / -2, value / 2);
            }
            return array;
        }
       
        static int[,] CreateArray(int n, int m, int value) {
            int[,] array = new int[n, m];

            for (int i = 0; i < n; i++){
                for (int j = 0; j < m; j++){
                    array[i, j] = rnd.Next(value / -2, value / 2);
                }
            }

            return array;

        }

        static void ShowArray(int[] array) {
            Console.Write("\n");
            for (int i = 0; i < array.Length; i++){
               Console.Write(array[i] + " ");
            }

        }

        static void ShowArray(int[,] array, int n, int m){
            Console.WriteLine("Ваш двумерный масив: \n");

            for (int i = 0; i < n; i++)
            {
               

                for (int j = 0; j < m; j++)
                {
                    
                        Console.Write(array[i, j] + " ");
                }
                Console.WriteLine();

            }


        }

        static int[] SortArray(int[] array, int method) {
            // Method - вид сортировки, если method > 0 то по неубыванию, иначе по невозрастанию
            if (method > 0)
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = i; j < array.Length; j++)
                        if (array[i] > array[j])
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
            }
            else{
                for (int i = 0; i < array.Length; i++)
                    for (int j = i; j < array.Length; j++)
                        if (array[i] < array[j])
                        {
                            int temp = array[i];
                            array[i] = array[j];
                            array[j] = temp;
                        }
            }
            return array;
        }

        static int[][] SortArrayOfArray(int[][] array, int method, int indexCompare ) {
            // Method - вид сортировки, если method > 0 то по неубыванию, иначе по невозрастанию

            if (method > 0)
            {
                for (int i = 0; i < array.Length; i++)
                    for (int j = i; j < array.Length; j++)
                        if (array[i][indexCompare] > array[j][indexCompare])
                        {
                            int temp = array[i][indexCompare];
                            array[i][indexCompare] = array[j][indexCompare];
                            array[j][indexCompare] = temp;
                        }

            } else {
                for (int i = 0; i < array.Length; i++)
                    for (int j = i; j < array.Length; j++)
                        if (array[i][indexCompare] < array[j][indexCompare])
                        {
                            int temp = array[i][indexCompare];
                            array[i][indexCompare] = array[j][indexCompare];
                            array[j][indexCompare] = temp;
                        }
            }
            
            return array;
        }

        static int[,] SortArrayLines(int[,] array, int n, int m, int indexCompare, int method) {
            // mehod > 0 => По неубыванию, else => По невозрастанию
            // m >= indexCompare !!!

            if (method > 0)
            {
                for (int i = 0; i < n; i++)
                    for (int j = i; j < n; j++)
                        if (array[i, indexCompare] > array[j, indexCompare])
                        {
                            int temp = array[i, indexCompare];
                            array[i, indexCompare] = array[j, indexCompare];
                            array[j, indexCompare] = temp;
                        }
            }
            else {
                for (int i = 0; i < n; i++)
                    for (int j = i; j < n; j++)
                        if (array[i, indexCompare] < array[j, indexCompare])
                        {
                            int temp = array[i, indexCompare];
                            array[i, indexCompare] = array[j, indexCompare];
                            array[j, indexCompare] = temp;
                        }
            }

            return array;
        }

        static int[,] SortArrayColumns(int[,] array, int n, int m, int indexCompare, int method) {
            
            for (int i = 0; i < m; i++)
                for (int j = i; j < m; j++)
                    if (array[indexCompare, i] > array[indexCompare, j])
                    {
                        int temp = array[indexCompare, i];
                        array[indexCompare, i] = array[indexCompare, i];
                        array[indexCompare, i] = temp;
                    }
            return array;
        }

        static int[,] ReplaceArrayLine(int[,] array, int n, int m, int indexOfLine, int indexOfLinePlace) {

            for (int i = 0; i < m; i++)
            {
                int temp = array[indexOfLinePlace, i];
                array[indexOfLinePlace, i] = array[indexOfLine, i];
                array[indexOfLine, i] = temp;
            }
            return array;
        }

        static int[,] ReplaceArrayColumn(int[,] array, int n, int m, int indexOfColumn, int indexOfColumnPlace) {
            for (int i = 0; i < n; i++)
            {
                int temp = array[i, indexOfColumnPlace];
                array[i, indexOfColumnPlace] = array[i, indexOfColumn];
                array[i, indexOfColumn] = temp;
            }

            return array;
        }

        

    }
}
