HashSet<string> party = new HashSet<string>();
HashSet<string> VIParty = new HashSet<string>();

while (true)
{
    string commands = Console.ReadLine();
    if (commands == "PARTY")
    {
        break;
    }

    if (char.IsDigit(commands[0]))
    {
        VIParty.Add(commands);
    }
    else
    {
        party.Add(commands);
    }
}

while (true)
{
    string input = Console.ReadLine();
    if (input == "END")
    {
        break;
    }

    if (char.IsDigit(input[0]) && VIParty.Contains(input))
    {
        VIParty.Remove(input);
    }
    else if (party.Contains(input))
    {
        party.Remove(input);
    }

    
}

int totalGuestsNotAttended = VIParty.Count + party.Count;
Console.WriteLine(totalGuestsNotAttended);


foreach (string person in VIParty)
{
    Console.WriteLine(person);
}

foreach (string person in party)
{
     Console.WriteLine(person);
}