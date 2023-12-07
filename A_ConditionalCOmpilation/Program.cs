//For choose between different Testing or Lib

//dotnet build -C GAMERUNNER
//dotnet run

class Program {
	static void Main() {
		#if CODE
		#elif RELEASE 
		Console.WriteLine("GameRunner.");
		//GameRunner gameRunner = new();
		#elif (TEST || DEBUG)
		Console.WriteLine("GameTester.");
		//GameTester gameTest = new();
		//methodTest(0);
		#else
		Console.WriteLine("Not anything.");
		#endif
		Console.WriteLine("Finish");
	}
}
