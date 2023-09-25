using System;

class Ar
{
    private int n;
    private int[] a;
    private int s;

    public int N
    {
        get { return n; }
    }

    public int S
    {
        get { return s; }
    }

    public Ar(int n, int x)
    {
        this.n = n;
        a = new int[n];
        Random random = new Random();

        for (int i = 0; i < n; i++)
            a[i] = random.Next(-x, x + 1);

        CalculateSumOfNegatives();
    }

    public Ar(string input)
    {
        string[] numbers = input.Split(' ');
        n = numbers.Length;
        a = new int[n];

        for (int i = 0; i < n; i++)
        {
            a[i] = int.Parse(numbers[i]);
        }

        CalculateSumOfNegatives();
    }

    public void Print()
    {
        for (int i = 0; i < n; i++)
            Console.Write(a[i] + " ");
        Console.WriteLine();
    }

    public int P()
    {
        for (int i = n - 1; i >= 0; i--)
        {
            if (a[i] % 7 == 0)
                return i;
        }
        return -1;
    }

    public int Pr(int i1, int i2)
    {
        int product = 1;
        for (int i = i1; i <= i2; i++)
        {
            product *= a[i];
        }
        return product;
    }

    private void CalculateSumOfNegatives()
    {
        s = 0;
        for (int i = 0; i < n; i++)
        {
            if (a[i] < 0)
                s += a[i];
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите номер конструктора (1 или 2):");
        int constructorNumber = int.Parse(Console.ReadLine());

        Ar ar;

        if (constructorNumber == 1)
        {
            Console.Write("Введите количество элементов в массиве: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write("Введите значение x: ");
            int x = int.Parse(Console.ReadLine());

            ar = new Ar(n, x);
        }
        else if (constructorNumber == 2)
        {
            Console.Write("Введите числа, разделенные пробелами: ");
            string input = Console.ReadLine();

            ar = new Ar(input);
        }
        else
        {
            Console.WriteLine("Неправильный номер конструктора.");
            return;
        }

        Console.WriteLine("Элементы массива:");
        ar.Print();

        Console.WriteLine("Сумма отрицательных элементов: " + ar.S);

        int lastIndexMultipleOf7 = ar.P();
        if (lastIndexMultipleOf7 != -1)
        {
            Console.WriteLine("Индекс последнего кратного 7 элемента: " + lastIndexMultipleOf7);

            int productBeforeIndex = ar.Pr(0, lastIndexMultipleOf7);

            Console.WriteLine("Произведение элементов до последнего кратного 7: " + productBeforeIndex);
        }
        else
        {
            Console.WriteLine("Нет элемента, кратного 7.");
        }
    }
}