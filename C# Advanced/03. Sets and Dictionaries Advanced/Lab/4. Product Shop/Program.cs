
string command = Console.ReadLine();


Dictionary<string, Dictionary<string, double>> stores = new Dictionary<string, Dictionary<string, double>>();

while  (command != "Revision")
{

    string[] partsCommand = command.Split(", ");
    string shop = partsCommand[0];
    string product = partsCommand[1];
    double price = double.Parse(partsCommand[2]);

    if (!stores.ContainsKey(shop)){
        stores.Add(shop, new Dictionary<string, double>());
    }
        stores[shop].Add(product, price);

    command = Console.ReadLine();
}


foreach (var (store,products) in stores.OrderBy(s => s.Key))
{
    Console.WriteLine($"{store}->");

    foreach(var (product,price) in products)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}