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
                if (a <= 0 || b <= 0) throw new ArgumentException();
                this.a = a;
                this.b = b;
            }
            public Rectangle(Rectangle rectangle)
            {
                a = rectangle.A;
                b = rectangle.B;
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
                a = a * coef;
                b = b * coef;
            }

            // Перегрузки методов Object
            public override string ToString()
            {
                return "(" + a + ", " + b + ")";
            }
            //public override string GetHashCode()
            //{

            //}
            public bool Equals(Rectangle obj)
            {
                if (a == obj.A && b == obj.B) return true;
                return false;
            }
            public static new string GetType()
            {
                return "Rectangle";
            }

            // Перегрузки операций
            public static Rectangle operator ++(Rectangle m)
            {
                return
            }
        }
        static void Main(string[] args)
        {
            Rectangle rect = new Rectangle();
            int a = 1;
            int b = 2;

            Console.WriteLine(rect.GetHashCode());
            
        }
    }
}
