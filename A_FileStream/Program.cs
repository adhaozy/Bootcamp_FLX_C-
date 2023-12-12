
namespace FileHandlinDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			string FilePath = @".\MyFile.txt";
			using (FileStream fileStream = new FileStream(FilePath, 
			FileMode.Create, FileAccess.Write, FileShare.None))
			{
				Console.Write("File has been opened and the Path is MyFile.txt");
				
			}
			
		}
	}
}