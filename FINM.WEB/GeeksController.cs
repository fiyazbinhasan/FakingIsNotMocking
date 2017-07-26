using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FINM.WEB
{
    [Route("api/[controller]")]
    public class GeeksController : Controller
    {
        private  readonly IRepository _repository;

        public GeeksController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.Get());
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] Geek geek)
        {
            try
            {
                _repository.Add(geek);

                if (_repository.SaveChanges() > 0)
                {
                    return Ok(geek);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return BadRequest("Could not add new category.");
        }
    }
}
