namespace Prac17
{
    internal class Program
    {
        class Rectangle
        {
            private int a;
            private int b;

            // Конструкторы
            public Rectangle() { }
            public Rectangle(int a, int b)
            {
                //if (a <= 0 || b <= 0) throw new ArgumentException();
                A = a;
                B = b;
            }
            public Rectangle(Rectangle rectangle)
            {
                A = rectangle.A;
                B = rectangle.B;
            }

            // Свойства
            public int A
            {
                get { return a; }
                set
                {
                    if (value <= 0) throw new ArgumentException();
                    a = value;
                }
            }
            public int B
            {
                get { return b; }
                set
                {
                    if (value <= 0) throw new ArgumentException();
                    b = value;
                }
            }
            public bool IsSquare
            {
                get { return a.Equals(b); }
            }

            // Индексатор
            public int this[int i]
            {
                get
                {
                    if (i == 0) return a;
                    else
                    {
                        if (i == 1) return b;
                        else
                        {
                            Console.WriteLine("Недопустимый индекс");
                            return 0;
                        }
                    }
                }
                set
                {
                    if (i == 0)
                    {
                        if (value <= 0) throw new ArgumentException();
                        a = value;
                    }
                    else
                    {
                        if (i == 1)
                        {
                            if (value <= 0) throw new ArgumentException();
                            b = value;
                        }
                        else Console.WriteLine("Недопустимый индекс");
                    }
                }
            }

            // Методы
            public int Perimeter()
            {
                return 2 * (a + b);
            }
            public int Area()
            {
                return a * b;
            }
            public void Scale(int coef)
            {
                if (coef <= 0) throw new ArgumentException();
                A = a * coef;
                B = b * coef;
            }

            // Перегрузки методов Object
            public override string ToString()
            {
                return "(" + a + ", " + b + ")";
            }
            public override int GetHashCode()
            {
                return a.GetHashCode() + b.GetHashCode();
            }
            public bool Equals(Rectangle obj)
            {
                if (this == obj) return true;
                if (obj == null || GetType() != obj.GetType()) return false;
                return a.Equals(obj.A) && b.Equals(obj.B);
            }
            /*public static new string GetType()
            {
                return "Rectangle";
            }*/

            // Перегрузки операций
            public static Rectangle operator ++(Rectangle m)
            {
                Rectangle temp = new Rectangle(m);
                temp.A += 1;
                temp.B += 1;
                return temp;
            }
            public static Rectangle operator --(Rectangle m)
            {
                Rectangle temp = new Rectangle(m);
                temp.A += 1;
                temp.B += 1;
                return temp;
            }
            public static bool operator true(Rectangle m)
            {
                //return m.IsSquare;
                if (!m.IsSquare) return false;
                return true;
            }
            public static bool operator false(Rectangle m)
            {
                if (m.IsSquare) return true;
                return false;
            }
            public static Rectangle operator *(Rectangle m, int a)
            {
                Rectangle temp = new Rectangle(m);
                temp.A *= a;
                temp.B *= a;
                return temp;
            }
            public static Rectangle operator *(int a, Rectangle m)
            {
                return m * a;
            }
        }
        static void Main(string[] args)
        {
            // Конструкторы
            Console.WriteLine("// Конструкторы");
            Rectangle rect1 = new Rectangle();
            Rectangle rect2 = new Rectangle(1, 2);
            Rectangle rect3 = new Rectangle(rect2);
            Console.WriteLine("Rectangle 1: " + rect1);
            Console.WriteLine("Rectangle 2: " + rect2);
            Console.WriteLine("Rectangle 3: " + rect3);
            Console.WriteLine("");

            // Поля
            Console.WriteLine("// Поля");
            Console.WriteLine("Rectangle 2 A: " + rect2.A);
            Console.WriteLine("");

            // Методы
            Console.WriteLine("// Методы");
            Console.WriteLine("Rectangle 2 Perimeter: " + rect2.Perimeter());
            Console.WriteLine("Rectangle 2 Area: " + rect2.Area());
            rect2.Scale(2);
            Console.WriteLine("Rectangle 2 A: " + rect2);
            Console.WriteLine("");

            // Перегрузки методов Object
            Console.WriteLine("// Перегрузки методов Object");
            Console.WriteLine("Rectangle 2 ToString: " + rect2);
            Console.WriteLine("Rectangle 2 GetHashCode: " + rect2.GetHashCode());
            Console.WriteLine("Rectangle 2 Equals Rectangle 3: " + rect2.Equals(rect3));
            Console.WriteLine("");

            // Свойства
            Console.WriteLine("// Свойства");
            Console.WriteLine("Rectangle 2 A: " + rect2.A);
            rect2.A = 5;
            Console.WriteLine("Rectangle 2: " + rect2);
            Console.WriteLine("Rectangle 2 IsSquare: " + rect2.IsSquare);
            Console.WriteLine("");

            // Индексатор
            Console.WriteLine("// Индексатор");
            Console.WriteLine("Rectangle 2 [0]: " + rect2[0]);
            rect2[0] = 6;
            Console.WriteLine("Rectangle 2: " + rect2);
            Console.WriteLine("");

            // Перегрузки операций
            Console.WriteLine("// Перегрузки операций");
            Console.WriteLine("Rectangle 2: " + rect2);
            rect2++;
            Console.WriteLine("Rectangle 2 ++: " + rect2);
            if (rect2) Console.WriteLine("Rectangle 2 is true");
            else Console.WriteLine("Rectangle 2 is false");
            rect2 *= 2;
            Console.WriteLine("Rectangle 2 *: " + rect2);
            Console.WriteLine("");
        }
    }
}
