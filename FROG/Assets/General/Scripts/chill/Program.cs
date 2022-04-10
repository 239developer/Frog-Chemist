using System;
using System.IO;

namespace chill
{
    class Program
    {
        static void Main()
        {
            StreamWriter sw = new StreamWriter(@"text.txt");
            Console.WriteLine(Path.GetFullPath(@"text.txt"));

            sw.WriteLine("{");
            string i = Console.ReadLine();
            while(i != "end")
            {
                sw.WriteLine($"{i}, ");
                i = Console.ReadLine();
            }
            sw.WriteLine("}");

            sw.Close();
            Console.WriteLine("End.");
        }
    }
}
