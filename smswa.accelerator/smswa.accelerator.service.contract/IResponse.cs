namespace smswa.accelerator.service.contract
{
    public interface IResponse
    {
        bool Success { get; set; }
        string[] Errors { get; set; }
    }
}