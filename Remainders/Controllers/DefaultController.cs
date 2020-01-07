using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Remainders.Data;
using Remainders.Models;

namespace Remainders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private DataContext _ctx;
        public DefaultController (DataContext ctx)
        {
            _ctx = ctx; 
        }

        // GET: api/Default
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var remainders = _ctx.Remainders.Select(r => r.Text).ToArray();

            Remainder remainder = new Remainder();
            remainder.Text = "Купть слона";
            remainder.TimeToWork = ToDateSQLite(DateTime.Now);
            remainder.Priority = Priority.A;

            _ctx.Remainders.Add(remainder);
            _ctx.SaveChanges();


            return remainders;
        }

        // GET: api/Default/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return _ctx.Remainders.Find(id).Text;
        }

        // POST: api/Default
        [HttpPost]
        public void Post([FromBody] string text)
        {
            Remainder remainder = new Remainder();
            remainder.Text = text;
            remainder.TimeToWork = ToDateSQLite(DateTime.Now);
            remainder.Priority = Priority.A;

            _ctx.Remainders.Add(remainder);
            _ctx.SaveChanges();
        }

        // PUT: api/Default/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string text)
        {
            Remainder remainder = _ctx.Remainders.Find(id);
            remainder.Text = text;

            _ctx.SaveChanges();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Remainder remainder = _ctx.Remainders.Find(id);
            _ctx.Remainders.Remove(remainder);

            _ctx.SaveChanges();
        }

        public static string ToDateSQLite(DateTime value)
        {
            string format_date = "yyyy-MM-dd HH:mm:ss.fff";
            return value.ToString(format_date);
        }
    }
}
