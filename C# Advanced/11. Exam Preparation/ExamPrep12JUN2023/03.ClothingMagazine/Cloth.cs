namespace ClothesMagazine
{
    public class Cloth
    {
        public Cloth(string color, int size, string type)
        {
            Color = color;
            Size = size; 
            Type = type;
        }
        public string Color { get; set; }
        public int Size { get; set; }
        public string Type { get; set; }

        override public string ToString()
        {
            return $"Product: {Type} with size {Size}, color {Color}";
        }
    }
}
