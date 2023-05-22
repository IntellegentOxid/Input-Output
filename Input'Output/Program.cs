using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            int numberA = ReadNumberFromFile("input.txt");
            int numberB = ReadNumberFromFile("output.txt");
            //ps by Viktor Synenko (0_0)
            int count = CountCoPrimes(numberA, numberB);

            Console.WriteLine("Кiлькiсть пар взаємно простих чисел: " + count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

        Console.ReadLine();
    }

    static int ReadNumberFromFile(string fileName)
    {
        // Відкриваємо файл для читання
        using (StreamReader reader = new StreamReader(fileName))
        {
            // Зчитуємо число з файлу
            string numberString = reader.ReadLine();

            // Перетворюємо рядок на ціле число
            if (int.TryParse(numberString, out int number))
            {
                return number;
            }
            else
            {
                throw new Exception("Введiть нормальнi числа будь-ласка, не будь-те як Iван.");
            }
        }
    }

    static int CountCoPrimes(int numberA, int numberB)
    {
        int count = 0;
        for (int i = 1; i <= numberA; i++)
        {
            for (int j = 1; j <= numberB; j++)
            {
                if (GreatestCommonDivisor(i, j) == 1)
                {
                    count++;
                }
            }
        }

        return count;
    }

    static int GreatestCommonDivisor(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }
}
