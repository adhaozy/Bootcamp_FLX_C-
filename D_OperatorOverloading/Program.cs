class Program 
{
    static void Main()
    {
        Car cara = new(2);
        Car carb = new(3);
        Car carc = new(4);
        Car card = new(5);
        Car result = cara + carb + carc + card;
    }
    class Car 
    {
        public int price;
        public Car(int p)
        {
            price = p;
        }
        public static Car operator+(Car left, Car right)
        {
            return new Car(left.price + right.price);
        }
    }
}