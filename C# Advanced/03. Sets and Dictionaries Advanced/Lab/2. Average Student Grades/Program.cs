int n = int.Parse(Console.ReadLine());


Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

for (int i = 0; i < n; i++)
{
    var tokens = Console.ReadLine().Split();

    var name = tokens[0];
    var grade = decimal.Parse(tokens[1]);

    if (!grades.ContainsKey(name))
    {
        grades[name] = new List<decimal>();
    }
    grades[name].Add(grade);

}

foreach (var (name, studentsGrades) in grades)
{
    var average = studentsGrades.Average();
    Console.Write($"{name} -> ");
    foreach (var grade in studentsGrades)
    {
        Console.Write($"{grade:f2} ");
    }
    Console.WriteLine($"(avg: {average:f2})");
}