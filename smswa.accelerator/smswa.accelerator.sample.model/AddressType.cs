namespace smswa.accelerator.sample.model
{
    public enum AddressTypes
    {
        Unknown = 0,
        Home = 1,
        Postal = 2,
        Work = 3,
    }

    public class AddressType
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public bool Inactive { get; set; }
    }
}