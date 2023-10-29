using System;
using System.Linq;

public class MathOperations
{
    // Перевантажений метод для додавання двох чисел
    public static int Add(int a, int b)
    {
        return a + b;
    }

    // Перевантажений метод для додавання двох масивів чисел
    public static int[] Add(int[] a, int[] b)
    {
        if (a.Length != b.Length)
        {
            throw new ArgumentException("Arrays must have the same length for addition.");
        }

        int[] result = new int[a.Length];
        for (int i = 0; i < a.Length; i++)
        {
            result[i] = a[i] + b[i];
        }
        return result;
    }

    // Перевантажений метод для додавання двох матриць
    public static int[,] Add(int[,] a, int[,] b)
    {
        if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
        {
            throw new ArgumentException("Matrices must have the same dimensions for addition.");
        }

        int rows = a.GetLength(0);
        int cols = a.GetLength(1);
        int[,] result = new int[rows, cols];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = a[i, j] + b[i, j];
            }
        }
        return result;
    }

}
