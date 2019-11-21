using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickCore.ApiHost;

namespace Example.Api.Client.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            CalcClient cc = new CalcClient(null);
            var r = cc.Add(1, 3);
        }
        [TestMethod]
        public void TestServer()
        {
            //var builder = Program.CreateHostBuilder(new string[0]);
            var builder = new WebHostBuilder().UseStartup<Startup>();
            var testServer = new TestServer(builder);


            var _client = testServer.CreateClient();
            var res = _client.GetAsync("/calc/add/1/2").Result;
            var text = res.Content.ReadAsStringAsync().Result;

        }
    }
}
