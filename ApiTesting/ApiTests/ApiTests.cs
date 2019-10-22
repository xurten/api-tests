using ApiCore;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
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

        [Test]
        public async Task CheckPostResult()
        {
            string url = "https://jsonplaceholder.typicode.com/posts";
            var httpClient = new HttpClient();
            var jsonFile = File.ReadAllText("Resources\\PostExample.txt");
            var content = new StringContent(jsonFile, Encoding.UTF8, "application/json");
            var postResponse = await httpClient.PostAsync(url, content);
            var userObject = JsonConvert.DeserializeObject<Post>(postResponse.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(HttpStatusCode.Created, postResponse.StatusCode);
            Assert.AreEqual(1, userObject.UserId);
            Assert.AreEqual(101, userObject.Id);
            Assert.AreEqual("sunt aut facere repellat provident occaecati excepturi optio reprehenderit", userObject.Title);
            Assert.AreEqual("quia et suscipit suscipit recusandae consequuntur expedita et cum reprehenderit molestiae ut ut quas totam nostrum rerum est autem sunt rem eveniet architecto", userObject.Body);
        }
    }
}