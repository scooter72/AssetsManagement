namespace AssetsManagement.Model
{
    public class Asset
    {
        public Owner Owner { get; set; }
        public Address Address { get; set; }
        public int Id { get; set; }

        public override string ToString()
        {
            return $"Asset: [{Owner}, {Address}]";
        }
    }
}