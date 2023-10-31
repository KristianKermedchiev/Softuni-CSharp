namespace CustomRandomList
{
    public class StartUp
    {
       public static void Main()
        {
            RandomList list  = new RandomList();

            list.Add("1");
            list.Add("2");
            list.Add("3");

            Console.WriteLine(list.RandomString());
        }
    }
}