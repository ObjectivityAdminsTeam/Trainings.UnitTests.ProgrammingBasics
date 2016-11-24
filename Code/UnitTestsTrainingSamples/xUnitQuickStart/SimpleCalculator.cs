namespace xUnitQuickStart
{
    public class SimpleCalculator
    {
        public int Addition(int a, int b)
        {
            return checked(a + b);
        }

        public int Subtraction(int a, int b)
        {
            return checked(a - b);
        }

        public int Multiplication(int a, int b)
        {
            return checked(a * b);
        }

        public int Division(int a, int b)
        {
            return a / b;
        }

        public bool IsOdd(int number)
        {
            return number % 2 == 1;
        }
    }
}