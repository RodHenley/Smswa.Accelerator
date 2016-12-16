using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Web;
using smswa.accelerator.data;
using smswa.accelerator.sample.model;
using smswa.accelerator.service.contract;
using smswa.accelerator.service.contract.Commands.Person;

namespace smswa.accelerator.service.Handlers.Person
{
    public class AddAddressHandler:IHandler, IHandler<AddAddressRequest, AddAddressResponse>
    {
        private readonly AcceleratorContext _context;

        public AddAddressHandler(AcceleratorContext context)
        {
            _context = context;
        }

        public async Task<IResponse> Handle(IRequest request)
        {
            return await Handle(request as AddAddressRequest);
        }

        public async Task<AddAddressResponse> Handle(AddAddressRequest request)
        {
            var address = DtoToModel(request);

            try
            {
                //deactivate old addresses
                var address1 = address;
                var oldAddresses = await _context.Addresses
                    .Where(x => x.PersonId == address1.PersonId)
                    .Where(x => x.AddressTypeId == address1.AddressTypeId)
                    .Where(x => x.Inactive == false)
                    .ToListAsync()
                    ;

                foreach (var oldAddress in oldAddresses)
                {
                    oldAddress.Inactive = true;
                }

                //add new address
                address = _context.Addresses.Add(address);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new AddAddressResponse
                {
                    Success = false,
                    Errors = new[] { e.Message }
                };
            }

            return new AddAddressResponse
            {
                Id = address.Id,
                Success = true,
                Errors = new string[] { }
            };
        }

        private Address DtoToModel(AddAddressRequest request)
        {
            return new Address
            {
                PersonId = request.PersonId,
                AddressTypeId = request.AddressTypeId,
                Inactive = false,
                Line1 = request.Line1,
                Line2 = request.Line2,
                Country = request.Country,
                Postcode = request.Postcode,
                Suburb = request.Suburb,
                State = request.State
            };
        }
    }
}