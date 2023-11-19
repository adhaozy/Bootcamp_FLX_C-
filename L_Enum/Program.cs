//Enum
//List of Const
static void Main()
{
    string month = MonthOfYear.January.ToString();
    int count = (int)MonthOfYear.January;
    Console.WriteLine(month);
    Console.WriteLine(count);

    int x = 4;
    MonthOfYear result = (MonthOfYear) x;
    Console.WriteLine(result);
}

public enum MonthOfYear
{
    January,
    February,
    March,
    April,
    May,
    June,
    July,
    August,
    September,
    October,
    November,
    December
}