//Object
class Program
{
    static void Main(){
        //Boxing
        int x = 3;
        object obj = x;
        // Unboxing
        int result = (int)obj;
        Console.WriteLine(result);

        //No need for cast, just unbox
        object objt1 = 3;
        double myDouble = (int)objt1;

        //Need for cast + unbox
        object obj2 = 3.0;
        int myInt = (int)(double)obj2;
    }
}