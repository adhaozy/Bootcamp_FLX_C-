using CatProgramParameter;

class Program 
{
	static void Main() 
	{
		Cat cat = new Cat("iqbal", 8, 70);
		cat.Sleep();
	// iqbal

		string food = "whiskas";
		cat.Eat(food);
	}
}