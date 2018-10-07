using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Open.Aids;
using Open.Sentry1.Controllers;

namespace Open.Tests.Sentry.Controllers
{
    //[TestClass]
    public class CurrenciesControllerTests : AcceptanceTests
    {
        [TestMethod]
        public async Task IndexTestWhenLoggedOut()
        {
            Assert.Inconclusive();
            var response = await client.GetAsync("/currencies");
            Assert.AreEqual(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [TestMethod]
        public async Task IndexTestWhenLoggedIn()
        {
            Assert.Inconclusive();
            TestAuthenticationHandler.IsLoggedIn = true;
            var response = await client.GetAsync("/currencies");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            Assert.IsTrue(stringResponse.Contains("Currencies"));
        }

        /*[TestMethod]
        public void RepositoryTest()
        {
            const string c = ", ";
            var b = new StringBuilder();
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.Country));
            b.Append(c);
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.Alpha3Code));
            b.Append(c);
            b.Append(GetMember.Name<CurrencyViewModel>(m => m.Currency));
            Assert.AreEqual(b.ToString(), CurrenciesController.properties);
        }*/
    }
}