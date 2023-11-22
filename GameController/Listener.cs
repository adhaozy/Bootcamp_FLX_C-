
namespace GameControllerLib;

public class UI 
{
    public void CardUpdate(ICard card, CardStatus status)
    {
        Console.WriteLine($"Card : {card.Id} status changed to {status}");
    }

}
public class Database
{
	public void LogToDb(ICard card, CardStatus status) 
	{
		Console.WriteLine($"{DateTime.Now} - Card : {card.Id} status changed to {status}");
	}
}
public static class SMS 
{
	public static void SendSms(ICard card, CardStatus status ) 
	{
		
	}
}
