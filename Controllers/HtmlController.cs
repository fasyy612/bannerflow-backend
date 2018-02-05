using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace BannerflowApi.Controllers
{
    [Route("api/[controller]")]
    public class HtmlController : Controller
    {
        // Produce the html within banner
        public ActionResult Index()
        {
            //return RedirectToAction("ActionName", "ControllerName", new { userId = id });
            //var html = new BannerController().GetById(1);
            //ViewBag.HtmlStr = html;
            return View();
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
