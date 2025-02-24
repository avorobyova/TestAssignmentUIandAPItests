using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using SpecFlow.Internal.Json;
using TestAssignment.APItests.Models;

namespace TestAssignment.APItests
{
    class ReqResAPItests
    {

        [Test]
        public void VerifyFetchingUserList()
        {
            var client = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://reqres.in/")
            });

            var response = client.Get(new RestRequest("/api/users?page=2"));
            var jsonData = JsonConvert.DeserializeObject<ListUsers>(response.Content);

            Assert.AreEqual("OK", response.StatusCode.ToString());
            Console.WriteLine($"Response status code {response.StatusCode}");

            Assert.IsTrue(jsonData.data.Count > 0, "No one user exists.");
            Assert.NotNull(jsonData.data.First().id, "The first user's id is empty.");
            Console.WriteLine($"The first user's id is {jsonData.data.First().id}");
        }

        [Test]
        public void VerifyCreatingNewUser()
        {
            var client = new RestClient(new RestClientOptions
            {
                BaseUrl = new Uri("https://reqres.in/")
            });

            var request = new RestRequest("/api/users");
            request.AddJsonBody(new CreateUser
            {
                name = "John Doe",
                job = "Jedi",
            });
            var response = client.Post<CreateUser>(request);

            Console.WriteLine($"The new user is {response.name}, and job is {response.job}.");
            Console.WriteLine($"The Id is {response.id}.");

            Assert.NotNull(response.id, "The new user's id is empty.");
            Assert.NotNull(response.name, "The new user's name is empty.");
            Assert.NotNull(response.job, "The new user's job is empty.");

        }

    }
}
