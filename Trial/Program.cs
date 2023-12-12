using System;
using System.IO;
using System.Text;

class Program {

	static void Main(string[] args)
	{

		string filePath = "data.txt";
		string text = "Ini adalah contoh menulis string ke file.\nBaris kedua.";

		using(FileStream fs = new(filePath, FileMode.Open, FileAccess.Write, FileShare.Read)) 
		{
			using (StreamWriter sw = new(fs)) 
			{
				sw.BaseStream.Position = fs.Seek(3, SeekOrigin.Begin);
				sw.BaseStream.Position = fs.Seek(3, SeekOrigin.Current);
			}
		}

	}

}