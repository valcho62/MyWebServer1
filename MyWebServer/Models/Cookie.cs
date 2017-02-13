namespace MyWebServer.Models
{
    public class Cookie
    {
        public string Name { get; private set; }
        public string Value { get; private set; }
        public Cookie():this(null,null)
        {
            
        }

        public Cookie( string name, string value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{this.Name} = {this.Value}";
        }
    }
}