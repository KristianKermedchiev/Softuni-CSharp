namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        List<Person> people = new List<Person>();

        for (int i = 0; i < n; i++)
        {
            string[] personInfo = Console.ReadLine().Split();

            int age = int.Parse(personInfo[2]);

            Person person = new Person(personInfo[0], personInfo[1], age);

            people.Add(person);
        }

        foreach (var person in people.OrderBy(x => x.FirstName).ThenBy(x => x.Age))
        {
            Console.WriteLine(person.ToString());
        }
    }
}