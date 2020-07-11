namespace AssetsManagement.Model
{
    public class Owner : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }

        public override string ToString()
        {
            return $"Owner: [Id = {Id}, Name = {Name}, Address: {Address}]";
        }

    }
}
