using System;

class Program
{
    static void Main(string[] args)
    {
        // Упражнение 5.1
        Exercise5_1();

        // Упражнение 5.2
        Exercise5_2();

        // Упражнение 5.3
        Exercise5_3();

        // Упражнение 5.4
        Exercise5_4();

        // Домашнее задание 5.1
        Homework5_1();

        // Домашнее задание 5.2
        Homework5_2();
    }

    // Упражнение 5.1
    static void Exercise5_1()
    {
        Console.WriteLine("Упражнение 5.1");
        Console.Write("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());
        int max = GetMax(a, b);
        Console.WriteLine($"Максимальное число между {a} и {b} это {max}");
        Console.WriteLine();
    }

    static int GetMax(int a, int b)
    {
        return a > b ? a : b;
    }

    // Упражнение 5.2
    static void Exercise5_2()
    {
        Console.WriteLine("Упражнение 5.2");
        Console.Write("Введите первое число: ");
        int x = int.Parse(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int y = int.Parse(Console.ReadLine());
        Swap(ref x, ref y);
        Console.WriteLine($" {x}, {y}");
    }

    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    // Упражнение 5.3
    static void Exercise5_3()
    {
        Console.WriteLine("Упражнение 5.3");
        Console.Write("Введите число для вычисления факториала: ");
        int number = int.Parse(Console.ReadLine());
        if (CalculateFactorial(number, out long factorialResult))
        {
            Console.WriteLine($"Факториал числа {number} = {factorialResult}");
        }
        else
        {
            Console.WriteLine("Переполнение при вычислении факториала.");
        }
        Console.WriteLine();
    }

    static bool CalculateFactorial(int number, out long result)
    {
        result = 1;
        try
        {
            for (int i = 1; i <= number; i++)
            {
                checked
                {
                    result *= i;
                }
            }
            return true;
        }
        catch (OverflowException)
        {
            return false;
        }
    }

    // Упражнение 5.4
    static void Exercise5_4()
    {
        Console.WriteLine("Упражнение 5.4");
        Console.Write("Введите число для вычисления факториала(рекурсивно): ");
        int number = int.Parse(Console.ReadLine());
        long recursiveResult = RecursiveFactorial(number);
        Console.WriteLine($"Факториал числа {number} (рекурсивный) = {recursiveResult}");
        Console.WriteLine();
    }

    static long RecursiveFactorial(int number)
    {
        if (number <= 1) return 1;
        return number * RecursiveFactorial(number - 1);
    }

    // Домашнее задание 5.1
    static void Homework5_1()
    {
        Console.WriteLine("Домашнее задание 5.1");
        Console.Write("Введите первое натуральное число: ");
        int firstNumber = int.Parse(Console.ReadLine());
        Console.Write("Введите второе натуральное число: ");
        int secondNumber = int.Parse(Console.ReadLine());
        int gcd = GCD(firstNumber, secondNumber);
        Console.WriteLine($"НОД чисел {firstNumber} и {secondNumber} = {gcd}");

        Console.WriteLine("НОД трех чисел");
        Console.Write("Введите третье натуральное число: ");
        int thirdNumber = int.Parse(Console.ReadLine());
        int gcdThree = GCD(firstNumber, secondNumber, thirdNumber);
        Console.WriteLine($"НОД чисел {firstNumber}, {secondNumber} и {thirdNumber} = {gcdThree}");
        Console.WriteLine();
    }
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static int GCD(int a, int b, int c)
    {
        return GCD(GCD(a, b), c);
    }

    // Домашнее задание 5.2
    static void Homework5_2()
    {
        Console.WriteLine("Домашнее задание 5.2");
        Console.Write("Введите номер n (n >= 1): ");
        int n = int.Parse(Console.ReadLine());
        long fibonacciResult = Fibonacci(n);
        Console.WriteLine($"Число Фибоначчи для n = {n} это {fibonacciResult}");
    }

    static long Fibonacci(int n)
    {
        if (n <= 1) return n;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }
}