namespace SoftUniServer.HTTP
{
    public class Header
    {
        public Header(string headerLine)
        {
            // Cache-Control: max-age=04
            // We specifically say we want 2 parts. If we have ': ' multiple times,
            // this means that only the first time will do the split
            var headerParts = headerLine.Split(new string[] { ": " }, 2, StringSplitOptions.None);
            this.Name = headerParts[0];
            this.Value = headerParts[1];
        }

        public Header(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{this.Name}: {this.Value}";
        }
    }
}