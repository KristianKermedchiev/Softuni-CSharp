int cities = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, List<string>>> places = new Dictionary<string, Dictionary<string, List<string>>>();

for (int i = 0; i < cities; i++)
{
    string[] input = Console.ReadLine().Split();

    string continent = input[0];
    string country = input[1];
    string city = input[2];

    if (!places.ContainsKey(continent))
    {
        places.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!places[continent].ContainsKey(country)) 
    {
        places[continent].Add(country, new List<string>());
    }

    places[continent][country].Add(city);
}


foreach (var (continent,countries) in places)
{
    Console.WriteLine($"{continent}:");

    foreach (var (country, city) in countries)
    {
        Console.WriteLine($"{country} -> {string.Join(", ", city)}");
    }
}