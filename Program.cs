using System;

namespace PracticalWorks
{
    class Program
    {
        static void Main(string[] args)
        {

            PracticalWork_1();
            PracticalWork_2();
            PracticalWork_3();
            PracticalWork_4();
            PracticalWork_5();
            PracticalWork_6();
            PracticalWork_7();
        
        }

        static void PracticalWork_1()
        {
            Console.WriteLine("Практическая работа №1");

            Console.WriteLine("Введите трехзначное число");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("квадрат заданного трехзначного числа равен куб суммы цифр этого числа - ");
            if (n * n == Math.Pow(n / 100 + n % 100 / 10 + n % 10, 3))
            {
                Console.WriteLine("True");
            }
            else
                Console.WriteLine("False");



            Console.WriteLine("Введите четырехзначное число");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("сумма двух первых цифр заданного четырехзначного числа равна сумме двух его последних циф - ");
            if (n / 1000 + n % 1000 / 100 == n % 100 / 10 + n % 10)
            {
                Console.WriteLine("True");
            }
            else
                Console.WriteLine("False");


            Console.WriteLine("Введите трехзначное число");
            n = Convert.ToInt32(Console.ReadLine());
            Console.Write("среди цифр заданного трехзначного числа есть одинаковые - ");
            string str = n.ToString();
            bool fl = false;
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                    if (str[i] == str[j])
                        fl = true;
            }
            Console.WriteLine(fl);


            Console.WriteLine("Введите вещественное положительное число");
            double d = Convert.ToDouble(Console.ReadLine());
            str = d.ToString();
            bool hasMontice = false;
            fl = false;

            Console.WriteLine("Ваiе число: " + str);
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ',')
                    hasMontice = true;
                if (hasMontice)
                {
                    for (int j = 1; j < 3; j++)
                    {
                        if (str[i + j] == '0')
                            fl = true;
                    }
                    break;
                }

            }
            Console.WriteLine("среди первых трех цифр из дробной части заданного положительного вещественного числа есть цифра 0 - " + fl);

        }

        static void PracticalWork_2() {
            Console.WriteLine("Практическая работа №2");

            Console.WriteLine("Введите натруальное число n");
            int n = Convert.ToInt32(Console.ReadLine());
            double answer = 1;
            int f = 1; 
            for (int i = 1; i <= n; i++) {
                f *= i;
                answer *= 2 + (double)1/f;
            }
            Console.WriteLine("Ответ: " + answer);
        }

        static void PracticalWork_3() { 
            Console.WriteLine("Практическая работа №3");

            int d0 = 1, 
                d1 = 3;
            double value = 1.0 /(d0*d1),
                e = 0.75;
            int i = 1;
            Console.WriteLine(i+ ": "+ Math.Abs(value));

            while (Math.Abs(value) >= e) {
                d0++;
                d1++;
                i++;
                Console.WriteLine(i+ ": "+ Math.Abs(value));
                value += 1.0 / (d0 * d1);
            }
            Console.WriteLine("End. Сумма оказалась меньше либо равна");



        }

        static void PracticalWork_4() {
            Console.WriteLine("Практическая работа №4");

            Console.Write("Двузначное число, которое равно утроенному произведению его цифирок: ");
            int answer = 0;

            for (int i = 10; i < 100; i++)
            {
                if (i == 3 * (i % 10) * (i / 10))
                {
                    answer = i;
                    Console.Write(answer + ", ");
                }
            }

            Console.WriteLine();

        }

        static void PracticalWork_5() {
            Console.WriteLine("Практическая работа №5");

            string str = "11";
            Console.WriteLine("Введите число k");
            int k = Convert.ToInt32(Console.ReadLine());
            int f0 = 1;
            int f1 = 1;
            for (int i = 0; i < k; i++) {
                if (str.Length >= k)
                    break;
                int fc = f0 + f1;
                f0 = f1;
                f1 = fc;

                str = str + fc.ToString();
            }
            
            Console.WriteLine("k-ый символ последовательности [ " + str + "... ]: " + str[k-1]);
        }
        
        static void PracticalWork_6() {
            Console.WriteLine("Практическая работа №6");

            Console.Write("n = ");
            int n = Convert.ToInt32(Console.ReadLine());
            int[] array = new int[n];
            Console.WriteLine("Ввидите n чисел. Каждое число с новой строки");

            for (int i = 0; i < n; i++) { 
                array[i] = Convert.ToInt32(Console.ReadLine());
            }
            
            Console.Write("Ваш массив: ");
            for (int i = 0; i < n; i++) {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            int[] arrayB = new int[n];

            int k = 0;
            for (int i = n - 1; i >= 0; i--) {
                arrayB[k] = array[i];
                k++;
            }

            for (int i = 0; i < n; i++)
            {
                Console.Write(arrayB[i] + " ");
            }
        }
    
        static void PracticalWork_7()
        {
            Console.WriteLine("Практическая работа №7");

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

                for (int i = 1; i < n + 1; i++)
                {
                    for (int j = 1; j < n + 1; j++)
                    {

                        Console.Write(array[i, j] + " ");
                    }
                    Console.WriteLine();

                }
            }


        }
    }
}