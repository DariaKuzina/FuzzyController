using System;

namespace FuzzyController
{

    public delegate double FuncAsses(int x);

    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            Console.WriteLine("Введите значение альфа");
            int x, y;
            x = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение бета");
            y = int.Parse(Console.ReadLine());
            Console.WriteLine("Результат: {0}", controller.Start(x, y));
        }
    }
}
