class Program{
    static void Main()
    {
        #if ANDROID
        Console.WriteLine("ANDROID");
        #elif APPLE
        Console.WriteLine("Apple");
        #endif
        Console.WriteLine("Program berjalan...");
    }
}