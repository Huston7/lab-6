using System;
using System.Collections.Generic;

// Абстрактний клас GraphicPrimitive
public abstract class GraphicPrimitive
{
    public int X { get; set; }
    public int Y { get; set; }

    public abstract void Draw();
    public abstract void Move(int x, int y);
    public abstract void Scale(float factor);
}

// Клас Circle
public class Circle : GraphicPrimitive
{
    public int Radius { get; set; }

    public Circle(int x, int y, int radius)
    {
        X = x;
        Y = y;
        Radius = radius;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a circle at ({X}, {Y}) with radius {Radius}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Radius = (int)(Radius * factor);
    }
}

// Клас Rectangle
public class Rectangle : GraphicPrimitive
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height = height;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a rectangle at ({X}, {Y}) with width {Width} and height {Height}");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        Width = (int)(Width * factor);
        Height = (int)(Height * factor);
    }
}

// Клас Triangle
public class Triangle : GraphicPrimitive
{
    public Triangle(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a triangle at ({X}, {Y})");
    }

    public override void Move(int x, int y)
    {
        X += x;
        Y += y;
    }

    public override void Scale(float factor)
    {
        // Немає масштабу для трикутника в цьому прикладі
    }
}

// Клас Group, який дозволяє групувати фігури
public class Group : GraphicPrimitive
{
    private List<GraphicPrimitive> elements = new List<GraphicPrimitive>();

    public void AddElement(GraphicPrimitive element)
    {
        elements.Add(element);
    }

    public override void Draw()
    {
        Console.WriteLine("Drawing a group:");
        foreach (var element in elements)
        {
            element.Draw();
        }
    }

    public override void Move(int x, int y)
    {
        foreach (var element in elements)
        {
            element.Move(x, y);
        }
    }

    public override void Scale(float factor)
    {
        foreach (var element in elements)
        {
            element.Scale(factor);
        }
    }
}

// Клас GraphicsEditor для керування фігурами
public class GraphicsEditor
{
    private List<GraphicPrimitive> primitives = new List<GraphicPrimitive>();

    public void AddPrimitive(GraphicPrimitive primitive)
    {
        primitives.Add(primitive);
    }

    public void DrawAll()
    {
        foreach (var primitive in primitives)
        {
            primitive.Draw();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GraphicsEditor editor = new GraphicsEditor();

        Circle circle = new Circle(10, 10, 5);
        Rectangle rectangle = new Rectangle(20, 20, 8, 6);
        Triangle triangle = new Triangle(30, 30);

        Group group = new Group();
        group.AddElement(circle);
        group.AddElement(rectangle);

        editor.AddPrimitive(circle);
        editor.AddPrimitive(rectangle);
        editor.AddPrimitive(triangle);
        editor.AddPrimitive(group);

        editor.DrawAll();

        // Переміщення та масштабування
        circle.Move(5, 5);
        rectangle.Scale(2);

        Console.WriteLine("After transformations:");
        editor.DrawAll();
    }
}

