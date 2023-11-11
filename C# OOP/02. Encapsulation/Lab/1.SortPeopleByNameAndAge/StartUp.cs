namespace PersonsInfo;

public class StartUp
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        Team team = new Team("SoftUni");

        for (int i = 0; i < n; i++)
        {
            string[] inputInfo = Console.ReadLine().Split();

            int age = int.Parse(inputInfo[2]);
            decimal salary = decimal.Parse(inputInfo[3]);

            Person person = new Person(inputInfo[0], inputInfo[1], age, salary);

            team.AddPlayer(person);
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}