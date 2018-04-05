using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dal.interfaces;
using dal.models;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        IRepository _repository;

        public ValuesController(IRepository repository) => _repository = repository;
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _repository.GetAllAsync<Patient>(i => i.OrderBy(o => o.Created), "Address", 10, 10);
            _repository.GetFirst<Patient>(i => i.Address1 == "1" && i.FullName == "Pizza the hut", 
                        i => i.OrderByDescending(o => o.FullName), "Address,Claims");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
