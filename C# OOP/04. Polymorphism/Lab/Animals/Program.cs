

namespace Animals
{
    public class StartUp
    {
        static void Main()
        {
            Animal animal = new Dog("Sharo", "whiskas");
            Explain(animal);
            animal = new Cat("Garfield", "lasagna");
            Explain(animal);
        }

        static void Explain(Animal animal)
        {
            Console.WriteLine(animal.ExplainSelf());
        }
    }
}