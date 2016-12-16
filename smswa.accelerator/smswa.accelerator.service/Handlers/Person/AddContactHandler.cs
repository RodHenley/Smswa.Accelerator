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
    public class AddContactHandler:IHandler, IHandler<AddContactRequest, AddContactResponse>
    {
        private readonly AcceleratorContext _context;

        public AddContactHandler(AcceleratorContext context)
        {
            _context = context;
        }

        public async Task<IResponse> Handle(IRequest request)
        {
            return await Handle(request as AddContactRequest);
        }

        public async Task<AddContactResponse> Handle(AddContactRequest request)
        {
            var contact = DtoToModel(request);

            try
            {
                //deactivate old contact
                var contact1 = contact;
                var oldContacts = await _context.Contacts
                    .Where(x => x.PersonId == contact1.PersonId)
                    .Where(x => x.ContactTypeId == contact1.ContactTypeId)
                    .Where(x => x.Inactive == false)
                    .ToListAsync()
                    ;

                foreach (var oldContact in oldContacts)
                {
                    oldContact.Inactive = true;
                }

                //add new contact
                contact = _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                return new AddContactResponse
                {
                    Success = false,
                    Errors = new[] { e.Message }
                };
            }

            return new AddContactResponse
            {
                Id = contact.Id,
                Success = true,
                Errors = new string[] { }
            };
        }

        private Contact DtoToModel(AddContactRequest request)
        {
            return new Contact
            {
                PersonId = request.PersonId,
                ContactTypeId = request.ContactTypeId,
                Inactive = false,
                Value = request.Value
            };
        }
    }
}