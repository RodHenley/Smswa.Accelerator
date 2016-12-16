using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using smswa.accelerator.service.contract.Infrastructure;

namespace smswa.accelerator.service.contract
{
    [ServiceKnownType("AllServiceTypes", typeof(KnownTypesHelper))]
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        string HealthCheck();

        [OperationContract]
        Task<IResponse> Execute(IRequest request);
    }
}
