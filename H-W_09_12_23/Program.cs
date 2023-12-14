using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace H_W_09_12_23
{
    internal class Refl
    {
        static void PrintNumbers()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
        static long Factorial(int x)
        {
            Thread.Sleep(8000);
            long result = 1;
            for (int i = 1; i <= x; i++)
                result *= i;
            return result;
        }
        static long Square(int x)
        {
            return x * x;
        }
        static async Task Main(string[] args)
        {
            // EX 1 - 3 streams
            Console.WriteLine("EX 1 - 3 streams");
            Thread thread1 = new Thread(PrintNumbers);
            Thread thread2 = new Thread(PrintNumbers);
            Thread thread3 = new Thread(PrintNumbers);
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread1.Join();
            thread2.Join();
            thread3.Join();
            // EX 2 Factorial and Square
            Console.WriteLine("EX 2 Factorial and Square");
            Console.Write("Enter a number: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Task<long> factTask = new Task<long>(() => Factorial(n));
            factTask.Start();
            long square = Square(n);
            Console.WriteLine($"Square: {square}");
            long factorial = await factTask;
            Console.WriteLine($"Factorial: {factorial}");
            //EX 3 Names of methods
            Console.WriteLine("EX 3 Names of methods");
            Type t = typeof(Refl);
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo m in methods)
            {
                Console.WriteLine(m.Name);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        public string Output()
        {
            return "Test-Output";
        }
        public int AddInts(int i1, int i2)
        {
            return i1 + i2;
        }
    }
}
   
