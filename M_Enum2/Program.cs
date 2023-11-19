//Enum

static void Main()
{
    //string month = MonthOfYear.January.ToString();
    int count = (int)MonthOfYear.January;
    //Console.WriteLine(month);
    Console.WriteLine(count);

    //int x = 4;
    //MonthOfYear result = (MonthOfYear) x;
    //Console.WriteLine(result);
}

public enum MonthOfYear
{
    January,
    February =401,
    March,
    April =1,
    May,
    June =400,
    July=2,
    August,
    September=2,
    October,
    November,
    December
}

public static class IniExtension{
    public static void Dump(this object x)
    {
        Console.WriteLine(x.ToString());
    }
}