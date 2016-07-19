using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Zensar.API.DTO;
using Zensar.Domain.Entities;
using  Zensar.Service;

namespace Zensar.API.Controllers
{
    public class SiteController : ApiController
    {
        private IPricingSevice _pricingSevice;

        public SiteController(IPricingSevice pricingSevice)
        {
            _pricingSevice = pricingSevice;
        }


        [HttpPost]
        public HttpResponseMessage InsertPerson(Person person)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = this.Request.CreateResponse(HttpStatusCode.BadRequest,
                    ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                        .Select(m => m.Exception.ToString()).ToArray());
            }
            else
            {
                var p =  _pricingSevice.InsertPerson(person);
                response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new ObjectContent<dynamic>(p, this.Configuration.Formatters.JsonFormatter, new MediaTypeWithQualityHeaderValue("application/json"))

                };
            }

            return response;

        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetPersons()
        {
            List<Person> ret = await _pricingSevice.GetPersonsAsync();
            List<PersonDTO> personDtos=new List<PersonDTO>();
            ret.ForEach(x =>
            {
                PersonDTO p = new PersonDTO()
                {
                    FirstName = x.FirstName,
                    Surname = x.Surname,
                    Active = x.Active,
                    Id = x.Id,
                    Phone = x.Phone
                };
                personDtos.Add(p);
            });

            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ObjectContent<dynamic>(personDtos, this.Configuration.Formatters.JsonFormatter, new MediaTypeWithQualityHeaderValue("application/json"))
               
            };

        }
        



        [HttpPost]
        public HttpResponseMessage UpdatePerson1(Person person)
        {
            HttpResponseMessage response = null;

            if (!ModelState.IsValid)
            {
                response = this.Request.CreateResponse(HttpStatusCode.BadRequest,
                    ModelState.Keys.SelectMany(k => ModelState[k].Errors)
                        .Select(m => m.Exception.ToString()).ToArray());
            }
            else
            {
                _pricingSevice.UpdatePerson(person);
                response = new HttpResponseMessage(HttpStatusCode.Created)
                {
                    Content = new ObjectContent<dynamic>(person, this.Configuration.Formatters.JsonFormatter, new MediaTypeWithQualityHeaderValue("application/json"))

                };
            }

            return response;

        }
    }
}
