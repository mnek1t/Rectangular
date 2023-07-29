using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rectangular
{
    internal class Program
    {
        abstract class Dot
        {
            public int X;
            public int Y;
        }
        class Rectangular : Dot
        {
            public Rectangular() { }
            public Rectangular(int x, int y)
            {
                X = x;
                Y = y;
            }
            public Dot CreateThirdDot(Dot dot1, Dot dot2) 
            {
                Dot dot3 = new Rectangular(dot1.X, dot2.Y);
                return dot3;
            }
            public bool IsDotonTheSameLine(Dot dot1, Dot dot2) 
            {
                if (dot1.X != dot2.X && dot1.Y != dot2.Y)
                {
                    return true;
                }
                else return false;
            }
            public (double,double) CalculateSide(Dot dot1,Dot dot2, Dot dot3) 
            {
                double deltaX1 = dot1.X - dot3.X;
                double deltaY1 = dot1.Y - dot3.Y;
                double deltaX2 = dot2.X - dot3.X;
                double deltaY2 = dot2.Y - dot3.Y;
                double side1 = Math.Sqrt(deltaX1 * deltaX1 + deltaY1 * deltaY1);
                double side2 = Math.Sqrt(deltaX2 * deltaX2 + deltaY2 * deltaY2);
                return (side1,side2);
            }
            public double Area(double side1, double side2) 
            {
                return side1 * side2;
            }
            public double Perimeter(double side1, double side2) 
            {
                return (side1 + side2) * 2;
            }
        }
        static void Main(string[] args)
        {
            Dot dot1 = new Rectangular(1, 1);
            Dot dot2 = new Rectangular(2, 2);
            Rectangular rec = new Rectangular();
            bool check = rec.IsDotonTheSameLine(dot1,dot2);
            if (check)
            {
                rec.CreateThirdDot(dot1,dot2);

                double side1 = rec.CalculateSide(dot1,dot2,rec.CreateThirdDot(dot1,dot2)).Item1;
                double side2 = rec.CalculateSide(dot1,dot2,rec.CreateThirdDot(dot1,dot2)).Item2;

                Console.WriteLine($"Side1 = {side1}, Side2 = {side2}");
                Console.WriteLine($"Perimeter = {rec.Perimeter(side1,side2)}");
                Console.WriteLine($"Area =  {rec.Area(side1,side2)}");
            }
            else
            {
                Console.WriteLine("You wrongly entered coordinates for realizing rectangular. Dots are located on the same line!");
            }
            
        }
    }
}
