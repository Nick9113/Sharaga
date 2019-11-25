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
        static void Main(string[] args)
        {

            Console.WriteLine("Укажите размреность матрицы");
            int n = Convert.ToInt16(Console.ReadLine());

            int[,] array = new int[n + 2, n + 2];

            for (int i = 0; i < n + 2; i++)
            {
                for (int j = 0; j < n + 2; j++)
                {
                    if (i == 0 || j == 0 || i == n + 1 || j == n + 1)
                        array[i, j] = -1;
                    else
                        array[i, j] = 0;
                }

            }

            int arrayValue = 0;
            int direction = 0;

            int indexOfLine = 1, indexOfColumn = 1;
            if (n == 1)
                Console.WriteLine(1);
            else
            {
                while (arrayValue < n * n)
                {

                    while (direction == 0)
                    {
                        arrayValue++;
                        if (array[indexOfLine, indexOfColumn + 1] == 0)
                        {
                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfColumn++;
                        }
                        else
                        {
                            if (arrayValue > n * n)
                                break;
                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfLine++;
                            //arrayValue--;
                            direction = 1;
                        }
                    }

                    while (direction == 1)
                    {
                        arrayValue++;
                        if (array[indexOfLine + 1, indexOfColumn] == 0)
                        {

                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfLine++;

                        }
                        else
                        {
                            if (arrayValue > n * n)
                                break;
                            //arrayValue--;
                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfColumn--;
                            direction = 2;
                        }
                    }

                    while (direction == 2)
                    {
                        arrayValue++;
                        if (array[indexOfLine, indexOfColumn - 1] == 0)
                        {
                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfColumn--;
                        }
                        else
                        {
                            if (arrayValue > n * n)
                                break;
                            //arrayValue--;
                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfLine--;
                            direction = 3;
                        }
                    }

                    while (direction == 3)
                    {
                        arrayValue++;
                        if (array[indexOfLine - 1, indexOfColumn] == 0)
                        {
                            //arrayValue++;
                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfLine--;
                        }
                        else
                        {
                            if (arrayValue > n * n)
                                break;
                            //arrayValue--;
                            array[indexOfLine, indexOfColumn] = arrayValue;
                            indexOfColumn++;
                            direction = 0;
                        }
                    }

                }

                //for (int i = 1; i < n + 1; i++)
                //{
                //    for (int j = 1; j < n + 1; j++)
                //    {

                //        Console.Write(array[i, j] + " ");
                //    }
                //    Console.WriteLine();

                //}
            }

            ShowArray(array, n + 2, n + 2);

            Console.Read();

        }

        //static void Main(string[] args) {



        //    Console.Read();
        //}


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
