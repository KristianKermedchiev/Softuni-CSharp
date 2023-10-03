int countOfNames = int.Parse(Console.ReadLine());

HashSet<string> names = new HashSet<string>();

for (int i = 0; i < countOfNames; i++)
{
    string currentName = Console.ReadLine();

    names.Add(currentName);
}

foreach (string name in names)
{
    Console.WriteLine(name);
}