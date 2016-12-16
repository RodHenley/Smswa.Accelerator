namespace smswa.accelerator.service.contract.Commands.Person
{
    public class AddContactResponse : IResponse
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public int Id { get; set; }
    }
}