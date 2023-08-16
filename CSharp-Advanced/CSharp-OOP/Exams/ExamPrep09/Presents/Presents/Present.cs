namespace Presents
{
    public class Present
    {
        public Present(string name, double magic)
        {
            this.Name = name;
            this.Magic = magic;
        }

        public string Name { get; set; }

        public double Magic { get; set; }
    }
}
