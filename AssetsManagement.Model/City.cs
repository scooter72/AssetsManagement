namespace AssetsManagement.Model
{
    public class City : Entity
    {
        public int Symbol { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"City: [Symbol: {Symbol}, Name: {Name}]";
        }
    }
}
