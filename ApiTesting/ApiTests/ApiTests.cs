using ApiCore;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiTests
{
    public class Tests
    {
        [Test]
        public async Task CheckClientStatusCode()
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task CheckClientResponse()
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";
            var httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(url);
            var responseContent = response.Content.ReadAsStringAsync();
            var userObject = JsonConvert.DeserializeObject<User>(responseContent.Result);
            
            Assert.AreEqual(1, userObject.UserId);
            Assert.AreEqual(1, userObject.Id);
            Assert.AreEqual("delectus aut autem", userObject.Title);
            Assert.AreEqual(false, userObject.Completed);
        }
    }
}