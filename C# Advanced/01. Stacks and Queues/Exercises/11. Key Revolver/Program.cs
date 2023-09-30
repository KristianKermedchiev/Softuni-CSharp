

int bulletPrice = int.Parse(Console.ReadLine());
int gunBarrelSize = int.Parse(Console.ReadLine());

int[] inputBullets = Console.ReadLine().Split().Select(int.Parse).ToArray();
int[] inputLocks = Console.ReadLine().Split().Select(int.Parse).ToArray();

int intelligence = int.Parse(Console.ReadLine());

Queue<int> locks = new Queue<int>(inputLocks);
Stack<int> bullets = new Stack<int>(inputBullets);

int tempGunBarrel = gunBarrelSize;
int firedBullets = 0;

while (locks.Count > 0 && bullets.Count > 0)
{
    int currentBullet = bullets.Pop();
    int currentLock = locks.Peek();

    firedBullets++;

    if (currentBullet <= currentLock)
    {
        Console.WriteLine("Bang!");
        locks.Dequeue();
    }
    else
    {
        Console.WriteLine("Ping!");
    }

    tempGunBarrel--;

    if (tempGunBarrel == 0 && bullets.Count > 0)
    {
        Console.WriteLine("Reloading!");
        tempGunBarrel = gunBarrelSize;
    }
}

if (bullets.Count == 0 && locks.Count > 0)
{
    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
}
else
{
    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligence - (firedBullets * bulletPrice)}");
}