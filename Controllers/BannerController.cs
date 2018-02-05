using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using BannerflowApi.Models;
using System.Linq;
using HtmlAgilityPack;

namespace BannerflowApi.Controllers
{
    [Route("api/[controller]")]
    public class BannerController : Controller
    {
        private readonly BannerContext _context;

        public BannerController(BannerContext context)
        {
            _context = context;

            if (_context.Banners.Count() == 0)
            {
                //_context.Banners.Add(new Banner { Html = "<>" });
                _context.SaveChanges();
            }
        }  

        [HttpGet("content/{id}")]
        public IActionResult Index(long id)
        {
            var banner = _context.Banners.FirstOrDefault(b => b.Id == id);
            if (banner != null) {
                ViewBag.HtmlStr = banner.Html;
            } else {
                ViewBag.HtmlStr = "None yet";
            }
            return View();
        }

        // Get all banners as a list
        [HttpGet]
        public IEnumerable<Banner> GetAll()
        {
            return _context.Banners.ToList();
        }
        
        // Get banner by specific Id
        [HttpGet("{id}", Name = "GetBanner")]
        public IActionResult GetById(long id)
        {
            var item = _context.Banners.FirstOrDefault(b => b.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        
        // Create and add a new banner
        [HttpPost]
        public IActionResult Create([FromBody] Banner banner)
        {
            if (banner == null)
            {
                return BadRequest();
            }

            banner.Created = DateTime.Now;
            
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(banner.Html);

            if (doc.ParseErrors.Count() > 0) {
                // Invalid HTML
                System.Diagnostics.Debug.WriteLine("invalid html");
                return BadRequest();
            }

            _context.Banners.Add(banner);
            _context.SaveChanges();

            return CreatedAtRoute("GetBanner", new { id = banner.Id }, banner);
        }

        // Update an existing banner
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Banner item)
        {
            if (item == null || item.Id != id)
            {
                return BadRequest();
            }
        
            var banner = _context.Banners.FirstOrDefault(b => b.Id == id);
            if (banner == null)
            {
                return NotFound();
            }
        
            banner.Id = item.Id;
            banner.Html = item.Html;
            banner.Modified = DateTime.Now;
        
            _context.Banners.Update(banner);
            _context.SaveChanges();
            return new NoContentResult();
        }

        // Delete a banner
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var banner = _context.Banners.FirstOrDefault(b => b.Id == id);
            if (banner == null)
            {
                return NotFound();
            }
        
            _context.Banners.Remove(banner);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}