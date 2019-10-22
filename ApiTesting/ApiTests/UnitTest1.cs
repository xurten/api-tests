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
    }
}