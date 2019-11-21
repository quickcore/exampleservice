using Example.Core;
using Microsoft.AspNetCore.Mvc;
using QuickCore.Api;

namespace Example.Api
{
    public class CalcController : ApiBase<ICalc>
    {
        // GET: api/<controller>
        [HttpGet]
        [Route("add/{a}/{b}")]
        public double Add(double a, double b)
        {
            return Instance.Add(a, b);
        }

        [HttpGet]
        [Route("sub/{a}/{b}")]
        public double Sub(double a, double b)
        {
            return Instance.Sub(a, b);
        }
        [HttpGet]
        [Route("mutil/{a}/{b}")]
        public double Mutil(double a, double b)
        {
            return Instance.Mutil(a, b);
        }
        [HttpGet]
        [Route("div/{a}/{b}")]
        public double Div(double a, double b)
        {
            return Instance.Div(a, b);
        }
    }
    }
