using Example.Core;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickCore.ApiHost;
using QuickCore.UnitTest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Api.Client.UnitTest
{
    [TestClass]
    public class CalcClientTest:ApiClientTestBase<CalcClient,ICalc>
    {
        [TestMethod]
        public void Add_1_2_Should_3()
        {
            var res = this.Instance.Add(1, 2);
            var hash = this.Instance.GetHashCode();
            var hash2 = this.Instance.GetHashCode();
            
        }

        protected override IWebHostBuilder OnCreateWebHostBuilder()
        {
         
            return new WebHostBuilder().UseStartup<Startup>();
        }
    }
}
