namespace smswa.accelerator.sample.model
{
    public enum ContactTypes
    {
        Unknown = 0,
        WorkEmail = 1,
        PersonalEmail = 2,
        WorkPhone = 3,
        PersonalPhone = 4
    }

    public class ContactType
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public bool Inactive { get; set; }
    }
}