// Overloading
class Calculator
{
    public int Add(int a, int b);
    {
        return a + b;
    }
    public float Add(float a, float b);
    {
        return a + b;
    }
    public int StringLenghtChecker(string a,  string b);
    {
        retrung (a + b).Length;
    }
    // THis method is conflict beacuse same name same parameter,
    // ever tht return type is different
    // public double Add(string a, string b)
    // {
    // retrun a.Length + b.Length ;
    //}
}