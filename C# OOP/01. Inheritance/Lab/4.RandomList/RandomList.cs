namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random = new Random();
        public string RandomString()
        {
            return this[random.Next(0, this.Count)];
        }
    }
}