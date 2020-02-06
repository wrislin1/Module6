/* 
 Widler Rislin
 11/15/2019
 CEN 4370C
 Module 6 Assignment
 This Program prompts the user for input to find the area of either a Circle, 
 Square or Rectangle and the Circumference and perimeter of a circle and 
 rectangle respectively. It uses a shape class and features 
 a Circle,Square and Rectangle subclasses.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module6
{
    class Program
    {
       class Shape  //Shape Class
        {
            public double area, perimeter;
            public int num_sides;
           public string type;
            public Shape(string type="None",int num_sides=0)  // Shape class contructor with optional parameters
            {
                area = 0;
                perimeter = 0;
                this.type=type;
                this.num_sides = num_sides;
            }

            public virtual double CalculateArea()  //virtual function tocalculate area
            { return 0; }

            public virtual double CalculatePerim() //virtualfunctionto calculate perimeter
            { return 0; }

         

        }
        class Circle : Shape // Circle subclass
        {
            public double radius, circumference;
            
            public Circle() //parameterless constructor
            { }
            public Circle(double radius = 0):base("Circle",0)  // Circle object constructor with an optional parameter, calls base constructor
            {
                this.radius = radius;
                area = 0;
            }

            public override double CalculateArea() //overidded CalculateArea function
            {
                return Math.PI * Math.Pow(radius, 2);
            }

            public override double CalculatePerim() //overidded CalculatePerim function
            { return 2 * Math.PI * radius; }

        }

        class Rectangle :Shape // Rectangele object definitions
        {
            public double base1, height;

            public Rectangle()
            { }
            public Rectangle(double base1 = 0, double height = 0):base("Rectangle",4) // Constructor with optional parameters, calls base class
            {
                this.base1 = base1;
                this.height = height;

            }

            public override double CalculateArea() //overidded CalculateArea function
            {
                return base1 * height;
            }

            public override double CalculatePerim() //overidded CalculatePerim functio
            { return (2 * base1) + (2 * height); }

         
        }

        class Triangle:Shape  // Triangle object and definitions
        {
            public double base1, height;

            public Triangle(double base1 = 0, double height = 0):base("Triangle",3)  // Constructor with optional parameters,calls base class
            {
                this.base1 = base1;
                this.height = height;

            }

            public override double CalculateArea() //overidded CalculateArea function
            {
                return (base1 * height) / 2;
            }



        }
        static void Main(string[] args)
        {
            int opt = 0; // Variable holding user selection
                         // variable holding area value.

            while (opt != 4) // Loops through selection menu, checks for escape character.
            {
                opt = 0; // resets user selection to 0
                Console.WriteLine("Please enter a Selection");    // Selection Menu
                Console.WriteLine("1. Area of a Circle");
                Console.WriteLine("2. Area of a Rectangle");
                Console.WriteLine("3. Area of a Triangle");
                Console.WriteLine("4. Exit Program");
                Console.WriteLine();

                try //Checking for invalid inputs
                {
                    opt = int.Parse(Console.ReadLine());
                    if (opt < 1 || opt > 4)
                        throw new Exception();
                }
                catch
                {
                    Console.WriteLine();
                    Console.Write("Input Not Valid, Please try again: ");    // Prompts user for new input
                    Console.WriteLine();

                }
                switch (opt)   // Checks user selection and creates appropriate object
                {
                    case 1:
                        Circle circ = new Circle();   // Creates new circle object
                        CirclePrompt(ref circ);
                        if (circ.area == 0)     // If area is 0 the eescape character was pressed
                        {
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Area of the Circle = " + circ.area); //outputs area
                        Console.WriteLine("Circumference of the Circle = " + circ.circumference);
                        break;
                    case 2:
                        Rectangle rec = new Rectangle();  // Creates new Rectangle object
                        RectanglePrompt(ref rec);
                        if (rec.area == 0)  // If area is 0 the eescape character was pressed
                        {
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Area of the Rectangle = " + rec.area);
                        Console.WriteLine("Perimeter of the Rectangle = " + rec.perimeter);
                        break;
                    case 3:
                        Triangle tri = new Triangle(); // Creates new Triangle object
                        TrianglePrompt(ref tri);
                        if (tri.area == 0)   // If area is 0 the eescape character was pressed
                        {
                            break;
                        }
                        Console.WriteLine();
                        Console.WriteLine("Area of the Triangle = " + tri.area);
                        break;
                }
                Console.WriteLine();
            }
        }

        static void CirclePrompt(ref Circle circ) // Prompts user for Circle radius
        {
            string c;       // escape character check

            Console.WriteLine();
            Console.WriteLine("Press x to return to the Menu");
            Console.WriteLine();                                 // Prompts user for input
            Console.Write("Please enter the Radius of the Circle: ");

            while (circ.radius <= 0)
            {
                c = Console.ReadLine(); // stores user input
                if (c == "x" || c == "X")  // checks for escape character
                {
                    circ.radius = 0;
                    break;
                }
                try // checks for valid input
                {
                    circ.radius = double.Parse(c);
                    if (circ.radius <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.Write("Invalid Input, Please enter a valid Radius: "); // prompts user for valid input

                }

            }
            circ.area = circ.CalculateArea();   // computes area and circumference
            circ.circumference = circ.CalculatePerim();
            circ.perimeter = circ.circumference;
        }

        static void RectanglePrompt(ref Rectangle rec) //Prompts user for Rectangle base and height
        {
            string c; // escape character check


            Console.WriteLine();
            Console.WriteLine("Press x to return to the Menu");
            Console.WriteLine(); //prompts user for input
            Console.Write("Please enter the Base of the Rectangle: ");

            while (rec.base1 <= 0)
            {
                c = Console.ReadLine(); // stores user input
                if (c == "x" || c == "X") // checks for escape character
                {
                    rec.base1 = 0;
                    break;
                }
                try // checks for valid input
                {
                    rec.base1 = double.Parse(c);
                    if (rec.base1 <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.Write("Invalid Input, Please enter a valid Base: "); //prompts user to enter valid input

                }
            }

            if (rec.base1 != 0)
            {
                Console.Write("Please enter the Height of the Rectangle: ");
                while (rec.height <= 0)
                {
                    c = Console.ReadLine();
                    if (c == "x" || c == "X")
                    {
                        rec.height = 0;
                        break;
                    }
                    try
                    {
                        rec.height = double.Parse(c);
                        if (rec.height <= 0)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.Write("Invalid Input, Please enter a valid Height: ");

                    }
                }
                if (rec.base1 != 0 && rec.height != 0)
                {
                    rec.area = rec.CalculateArea();  // Calculates area and perimeter of rectangle
                    rec.perimeter = rec.CalculatePerim();
                }
            }
        }

        static void TrianglePrompt(ref Triangle tri) // Prompts user for Triangle Base an height
        {
            string c; // escape character check


            Console.WriteLine();
            Console.WriteLine("Press x to return to the Menu");
            Console.WriteLine(); //prompts user for input
            Console.Write("Please enter the Base of the Triangle: ");

            while (tri.base1 <= 0)
            {
                c = Console.ReadLine(); // stores user input
                if (c == "x" || c == "X") // checks for escape character
                {
                    tri.base1 = 0;
                    break;
                }
                try // checks for valid input
                {
                    tri.base1 = double.Parse(c);
                    if (tri.base1 <= 0)
                    {
                        throw new Exception();
                    }
                }
                catch
                {
                    Console.Write("Invalid Input, Please enter a valid Base: "); //prompts user to enter valid input

                }
            }

            if (tri.base1 != 0)
            {
                Console.Write("Please enter the Height of the Triangle: ");
                while (tri.height <= 0)
                {
                    c = Console.ReadLine();
                    if (c == "x" || c == "X")
                    {
                        tri.height = 0;
                        break;
                    }
                    try
                    {
                        tri.height = double.Parse(c);
                        if (tri.height <= 0)
                        {
                            throw new Exception();
                        }
                    }
                    catch
                    {
                        Console.Write("Invalid Input, Please enter a valid Height: ");

                    }
                }
                if (tri.height != 0 && tri.base1 != 0)
                {
                    tri.area = tri.CalculateArea(); // Computes area of the triangle
                }

            }
        }
    }
}
