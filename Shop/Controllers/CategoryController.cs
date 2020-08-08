using Microsoft.AspNetCore.Mvc;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete()
        {
            return Ok();
        }
    }
}
