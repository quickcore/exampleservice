using Example.Core;
using QuickCore.Client;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Example.Api.Client
{
    public class CalcClient : ClientBase<ICalc>, ICalc
    {
        public CalcClient(IHttpClientFactory factory) : base(factory)
        {

        }
        public double Add(double a, double b)
        {
            var task = this.GetJsonObject<double>($"/calc/add/{a}/{b}");
            return task.Result;
        }
        [Get("/div/{a}/{b}")]
        public double Div(double a, double b)
        {
            return this.Div(a, b);
        }
        [Get("/mutil/{a}/{b}")]
        public double Mutil(double a, double b)
        {
            return this.Mutil(a, b);
        }
        [Get("/sub/{a}/{b}")]
        public double Sub(double a, double b)
        {
            return this.Sub(a, b);
        }
    }
}
