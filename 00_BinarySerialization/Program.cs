using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Person
{
	public string Name { get; set; }
	public int Age { get; set; }
}

class Program
{
	static void Main(string[] args)
	{
		Person person = new Person { Name = "Alice", Age = 10 };

		BinaryFormatter formatter = new BinaryFormatter();
		using (FileStream stream = new FileStream("person.bin", FileMode.Create))
		{
			formatter.Serialize(stream, person);
		}

		Person deserializedPerson;
		using (FileStream stream = new FileStream("person.bin", FileMode.Open))
		{
			deserializedPerson = (Person)formatter.Deserialize(stream);  //unboxing
		}

		Console.WriteLine($"Deserialized Person: {deserializedPerson.Name}, {deserializedPerson.Age}");
	}
}
