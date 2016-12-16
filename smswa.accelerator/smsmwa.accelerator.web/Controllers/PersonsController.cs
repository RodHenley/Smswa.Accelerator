using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using smsmwa.accelerator.web.Infrastructure;
using smsmwa.accelerator.web.Models;
using smswa.accelerator.service.contract.Commands.Person;
using smswa.accelerator.service.contract.Infrastructure;

namespace smsmwa.accelerator.web.Controllers
{
    public class PersonController : Controller
    {
        private readonly string _httpUrl;
        private readonly Func<string, Service> _serviceFactory;

        public PersonController(string httpUrl, Func<string, Service> serviceFactory )
        {
            _httpUrl = httpUrl;
            _serviceFactory = serviceFactory;
        }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        // GET: Person
        public async Task<ActionResult> IndexMvc()
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(
                HttpMethod.Get,
                new GetPeopleRequest { }
                );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return View(response);
        }

        public async Task<ActionResult> IndexKo()
        {
            //var service = new Service(_httpUrl);
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(
            //    HttpMethod.Get,
            //    new GetPeopleRequest { }
            //    );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return View();
        }

        public async Task<ActionResult> IndexReact()
        {
            //var service = new Service(_httpUrl);
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(
            //    HttpMethod.Get,
            //    new GetPeopleRequest { }
            //    );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return View();
        }

        public async Task<ActionResult> Person(int id)
        {
            var service = new Service(_httpUrl);
            var response = await service.Execute<GetPersonRequest, GetPersonResponse>(
                HttpMethod.Get,
                new GetPersonRequest{ Id = id}
                );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return View(response);
        }

        public async Task<ActionResult> PersonKo()
        {
            //var service = new Service(_httpUrl);
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(
            //    HttpMethod.Get,
            //    new GetPeopleRequest { }
            //    );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return View();
        }

        public async Task<ActionResult> PersonReact()
        {
            //var service = new Service(_httpUrl);
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(
            //    HttpMethod.Get,
            //    new GetPeopleRequest { }
            //    );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return View();
        }

        public async Task<ActionResult> GetList()
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(
                HttpMethod.Get,
                new GetPeopleRequest { }
                );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return new JsonCamelCaseResult
            {
                Data = response,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> GetPerson(int id)
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<GetPersonRequest, GetPersonResponse>(
                HttpMethod.Get,
                new GetPersonRequest {Id = id}
                );
            //var service = new WcfService();
            //var response = await service.Execute<GetPeopleRequest, GetPeopleResponse>(new GetPeopleRequest());
            return new JsonCamelCaseResult
            {
                Data = response,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> Get(int id)
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<GetPersonRequest, GetPersonResponse>(
                HttpMethod.Get,
                new GetPersonRequest
                {
                    Id = id
                }
                );
            //var service = new WcfService();
            //var response = await service.Execute<GetPersonRequest, GetPersonResponse>(new GetPersonRequest {Id = id});

            return View("Person", response);
        }


        // This is knockout
        public async Task<ActionResult> AddAddress(int id, AddAddress address)
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<AddAddressRequest, AddAddressResponse>(
                HttpMethod.Post,
                new AddAddressRequest
                {
                    PersonId = id,
                    AddressTypeId = address.AddressTypeId,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Suburb = address.Suburb,
                    Postcode = address.Postcode,
                    State = address.State,
                    Country = address.Country
                }
                );

            return new JsonCamelCaseResult
            {
                Data = response,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public async Task<ActionResult> AddContact(int id, AddContact contact)
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<AddContactRequest, AddContactResponse>(
                HttpMethod.Post,
                new AddContactRequest
                {
                    PersonId = id,
                    ContactTypeId = contact.ContactTypeId,
                    Value = contact.Value
                }
                );

            return new JsonCamelCaseResult
            {
                Data = response,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }


        // This is for MVC
        [HttpPost]
        public async Task<ActionResult> SavePersonAddress(int id, AddAddress address)
        {
            return await SaveAddress(id, address);
        }


        //[HttpPost]
        //public async Task<ActionResult> Person(int id, AddAddress address)
        //{
        //    return await SaveAddress(id, address);
        //}

        private async Task<ActionResult> SaveAddress(int id, AddAddress address)
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<AddAddressRequest, AddAddressResponse>(
                HttpMethod.Post,
                new AddAddressRequest
                {
                    PersonId = id,
                    AddressTypeId = address.AddressTypeId,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Suburb = address.Suburb,
                    Postcode = address.Postcode,
                    State = address.State,
                    Country = address.Country
                }
                );

            return RedirectToAction("Person", new { id = id });
        }


        // This is for MVC
        [HttpPost]
        public async Task<ActionResult> SavePersonContact(int id, AddContact contact)
        {
            var service = _serviceFactory(_httpUrl);
            var response = await service.Execute<AddContactRequest, AddContactResponse>(
                HttpMethod.Post,
                new AddContactRequest
                {
                    PersonId = id,
                    ContactTypeId = contact.ContactTypeId,
                    Value = contact.Value
                }
                );

            return RedirectToAction("Person", new { id = id });
        }


    }
}