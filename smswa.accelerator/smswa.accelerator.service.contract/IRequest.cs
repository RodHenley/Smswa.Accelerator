namespace smswa.accelerator.service.contract
{
    public interface IRequest
    {
    }

    public interface IParamertisedRequest : IRequest
    {
        string ToRequestString();
    }
}