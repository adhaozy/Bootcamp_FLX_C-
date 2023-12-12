using System;
using System.IO;

class Program
{
	static void Main()
	{
		string path = @"bootcamp.bin";

		using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
		{
			double[] myArray = { 1.1, 2.3, 3.4, 4.5, 5.6 };
			writer.Write(3);
			writer.Write(myArray.Length);
			for (int i = 0; i < myArray.Length; i++)
			{
				writer.Write(myArray[i]);
			}
			writer.Write(true);
		}


		using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
		{
			int x = reader.ReadInt32();
			int length = reader.ReadInt32();
			double[] myArray = new double[length];
			for (int i = 0; i < length; i++)
			{
				myArray[i] = reader.ReadDouble();
			}
			bool boolData = reader.ReadBoolean();

			Console.WriteLine("First int value: {0}", x);
			Console.WriteLine("Double array length: {0}", length);
			Console.WriteLine("Double array values: {0}", string.Join(", ", myArray));
			Console.WriteLine("Bool value: {0}", boolData);
		}
	}
}
