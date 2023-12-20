using System;

namespace LoggingIntroduction
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Starting the program...");

			int a = 10;
			int b = 20;
			
			Console.WriteLine($"a: {a}, b: {b}");

			int sum = a + b;

			Console.WriteLine($"The sum of a and b is: {sum}");

			Console.WriteLine("Program completed.");
		}
	}
}