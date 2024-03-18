using System;
using System.Text;

class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(double x, double y)
    {
        X = x;
        Y = y;
    }
}

interface IShape
{
    double GetArea();
}

class Triangle : IShape
{
    private Point vertex1, vertex2, vertex3;

    public Triangle(Point vertex1, Point vertex2, Point vertex3)
    {
        this.vertex1 = vertex1;
        this.vertex2 = vertex2;
        this.vertex3 = vertex3;
    }

    public double GetArea()
    {
        double a = CalculateDistance(vertex1, vertex2);
        double b = CalculateDistance(vertex2, vertex3);
        double c = CalculateDistance(vertex3, vertex1);
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    private double CalculateDistance(Point point1, Point point2)
    {
        return Math.Sqrt(Math.Pow(point2.X - point1.X, 2) + Math.Pow(point2.Y - point1.Y, 2));
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("Введіть координати вершин трикутника:");
        Point vertex1 = ReadPoint("Точка 1");
        Point vertex2 = ReadPoint("Точка 2");
        Point vertex3 = ReadPoint("Точка 3");

        IShape triangle = new Triangle(vertex1, vertex2, vertex3);
        Console.WriteLine("Площа трикутника: " + triangle.GetArea());
    }

    static Point ReadPoint(string pointName)
    {
        Console.Write($"{pointName} (x): ");
        double x = double.Parse(Console.ReadLine());
        Console.Write($"{pointName} (y): ");
        double y = double.Parse(Console.ReadLine());
        return new Point(x, y);
    }
}
