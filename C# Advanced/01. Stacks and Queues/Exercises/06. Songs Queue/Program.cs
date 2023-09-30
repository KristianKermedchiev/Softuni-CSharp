string[] inputSongs = Console.ReadLine().Split(", ");

Queue<string> songs = new Queue<string>(inputSongs);

while (true)
{
    string[] commandInfo = Console.ReadLine().Split();

    if (commandInfo[0] == "Play")
    {
        if (songs.Any())
        {
            songs.Dequeue();
        }

        if (songs.Count == 0)
        {
            Console.WriteLine("No more songs!");
            break;
        }
    }
    else if (commandInfo[0] == "Add")
    {
        string songName = string.Join(" ", commandInfo.Skip(1));

        if (songs.Contains(songName))
        {
            Console.WriteLine($"{songName} is already contained!");
        }
        else
        {
            songs.Enqueue(songName);
        }
    }
    else if (commandInfo[0] == "Show")
    {
        Console.WriteLine(string.Join(", ", songs));
    }
}