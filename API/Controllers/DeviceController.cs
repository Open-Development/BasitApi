using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace sampleApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController : ControllerBase
    {
        Datacontext _db;

        public DeviceController()
        {
            _db = new Datacontext();
        }

        [HttpGet("{type}")]
        public IActionResult Get(string type)
        {
            if (type == "light")
            {
                return Ok(_db.Lights.ToList());
            }else{
                return NotFound();
            }
        }

        [HttpGet("{type}/{id}")]
        public IActionResult Get(string type, int id)
        {
            if (type == "light")
            {
                var light = _db.Lights.Where(a => a.Id == id).FirstOrDefault();

                if(light==null)
                    return NoContent();

                return Ok(light);
            }else{
                return NotFound();
            }
        }

        [HttpPost("{type}")]
        public IActionResult Post(string type, Light model)
        {
            if (model == null)
                return BadRequest();

            if(type == "light")
            {
                var rec = new Light();

                rec.Status = model.Status;

                _db.Lights.Add(rec);
                _db.SaveChanges();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{type}/{id:int}")]
        public IActionResult Put(int id, string type, Light model)
        {
            if (model == null)
                return BadRequest();

            if(type == "light")
            {
                 var rec = _db.Lights.Where(a => a.Id == id).FirstOrDefault();

                if(rec == null)
                    return NotFound();

                rec.Status = model.Status;

                _db.Lights.Update(rec);
                _db.SaveChanges();

                return Ok(rec);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
