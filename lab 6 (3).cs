using System;

public class Quaternion
{
    public double W { get; set; } // Скалярна компонента
    public double X { get; set; } // І компонента
    public double Y { get; set; } // J компонента
    public double Z { get; set; } // K компонента

    public Quaternion(double w, double x, double y, double z)
    {
        W = w;
        X = x;
        Y = y;
        Z = z;
    }

    // Перевантажені операції додавання
    public static Quaternion operator +(Quaternion a, Quaternion b)
    {
        return new Quaternion(a.W + b.W, a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    // Перевантажені операції віднімання
    public static Quaternion operator -(Quaternion a, Quaternion b)
    {
        return new Quaternion(a.W - b.W, a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    // Перевантажені операції множення
    public static Quaternion operator *(Quaternion a, Quaternion b)
    {
        double w = a.W * b.W - a.X * b.X - a.Y * b.Y - a.Z * b.Z;
        double x = a.W * b.X + a.X * b.W + a.Y * b.Z - a.Z * b.Y;
        double y = a.W * b.Y - a.X * b.Z + a.Y * b.W + a.Z * b.X;
        double z = a.W * b.Z + a.X * b.Y - a.Y * b.X + a.Z * b.W;

        return new Quaternion(w, x, y, z);
    }

    // Метод для обчислення норми кватерніона
    public double Norm()
    {
        return Math.Sqrt(W * W + X * X + Y * Y + Z * Z);
    }

    // Метод для обчислення спряженого кватерніона
    public Quaternion Conjugate()
    {
        return new Quaternion(W, -X, -Y, -Z);
    }

    // Метод для обчислення інверсного кватерніона
    public Quaternion Inverse()
    {
        double norm = Norm();
        double normSquared = norm * norm;

        if (normSquared == 0)
            throw new InvalidOperationException("Cannot compute inverse for a zero norm quaternion.");

        Quaternion conjugate = Conjugate();
        return new Quaternion(conjugate.W / normSquared, conjugate.X / normSquared, conjugate.Y / normSquared, conjugate.Z / normSquared);
    }

    // Перевантажені операції порівняння
    public static bool operator ==(Quaternion a, Quaternion b)
    {
        return a.W == b.W && a.X == b.X && a.Y == b.Y && a.Z == b.Z;
    }

    public static bool operator !=(Quaternion a, Quaternion b)
    {
        return !(a == b);
    }

    // Метод для конвертації кватерніона в матрицю обертання
    public double[,] ToRotationMatrix()
    {
        double[,] matrix = new double[3, 3];
        double xx = X * X;
        double xy = X * Y;
        double xz = X * Z;
        double xw = X * W;
        double yy = Y * Y;
        double yz = Y * Z;
        double yw = Y * W;
        double zz = Z * Z;
        double zw = Z * W;

        matrix[0, 0] = 1 - 2 * (yy + zz);
        matrix[0, 1] = 2 * (xy - zw);
        matrix[0, 2] = 2 * (xz + yw);
        matrix[1, 0] = 2 * (xy + zw);
        matrix[1, 1] = 1 - 2 * (xx + zz);
        matrix[1, 2] = 2 * (yz - xw);
        matrix[2, 0] = 2 * (xz - yw);
        matrix[2, 1] = 2 * (yz + xw);
        matrix[2, 2] = 1 - 2 * (xx + yy);

        return matrix;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Quaternion q1 = new Quaternion(1, 2, 3, 4);
        Quaternion q2 = new Quaternion(5, 6, 7, 8);

        // Додавання кватерніонів
        Quaternion sum = q1 + q2;
        Console.WriteLine("Sum: " + sum.W + ", " + sum.X + ", " + sum.Y + ", " + sum.Z);

        // Віднімання кватерніонів
        Quaternion difference = q1 - q2;
        Console.WriteLine("Difference: " + difference.W + ", " + difference.X + ", " + difference.Y + ", " + difference.Z);

        // Множення кватерніонів
        Quaternion product = q1 * q2;
        Console.WriteLine("Product: " + product.W + ", " + product.X + ", " + product.Y + ", " + product.Z);

        // Обчислення норми
        double norm = q1.Norm();
        Console.WriteLine("Norm of q1: " + norm);

        // Обчислення спряженого кватерніона
        Quaternion conjugate = q1.Conjugate();
        Console.WriteLine("Conjugate of q1: " + conjugate.W + ", " + conjugate.X + ", " + conjugate.Y + ", " + conjugate.Z);

        // Обчислення інверсного кватерніона
        Quaternion inverse = q1.Inverse();
        Console.WriteLine("Inverse of q1: " + inverse.W + ", " + inverse.X + ", " + inverse.Y + ", " + inverse.Z);

        // Порівняння кватерніонів
        bool areEqual = q1 == q2;
        Console.WriteLine("q1 and q2 are equal: " + areEqual);

        // Конвертація кватерніона в матрицю обертання
        double[,] rotationMatrix = q1.ToRotationMatrix();
        Console.WriteLine("Rotation Matrix:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(rotationMatrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}

