using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smswa.accelerator.service.contract
{
    public interface IHandler<in T, U> 
        where T : IRequest 
        where U : IResponse
    {
        Task<U> Handle(T request);
    }

    public interface IHandler
    {
        Task<IResponse> Handle(IRequest request);
    }
}
