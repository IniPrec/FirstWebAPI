﻿using FirstWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HatsControllers : ControllerBase
    {

        public static List<Hats> Hats = new List<Hats>
        {
            new Hats {ProductName = "Sinamay Hats", ProductId = 1, Category = "Church Hat", Price = "$20", Size = "XL" },
            new Hats {ProductName = "Second Hats", ProductId = 2, Category = "Church Hat", Price = "$20", Size = "XXL" }
        };

        [HttpGet]
        public IEnumerable<Hats> GetHats()
        {
            return Hats;
        }

        [HttpPost]
       public async Task<IActionResult> AddHat(string productName, string category, string price, string size)
        {
            Hats.Add(new Hats { Price = price, Size = size, ProductId = Hats.Count + 1, Category = category, ProductName = productName });

            return Ok(Hats);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateHat(int id, [FromBody] Hats hat)
        {
            var toBeUpdated = Hats.Find((eachHat)=> eachHat.ProductId == id);

            if (toBeUpdated == null)
            {
                return NotFound();
            }

            toBeUpdated.ProductName = hat.ProductName;
            toBeUpdated.Category = hat.Category;
            toBeUpdated.Size = hat.Size;
            toBeUpdated.Price = hat.Price;

            return Ok(toBeUpdated);
            
        }
        
        [HttpDelete]
        public IActionResult DeleteHat(int id, [FromBody] Hats hat) 
        {
            var toBeDeleted = Hats.Find((eachHat) => eachHat.ProductId == id);

            if (id == null)
            {
                return NotFound("Hat not found!");
            }

            Hats.Remove(toBeDeleted);
            return Ok("Successfully Deleted!");
        }
    }
}
