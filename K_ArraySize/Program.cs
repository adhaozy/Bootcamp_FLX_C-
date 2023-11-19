// Array Size
void Main()
{
    //C.Readlione always return string
    string userInput = Console.Readlione();
    int size = int.Parse(userInput);

    // array size config
    var myStringArray = new string[size];
    Console.WriteLine(myStringArray.Length);
}