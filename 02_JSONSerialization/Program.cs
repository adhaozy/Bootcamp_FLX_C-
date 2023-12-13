using System.Text.Json;

public class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
	public List<string> myList { get; set; }

}

class Program
{
	static void Main(string[] args)
	{
		//Serialize
		Person person = new Person { Name = "Charlie", Age = 122 , myList = new List<string>() 
		{
			"hello",
			"test"
		}};
		
		string jsonString = JsonSerializer.Serialize(person);
		using (StreamWriter writer = new StreamWriter("person.json"))
		{
			writer.Write(jsonString);
		}


		//Deserialize
		string jsonFromFile;
		using (StreamReader reader = new StreamReader("person.json"))
		{
			jsonFromFile = reader.ReadToEnd();
		}
		Person? deserializedPerson = JsonSerializer.Deserialize<Person>(jsonFromFile);

		Console.WriteLine($"Deserialized Person: {deserializedPerson.Name}, {deserializedPerson.Age}, {deserializedPerson.myList}");
	}
}