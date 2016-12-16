namespace smswa.accelerator.service.contract.Commands.Person
{
    public class AddPersonResponse:IResponse
    {
        public bool Success { get; set; }
        public string[] Errors { get; set; }
        public int Id { get; set; }
    }
}