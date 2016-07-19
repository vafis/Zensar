using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;
using Xunit.Extensions;
using Zensar.API;
using Zensar.API.Config;
using Zensar.API.DTO;
using Zensar.Domain.Entities;

namespace Zelsar.Web.Tests
{
    public class UnitTestAPI
    {
        [Theory]
        [InlineData("http://localhost:36324/api/site/GetPersons")]
        public async void Site_controller_Integration_Test(string url)
        {
            var config = new HttpConfiguration();
            ApiRouteConfig.RegisterRoutes(config);
            AutofacWebApi.Setup(config);
            var httpServer = new HttpServer(config);

            var client = HttpClientFactory.Create(innerHandler: httpServer);
           
  

        }

        [Theory]
        [InlineData("http://localhost:36324/api/site/InsertPerson")]
        public async void Site_controller_Send_new_Person(string url)
        {
            var config = new HttpConfiguration();
            ApiRouteConfig.RegisterRoutes(config);
            AutofacWebApi.Setup(config);
            var httpServer = new HttpServer(config);

            var client = HttpClientFactory.Create(innerHandler: httpServer);

            var person = new PersonDTO()
            {
                Name = "Kostas",
                Phone = "weedfwe",
                Surname = "Vafeiadakis",
                Active = true
            };
            
            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(url),
                Content =  new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("person", JsonConvert.SerializeObject(person)),
                   
                })
            };

            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("PersonDTO",JsonConvert.SerializeObject(person) )
            });

            //var response = client.GetAsync(new Uri(url)).Result;
            HttpResponseMessage response = await client.PostAsync(new Uri(url), requestMessage.Content);


            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var json = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            // WebSiteOwnerViewModel viewModel = json.ToObject<WebSiteOwnerViewModel>();
            // Assert.Equal(siteid, viewModel.WebSite.Id);
            // Assert.Equal(city, viewModel.WebSiteOwner.City);

        }
    }
}
