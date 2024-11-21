using System;

class Program
{
    static void Main(string[] args)
    {
        // Задание 1
        Console.WriteLine("Задание 1: Вывод массива и обмен элементами.");
        int[] numbers = GenerateRandomArray(20);
        PrintArray(numbers);
        Console.Write("Введите первый индекс для обмена: ");
        int index1 = int.Parse(Console.ReadLine());
        Console.Write("Введите второй индекс для обмена: ");
        int index2 = int.Parse(Console.ReadLine());
        SwapElements(numbers, index1, index2);
        PrintArray(numbers);
        Console.WriteLine();

        // Задание 2
        Console.WriteLine("Задание 2: Обработка массива.");
        PrintAndCalculateArrayStats(numbers);

        // Задание 3
        Console.WriteLine("Задание 3: Ввод и вывод изображений цифр.");
        HandleUserInput();

        // Задание 4
        Console.WriteLine("Задание 4: Структура Дед и его ворчливость.");
        HandleGrandfather();
    }

    // Задание 1: Генерация массива
    static int[] GenerateRandomArray(int size)
    {
        Random rand = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(1, 101); // Случайное число от 1 до 100
        }
        return array;
    }

    static void PrintArray(int[] array)
    {
        Console.WriteLine("[" + string.Join(", ", array) + "]");
    }

    static void SwapElements(int[] array, int index1, int index2)
    {
        if (index1 < array.Length && index2 < array.Length)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }
        else
        {
            Console.WriteLine("Некорректные индексы.");
        }
    }

    // Задание 2: Обработка массива
    static void PrintAndCalculateArrayStats(int[] array)
    {
        int sum = SumArray(array);
        long product = 1; // начальное произведение
        double average;

        CalculateArrayStats(array, ref product, out average);

        Console.WriteLine($"Сумма: {sum}");
        Console.WriteLine($"Произведение: {product}");
        Console.WriteLine($"Среднее арифметическое: {average}");
    }

    static int SumArray(int[] array)
    {
        int sum = 0;
        foreach (int number in array)
        {
            sum += number;
        }
        return sum;
    }

    static void CalculateArrayStats(int[] array, ref long product, out double average)
    {
        int sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
            sum += array[i];
        }
        average = (double)sum / array.Length;
    }

    // Задание 3
    static void HandleUserInput()
    {
        while (true)
        {
            Console.Write("Введите число (или 'exit' для выхода): ");
            string input = Console.ReadLine();

            if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                break;

            try
            {
                int number = int.Parse(input);
                if (number >= 0 && number <= 9)
                {
                    DrawNumber(number);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка: число должно быть от 0 до 9.");
                    Console.ResetColor();
                    System.Threading.Thread.Sleep(3000); // задержка 3 секунды
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: введено не число.");
            }
        }

        void DrawNumber(int number)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("###\n# #\n# #\n# #\n###"); break;
                case 1:
                    Console.WriteLine("  #\n  #\n  #\n  #\n  #");
                    break;
                case 2:
                    Console.WriteLine("###\n  #\n###\n#  \n###");
                    break;
                default: Console.WriteLine("Неизвестная цифра."); break;
            }
        }
    }

    // Задание 4
    struct Grandfather
    {
        public string Name;
        public LevelOfGrumpiness GrumpinessLevel;
        public string[] GripingPhrases;
        public int BruisesCount;

        public Grandfather(string name, LevelOfGrumpiness level, string[] phrases)
        {
            Name = name;
            GrumpinessLevel = level;
            GripingPhrases = phrases;
            BruisesCount = 0;
        }

        public int CheckProfanity(string[] badWords)
        {
            foreach (string phrase in GripingPhrases)
            {
                foreach (string badWord in badWords)
                {
                    if (phrase.Contains(badWord))
                    {
                        BruisesCount++;
                    }
                }
            }
            return BruisesCount;
        }
    }

    enum LevelOfGrumpiness
    {
        Mild,
        Moderate,
        Severe
    }

    static void HandleGrandfather()
    {
        Grandfather[] grandpas = new Grandfather[5];
        grandpas[0] = new Grandfather("Дедушка А", LevelOfGrumpiness.Mild, new string[] { "Гады!", "Куда катится мир!" });
        grandpas[1] = new Grandfather("Дедушка Б", LevelOfGrumpiness.Moderate, new string[] { "Негодяи!", "Совсем обнаглели!" });
        grandpas[2] = new Grandfather("Дедушка В", LevelOfGrumpiness.Severe, new string[] { "Ох, ё-моё!", "Что за безобразие!" });
        grandpas[3] = new Grandfather("Дедушка Г", LevelOfGrumpiness.Mild, new string[] { "Проститутки!", "Откуда ноги растут?" });
        grandpas[4] = new Grandfather("Дедушка Д", LevelOfGrumpiness.Moderate, new string[] { "Гады!", "Пора на пенсию!" });

        string[] badWords = { "Гады", "Проститутки" }; // задаем матерные слова
        foreach (var grandpa in grandpas)
        {
            int bruises = grandpa.CheckProfanity(badWords);
            Console.WriteLine($"{grandpa.Name} получил {bruises} синяков.");
        }
    }
}